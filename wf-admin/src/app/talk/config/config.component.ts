import { Component, Injector, OnInit } from '@angular/core';
import {
  PagedListingComponentBase,
  PagedRequestDto,
  PagedResultDto
} from '@shared/component-base';
import { AppComponentBase } from '@shared/app-component-base';
import { TalkConfigService } from 'services';
import { CreateTalkConfigComponent } from '@app/talk/config/create-talk-config/create-talk-config.component'
import { EditTalkConfigComponent } from '@app/talk/config/edit-talk-config/edit-talk-config.component'
import { DingTalkConfig } from 'entities';

@Component({
  selector: 'app-config',
  templateUrl: './config.component.html',
  styles: [],
  providers: [TalkConfigService]
})
export class ConfigComponent extends AppComponentBase implements OnInit {
  constructor(injector: Injector, private configService: TalkConfigService) { super(injector); }
  configDing = [
    { value: 1, text: '公共配置', selected: true },
    { value: 2, text: '智能办公', selected: false },
  ]

  commonConfiguration: DingTalkConfig[] = [];
  intelligentOffice: DingTalkConfig[] = [];
  queryOffice: any = {
    pageIndex: 1,
    pageSize: 10,
    skipCount: function () { return (this.pageIndex - 1) * this.pageSize; },
    total: 0,
  };

  ngOnInit() {
    this.getConfig()
    this.getOffice()
  }
  // protected fetchDataList(
  //   request: PagedRequestDto,
  //   pageNumber: number,
  //   finishedCallback: Function,
  // ): void {
  //   let type;

  //   this.configService.getAll(request, type = 1)
  //     .finally(() => {
  //       finishedCallback();
  //     })
  //     .subscribe((result: PagedResultDto) => {
  //       this.commonConfiguration = result.items;
  //       this.commonConfigurationCount = result.totalCount;
  //     });


  //   this.configService.getAll(request, type = 2)
  //     .finally(() => {
  //       finishedCallback();
  //     })
  //     .subscribe((result: PagedResultDto) => {
  //       this.intelligentOffice = result.items;
  //       this.intelligentOfficeCount = result.totalCount;
  //     });
  // }

  //查询
  getConfig() {
    let params: any = {};
    params.SkipCount = this.query.skipCount();
    params.MaxResultCount = this.query.pageSize;
    params.type = 1;
    this.configService.getAll(params).subscribe((result: PagedResultDto) => {
      this.commonConfiguration = result.items;
      this.query.total = result.totalCount;
    })
  }
  getOffice() {
    let params: any = {};
    params.SkipCount = this.queryOffice.skipCount();
    params.MaxResultCount = this.queryOffice.pageSize;
    params.type = 2;
    this.configService.getAll(params).subscribe((result: PagedResultDto) => {
      this.intelligentOffice = result.items;
      this.queryOffice.total = result.totalCount;
    })
  }


  delete(entity: DingTalkConfig) {
    this.message.confirm(
      "是否确认删除该项'" + entity.typeName + "'?",
      '信息确认',
      (result: boolean) => {
        if (result) {
          this.configService.delete(entity.id).subscribe(() => {
            this.notify.success('删除成功！');
            this.ngOnInit();
          });
        }
      }
    );
  }

  editDing(item: DingTalkConfig): void {
    this.modalHelper.open(EditTalkConfigComponent, { id: item.id }, 'md', {
      nzMask: true, nzMaskClosable: false
    }).subscribe(isSave => {
      if (isSave) {
        this.ngOnInit();
      }
    });
  }
  create() {
    this.modalHelper.open(CreateTalkConfigComponent, {}, 'md', {
      nzMask: true, nzMaskClosable: false
    }).subscribe(isSave => {
      if (isSave) {
        this.ngOnInit();
      }
    });
  }
}
