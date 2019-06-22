import {
  Component,
  ViewEncapsulation,
  ElementRef,
  Renderer2,
  Inject,
  OnInit
} from '@angular/core';
import {
  Router,
  NavigationEnd,
  RouteConfigLoadStart,
  NavigationError,
} from '@angular/router';
import { BreakpointObserver, MediaMatcher } from '@angular/cdk/layout';
import { NzMessageService, NzModalService } from 'ng-zorro-antd';
import { ScrollService, SettingsService, Menu } from '@delon/theme';
import { updateHostClass } from '@delon/util';
import { SignalRAspNetCoreHelper } from '@shared/helpers/SignalRAspNetCoreHelper';
//import { TokenService, DA_SERVICE_TOKEN } from '@delon/auth';

@Component({
  selector: 'layout-simple',
  templateUrl: './simple.component.html',
  styleUrls: ['./simple.component.less', './theme.less'],
  encapsulation: ViewEncapsulation.None,
})
export class LayoutSimpleComponent implements OnInit {
  width = 256;
  isFetching = false;
  isMobile = false;
  theme = this.settings.layout.theme === 'light' ? 'light' : 'dark';

  constructor(
    scroll: ScrollService,
    bm: BreakpointObserver,
    mediaMatcher: MediaMatcher,
    private router: Router,
    private _message: NzMessageService,
    public settings: SettingsService,
    private el: ElementRef,
    private renderer: Renderer2
  ) {
    // scroll to top in change page
    router.events.subscribe(evt => {
      if (!this.isFetching && evt instanceof RouteConfigLoadStart) {
        this.isFetching = true;
      }
      if (evt instanceof NavigationError) {
        this.isFetching = false;
        _message.error(`无法加载${evt.url}路由`, { nzDuration: 1000 * 3 });
        return;
      }
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
      setTimeout(() => {
        scroll.scrollToTop();
        this.isFetching = false;
      }, 100);
    });

    // media
    const query = {
      'screen-xs': '(max-width: 575px)',
      'screen-sm': '(min-width: 576px) and (max-width: 767px)',
      'screen-md': '(min-width: 768px) and (max-width: 991px)',
      'screen-lg': '(min-width: 992px) and (max-width: 1199px)',
      'screen-xl': '(min-width: 1200px)',
    };
    bm.observe([
      '(min-width: 1200px)',
      '(min-width: 992px) and (max-width: 1199px)',
      '(min-width: 768px) and (max-width: 991px)',
      '(min-width: 576px) and (max-width: 767px)',
      '(max-width: 575px)',
    ])
      .subscribe(() =>
        this.setClass(
          Object.keys(query).find(
            key => mediaMatcher.matchMedia(query[key]).matches,
          ),
        ),
      );
    // Mobile
    bm.observe('only screen and (max-width: 767.99px)').subscribe(state => {
      this.isMobile = state.matches;
      if (this.isMobile) {
        this.toggleCollapsedSidebar(true);
      } else {
        this.toggleCollapsedSidebar(false);
      }
    });
  }

  private setClass(queryCls) {
    updateHostClass(
      this.el.nativeElement,
      this.renderer,
      {
        ['layout-simple']: true,
        [queryCls]: true,
      },
      true,
    );
  }

  toggleCollapsedSidebar(status?: boolean) {
    this.settings.setLayout(
      'collapsed',
      typeof status !== 'undefined' ? status : !this.settings.layout.collapsed,
    );
  }

  ngOnInit(): void {

    SignalRAspNetCoreHelper.initSignalR(function () { });

    abp.event.on('abp.notifications.received', userNotification => {
      console.log(userNotification);
      abp.notifications.showUiNotifyForUserNotification(userNotification);

      // Desktop notification
      /*Push.create('AbpZeroTemplate', {
        body: userNotification.notification.data.message,
        icon: abp.appPath + 'assets/app-logo-small.png',
        timeout: 6000,
        onClick: function () {
          window.focus();
          this.close();
        }
      });*/
    });
  }

}
