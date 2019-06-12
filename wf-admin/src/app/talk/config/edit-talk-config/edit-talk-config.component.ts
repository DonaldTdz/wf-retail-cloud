import { Component, OnInit, Injector, Input } from '@angular/core';
import { TalkConfigService } from 'services';
import { DingTalkConfig } from 'entities';
import { ModalComponentBase } from '@shared/component-base';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  moduleId: module.id,
  selector: 'app-edit-talk-config',
  templateUrl: './edit-talk-config.component.html',
  styles: [],
  providers: [TalkConfigService]
})
export class EditTalkConfigComponent extends ModalComponentBase implements OnInit {
  @Input() id: number;
  dingTalkConfig: DingTalkConfig = new DingTalkConfig();
  DingDingType = [
    { value: 1, text: '公共配置' },
    { value: 2, text: '智能办公' },
  ]

  form: FormGroup;
  constructor(injector: Injector, private service: TalkConfigService, private fb: FormBuilder) { super(injector); }

  ngOnInit() {
    this.form = this.fb.group({
      type: [null, Validators.compose([Validators.required])],
      code: [null, Validators.compose([Validators.required])],
      value: [null, Validators.compose([Validators.maxLength(500)])],
      remark: [null, Validators.compose([Validators.maxLength(500)])],
      seq: [null, Validators.compose([Validators.pattern('^[0-9]*$')])],
    });
    this.fetchData();
  }
  fetchData(): void {
    this.service.getMessageById(this.id.toString()).subscribe((result) => {
      this.dingTalkConfig = result;
      console.log(result);
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
