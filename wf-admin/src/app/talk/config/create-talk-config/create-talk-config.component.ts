import { Component, OnInit, Injector } from '@angular/core';
import { TalkConfigService } from 'services';
import { DingTalkConfig } from 'entities';
import { ModalComponentBase } from '@shared/component-base';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  moduleId: module.id,
  selector: 'app-create-talk-config',
  templateUrl: './create-talk-config.component.html',
  styles: [],
  providers: [TalkConfigService]
})
export class CreateTalkConfigComponent extends ModalComponentBase implements OnInit {
  dingTalkConfig: DingTalkConfig = new DingTalkConfig();
  DingDingType = [
    { value: 1, text: '公共配置' },
    { value: 2, text: '智能办公' },
  ]

  form: FormGroup;
  constructor(injector: Injector, private service: TalkConfigService, private fb: FormBuilder) { super(injector); }

  ngOnInit() {
    this.dingTalkConfig.type = 1;
    this.form = this.fb.group({
      type: [null, Validators.compose([Validators.required])],
      code: [null, Validators.compose([Validators.required])],
      value: [null, Validators.compose([Validators.maxLength(500)])],
      remark: [null, Validators.compose([Validators.maxLength(500)])],
      seq: [null, Validators.compose([Validators.pattern('^[0-9]*$')])],
    });
  }
  save() {
    this.service.createOrUpdate(this.dingTalkConfig).finally(() => {
      this.saving = false;
    }).subscribe(() => {
      this.notify.success(this.l('SavedSuccessfully'));
      this.success();
    });
  }

}
