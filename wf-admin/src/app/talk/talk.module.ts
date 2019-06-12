import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutModule } from '@layout/layout.module';
import { SharedModule } from '@shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { TalkRoutingModule } from './talk-routing.module';

import { ImageCropperModule } from 'ngx-img-cropper';
import { OrganizationComponent } from '@app/talk/organization/organization.component';
import { ConfigComponent } from '@app/talk/config/config.component';
import { CreateTalkConfigComponent } from './config/create-talk-config/create-talk-config.component';
import { EditTalkConfigComponent } from './config/edit-talk-config/edit-talk-config.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        TalkRoutingModule,
        LayoutModule,
        SharedModule,
        ImageCropperModule,
    ],
    declarations: [
        OrganizationComponent,
        ConfigComponent,
        CreateTalkConfigComponent,
        EditTalkConfigComponent],
    entryComponents: [
        OrganizationComponent,
        ConfigComponent,
        CreateTalkConfigComponent,
        EditTalkConfigComponent
    ],
    providers: []
})
export class TalkModule { }
