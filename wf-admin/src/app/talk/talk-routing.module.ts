import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { ConfigComponent } from '@app/talk/config/config.component';
import { OrganizationComponent } from '@app/talk/organization/organization.component';

const routes: Routes = [
    {
        path: 'config',
        component: ConfigComponent,
        canActivate: [AppRouteGuard],
    },
    {
        path: 'organization',
        component: OrganizationComponent,
        canActivate: [AppRouteGuard],
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class TalkRoutingModule { }
