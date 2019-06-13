import { Component, OnInit, Inject, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { SettingsService, ModalHelper } from '@delon/theme';
//import { DA_SERVICE_TOKEN, ITokenService } from '@delon/auth';
import { ChangePasswordComponent } from '../../change-password/change-password.component';
import { AppAuthService } from '@shared/auth';

@Component({
  selector: 'layout-simple-header-user',
  template: `
  <nz-dropdown nzPlacement="bottomRight">
    <div class="alain-default__nav-item d-flex align-items-center px-sm" style="color: rgba(0,0,0,.85)" nz-dropdown>
      <nz-avatar [nzSrc]="settings.user.avatar" nzSize="small" class="mr-sm"></nz-avatar>
      {{settings.user.name}}
    </div>
    <div nz-menu class="width-sm">
      <div nz-menu-item routerLink="/pro/account/center"><i nz-icon type="user" class="mr-sm"></i>
        个人中心
      </div>
      <div nz-menu-item (click)="changePassword()"><i nz-icon type="setting" class="mr-sm"></i>
        修改密码
      </div>
      <li nz-menu-divider></li>
      <div nz-menu-item (click)="logout()"><i nz-icon type="logout" class="mr-sm"></i>
        退出登录
      </div>
    </div>
  </nz-dropdown>
  `,
})
export class LayoutSimpleHeaderUserComponent {
  modalHelper: ModalHelper;
  constructor(
    public settings: SettingsService,
    private router: Router,
    injector: Injector,
    //@Inject(DA_SERVICE_TOKEN) private tokenService: ITokenService,
    private _authService: AppAuthService
  ) {
    this.modalHelper = injector.get(ModalHelper);
  }

  changePassword(): void {
    this.modalHelper
      .open(ChangePasswordComponent, {}, 'md', {
        nzMask: true,
        nzMaskClosable: false,
        nzClosable: true,
        nzTitle: '修改密码',
      })
      .subscribe(isSave => {
        if (isSave) {
          // this.refresh();
        }
      });
  }

  logout() {
    //this.tokenService.clear();
    //this.router.navigateByUrl(this.tokenService.login_url);
    this._authService.logout();
  }
}
