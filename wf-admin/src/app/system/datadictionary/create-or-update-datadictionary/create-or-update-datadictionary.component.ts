import { Component, OnInit, Input, Injector } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataDictionaryService } from 'services'
import { ModalComponentBase } from '@shared/component-base';
import { DataDictionary } from 'entities'

@Component({
  selector: 'app-create-or-update-datadictionary',
  templateUrl: './create-or-update-datadictionary.component.html',
  styles: [],
  providers: [DataDictionaryService]
})
export class CreateOrUpdateDatadictionaryComponent extends ModalComponentBase implements OnInit {
  @Input() id: number;
  title: string;
  groupList = [{ value: 1, text: '项目分类' }
    , { value: 2, text: '项目明细分类' }
    , { value: 3, text: '报销分类' }
    , { value: 4, text: '公共配置' }
    , { value: 5, text: '税率' }];
  form: FormGroup;
  dataDictionary: DataDictionary = new DataDictionary();
  constructor(injector: Injector, private dataDictionaryService: DataDictionaryService, private fb: FormBuilder) { super(injector); }

  ngOnInit() {
    this.form = this.fb.group({
      group: [null, Validators.compose([Validators.required])],
      code: [null, Validators.compose([Validators.required, Validators.maxLength(100)])],
      value: [null, Validators.compose([Validators.maxLength(25), Validators.required])],
      desc: [null, Validators.compose([Validators.maxLength(100)])],
      seq: [null, Validators.compose([Validators.pattern('^[0-9]*$')])],
    });
    if (this.id) {
      this.getData();
      this.title = "编辑数据字典";
    } else {
      this.title = "新增数据字典";
    }
  }

  getData() {
    this.dataDictionaryService.getById(this.id.toString()).subscribe((result) => {
      this.dataDictionary = result;
    });
  }

  save() {
    this.dataDictionaryService.createOrUpdate(this.dataDictionary).finally(() => {
      this.saving = false;
    }).subscribe(() => {
      this.notify.success('保存成功！');
      this.success();
    });
  }

}
