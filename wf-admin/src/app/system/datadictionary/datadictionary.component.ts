import { Component, OnInit, Injector } from '@angular/core';
import { DataDictionary } from 'entities'
import { DataDictionaryService } from 'services'
import { AppComponentBase } from '@shared/app-component-base';
import { PagedResultDto } from '@shared/component-base/paged-listing-component-base';
import { CreateOrUpdateDatadictionaryComponent } from './create-or-update-datadictionary/create-or-update-datadictionary.component'


@Component({
  selector: 'app-datadictionary',
  templateUrl: './datadictionary.component.html',
  styles: [],
  providers: [DataDictionaryService]
})
export class DatadictionaryComponent extends AppComponentBase implements OnInit {
  search: any = {};
  tableLoading = false
  dataDictionary: DataDictionary = new DataDictionary();
  group = [{ value: 1, text: '项目分类' }
    , { value: 2, text: '项目明细分类' }
    , { value: 3, text: '报销分类' }
    , { value: 4, text: '公共配置' }
    , { value: 5, text: '税率' }];
  constructor(injector: Injector, private dataDictionaryService: DataDictionaryService) {
    super(injector);
  }

  ngOnInit() {
    this.getDataDictionarys();
  }

  //查询
  getDataDictionarys() {
    this.tableLoading = true;
    let params: any = {};
    params.SkipCount = this.query.skipCount();
    params.MaxResultCount = this.query.pageSize;
    params.Value = this.search.value;
    params.Group = this.search.group;
    params.sorting = "Group";
    this.dataDictionaryService.getAll(params).subscribe((result: PagedResultDto) => {
      this.tableLoading = false
      this.query.dataList = result.items;
      this.query.total = result.totalCount;
    })
  }

  //删除
  delete(entity: DataDictionary) {
    this.message.confirm(
      "是否确认删除数据:'" + entity.value + "'?",
      '信息确认',
      (result: boolean) => {
        if (result) {
          this.dataDictionaryService.delete(entity.id).subscribe(() => {
            this.notify.success('删除成功！');
            this.getDataDictionarys();
          });
        }
      }
    )
  }

  //编辑
  editDing(item: DataDictionary) {
    this.modalHelper.open(CreateOrUpdateDatadictionaryComponent, { id: item.id }, 'md', {
      nzMask: true
    }).subscribe(isSave => {
      if (isSave) {
        this.getDataDictionarys();
      }
    });
  }

  //创建
  create() {
    this.modalHelper.open(CreateOrUpdateDatadictionaryComponent, {}, 'md', {
      nzMask: true
    }).subscribe(isSave => {
      if (isSave) {
        this.getDataDictionarys();
      }
    });
  }

  //重置
  refresh() {
    this.search = {};
    this.query.pageIndex = 1;
    this.getDataDictionarys();
  }

}
