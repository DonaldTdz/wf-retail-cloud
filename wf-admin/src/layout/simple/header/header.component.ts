import { Component, Input, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { SettingsService } from '@delon/theme';
import { AppAuthService } from '@shared/auth';
//import { DA_SERVICE_TOKEN, ITokenService } from '@delon/auth';

@Component({
  selector: 'layout-simple-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.less'],
  host: {
    '[class.layout-simple__head]': 'true',
  },
})
export class LayoutSimpleHeaderComponent {
  @Input() isMobile: boolean;

  constructor(
    public settings: SettingsService,
    private router: Router,
    //@Inject(DA_SERVICE_TOKEN) private tokenService: ITokenService,
    private _authService: AppAuthService
  ) {

  }

  toggleCollapsedSidebar() {
    this.settings.setLayout('collapsed', !this.settings.layout.collapsed);
  }

  logout() {
    //this.tokenService.clear();
    //this.router.navigateByUrl(this.tokenService.login_url);
    this._authService.logout();
  }
}
