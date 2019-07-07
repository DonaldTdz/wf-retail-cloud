import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { HeaderComponent } from './default/header/header.component';
import { SidebarComponent } from './default/sidebar/sidebar.component';
import { HeaderFullScreenComponent } from './default/header/components/fullscreen.component';
import { HeaderI18nComponent } from './default/header/components/i18n.component';
import { HeaderStorageComponent } from './default/header/components/storage.component';
import { HeaderUserComponent } from './default/header/components/user.component';
import { YoYoSidebarNavComponent } from './default/sidebar/components/yoyo-sidebar-nav.component';
import { LayoutDefaultComponent } from './default/layout-default.component';
//import { ChangePasswordComponent } from './default/change-password/change-password.component';
//import { HeaderNotifyComponent } from '@layout/default/header/components/notify.component';

const COMPONENTS = [
  HeaderComponent,
  SidebarComponent,
  LayoutDefaultComponent
];

const HEADERCOMPONENTS = [
  HeaderFullScreenComponent,
  HeaderI18nComponent,
  HeaderStorageComponent,
  HeaderUserComponent,
  ChangePasswordComponent,
  HeaderNotifyComponent,
];

const SIDEBARCOMPONENTS = [
  YoYoSidebarNavComponent
]

import { LayoutModule as CDKLayoutModule } from '@angular/cdk/layout';
import { LayoutSimpleComponent } from './simple/simple.component';
import { LayoutSimpleSidebarComponent } from './simple/sidebar/sidebar.component';
import { LayoutSimpleHeaderComponent } from './simple/header/header.component';
import { LayoutSimpleHeaderUserComponent } from './simple/header/components/user.component';
import { LayoutSimpleHeaderSearchComponent } from './simple/header/components/search.component';
import { ChangePasswordComponent } from './simple/change-password/change-password.component';
import { HeaderIconComponent } from './simple/header/components/icon.component';
import { HeaderNotifyComponent } from './simple/header/components/notify.component';

const SIMPLE = [
  LayoutSimpleSidebarComponent,
  LayoutSimpleHeaderComponent,
  LayoutSimpleHeaderUserComponent,
  LayoutSimpleHeaderSearchComponent,
  LayoutSimpleComponent,
  HeaderIconComponent,
];
// passport


@NgModule({
  imports: [
    SharedModule
  ],
  declarations: [
    ...COMPONENTS,
    ...HEADERCOMPONENTS,
    ...SIDEBARCOMPONENTS,
    ...SIMPLE
  ],
  exports: [
    ...COMPONENTS,
    ...SIMPLE
  ],
  entryComponents: [
    ChangePasswordComponent
  ],
  providers: [],
})
export class LayoutModule { }
