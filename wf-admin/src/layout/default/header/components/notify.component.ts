import { Component, ChangeDetectionStrategy, ChangeDetectorRef, OnInit, Injector } from '@angular/core';
import * as distanceInWordsToNow from 'date-fns/distance_in_words_to_now';
import { NzMessageService } from 'ng-zorro-antd';
import { NoticeItem, NoticeIconList } from '@delon/abc';
import { Router } from '@angular/router';
import { AppComponentBase } from '@shared/component-base';

/**
 * 菜单通知
 */
@Component({
    selector: 'header-notify',
    template: `
  <notice-icon
    [data]="data"
    [count]="count"
    [loading]="loading"
    (select)="select($event)"
    (clear)="clear($event)"
    (popoverVisibleChange)="getGetOrderTopSix($event)"></notice-icon>
  `
})
export class HeaderNotifyComponent extends AppComponentBase implements OnInit {
    data: NoticeItem[] = [
        {
            title: '待邮寄订单',
            list: [],
            emptyText: '你已完成所有待邮寄订单',
            emptyImage:
                'https://gw.alipayobjects.com/zos/rmsportal/HsIsxMZiWKrNUavQUXqx.svg',
            clearText: '更多',
        },
    ];
    count = 0;
    loading = false;
    constructor(private msg: NzMessageService, private cdr: ChangeDetectorRef,
        private router: Router, private injector: Injector
    ) {
        super(injector);
    }
    ngOnInit(): void {
        this.getGetOrderTopSix(true);
    }
    private updateNoticeData(notices: NoticeIconList[]): NoticeItem[] {
        const data = this.data.slice();
        data.forEach(i => (i.list = []));

        notices.forEach(item => {
            const newItem = { ...item };
            if (newItem.datetime)
                newItem.datetime = distanceInWordsToNow(item.datetime, {
                    locale: (window as any).__locale__,
                });
            if (newItem.extra && newItem.status) {
                newItem.color = {
                    todo: undefined,
                    processing: 'blue',
                    urgent: 'red',
                    doing: 'gold',
                }[newItem.status];
            }
            data.find(w => w.title === newItem.type).list.push(newItem);
        });
        return data;
    }

    getGetOrderTopSix(popoverVisible) {
        // this.popoverVisible = !this.popoverVisible;
        if (popoverVisible) {
            this.loading = true;
        }
    }

    clear(type: string) {

        // this.msg.success(`清空了 ${type}`);
    }

    select(res: any) {

        // this.msg.success(`点击了 ${res.title} 的 ${res.item.id}`);
    }
}
