import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from '@app/home/home.component';
import { LayoutSimpleComponent } from '@layout/simple/simple.component';
//import { LayoutDefaultComponent } from '../layout/default/layout-default.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutSimpleComponent,
    canActivate: [AppRouteGuard],
    canActivateChild: [AppRouteGuard],
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      {
        path: 'home',
        component: HomeComponent,
        canActivate: [AppRouteGuard],
        data: { preload: true }
      },
      {
        path: 'system',
        loadChildren: './system/system.module#SystemModule',
        data: { preload: true },
      },
      {
        path: 'wechat',
        loadChildren: './wechat/wechat.module#WechatModule',
        data: { preload: true },
      },
      {
        path: 'talk',
        loadChildren: './talk/talk.module#TalkModule',
        data: { preload: true },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
