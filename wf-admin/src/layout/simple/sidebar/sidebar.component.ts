import { Component, Input, ChangeDetectorRef } from '@angular/core';
import { Menu, SettingsService, MenuService } from '@delon/theme';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { Nav } from '@delon/abc/sidebar-nav/sidebar-nav.types';
import { Subscription } from 'rxjs';
import { ReuseTabService } from '@delon/abc';
import { AppSessionService } from '@shared/session/app-session.service';

@Component({
  selector: 'layout-simple-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.less'],
  preserveWhitespaces: false,
})
export class LayoutSimpleSidebarComponent {
  @Input() isMobile: boolean;
  @Input() theme: string;

  //menus: Menu[];
  private change$: Subscription;
  menus: Nav[] = [];
  shownLoginName = '';

  constructor(
    private menuService: MenuService,
    private router: Router,
    public settings: SettingsService,
    public reuseTabService: ReuseTabService,
    private cd: ChangeDetectorRef
  ) {
    /*menuSrv.change.subscribe(res => this.genMenus(res));
    router.events
      .pipe(filter(e => e instanceof NavigationEnd))
      .subscribe(res => this.openStatus());*/
    this.click(null);
  }

  ngOnInit(): void {
    this.change$ = <any>this.menuService.change.subscribe(res => {
      this.menus = res;
      this.processMenuOpen(this.reuseTabService.curUrl, this.menus);
      this.cd.detectChanges();
    });
  }

  get collapsed() {
    return this.settings.layout.collapsed;
  }

  hasChildren(item: Nav): boolean {
    if (item.children && item.children.length > 0) {
      return true;
    }
    return false;
  }

  /**
   * 处理菜单展开状态
   */
  processMenuOpen(currentUrl: string, menus: Nav[], parentMenu?: Nav): void {
    menus.forEach(item => {
      if (item.link === currentUrl) {
        if (parentMenu) {
          parentMenu._open = true;
        }
        item._selected = true;
      }

      if (item.children && item.children.length > 0) {
        this.processMenuOpen(currentUrl, item.children, item);
      }
    });
  }


  private genMenus(data?: Menu[]) {
    const res: Menu[] = [];
    let curMenu: Menu = null;
    const url = this.router.url;
    const inFn = (list: Menu[], parent: Menu) => {
      for (const item of list) {
        if (item._hidden === true) continue;
        if (!curMenu && item.link === url) {
          curMenu = item;
        }
        if (parent === null) res.push(item);
        if (item.children && item.children.length > 0) {
          inFn(item.children, item);
        } else {
          item.children = [];
        }
      }
    };
    // ingores category menus
    const ingoreCategores = (data || this.menuService.menus).reduce(
      (prev, cur) => prev.concat(cur.children),
      [],
    );
    inFn(ingoreCategores, null);
    if (curMenu) {
      curMenu._selected = true;
      do {
        curMenu = curMenu.__parent;
        if (curMenu) curMenu._open = true;
      } while (curMenu);
    }
    this.menus = res;
  }

  private openStatus() {
    let item: Menu;
    const url = this.router.url;
    const inFn = (list: Menu[], parent: Menu) => {
      for (const i of list) {
        i._open = false;
        i._selected = false;
        if (!item && i.link === url) {
          item = i;
          i._selected = true;
        }
        if (i.children && i.children.length > 0) {
          inFn(i.children, i);
        }
      }
    };
    inFn(this.menus, null);
    do {
      item = item.__parent;
      if (item) item._open = true;
    } while (item);
  }

  /*click(item: Menu) {
    if (item.externalLink) {
      if (item.target === '_blank') {
        window.open(item.externalLink);
      } else {
        location.href = item.externalLink;
      }
      return;
    }
    this.router.navigateByUrl(item.link);
    if (this.isMobile) {
      setTimeout(() => this.settings.setLayout('collapsed', true));
    }
  }*/

  private get isPad(): boolean {
    return window.innerWidth < 768;
  }

  click(item: Nav) {
    if (!item) {
      if (this.isMobile) {
        setTimeout(() => this.settings.setLayout('collapsed', true));
      }
      else if (this.isPad && !this.collapsed) {
        //this.settings.setLayout('collapsed', !this.settings.layout.collapsed);
        setTimeout(() => this.settings.setLayout('collapsed', !this.settings.layout.collapsed));
      }
      return;
    }
    if (item.externalLink) {
      if (item.target === '_blank') {
        window.open(item.externalLink);
      } else {
        location.href = item.externalLink;
      }
      return;
    }
    this.router.navigateByUrl(item.link);
    if (this.isMobile) {
      setTimeout(() => this.settings.setLayout('collapsed', true));
    }
    else if (this.isPad && !this.collapsed) {
      //this.settings.setLayout('collapsed', !this.settings.layout.collapsed);
      setTimeout(() => this.settings.setLayout('collapsed', !this.settings.layout.collapsed));
    }
  }

  ngOnDestroy(): void {
    if (this.change$) {
      this.change$.unsubscribe();
    }
  }
}
