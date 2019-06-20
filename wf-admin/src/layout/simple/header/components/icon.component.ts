import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
//import { RefundModalComponent } from 'app/routes/warehouse/sale-water/refund-modal/refund-modal.component';
import { ModalHelper } from '@delon/theme';
//import { HandoverComponent } from 'app/routes/shop/handover/handover.component';

@Component({
  selector: 'header-icon',
  template: `
  <nz-dropdown nzTrigger="click" nzPlacement="bottomRight" (nzVisibleChange)="change()">
    <div class="alain-default__nav-item" style="color: rgba(0,0,0,.85)" nz-dropdown>
      <i class="anticon anticon-appstore-o"></i>
    </div>
    <div nz-menu class="wd-xl animated jello">
      <nz-spin [nzSpinning]="loading" [nzTip]="'正在读取数据...'">
        <div nz-row [nzType]="'flex'" [nzJustify]="'center'" [nzAlign]="'middle'" class="app-icons">
          <div nz-col [nzSpan]="6" (click)="goHandover()">
            <i class="anticon anticon-calendar bg-error text-white"></i>
            <small>交接班</small>
          </div>
          <div nz-col [nzSpan]="6" (click)="goSale()">
            <i class="anticon anticon-file bg-geekblue text-white"></i>
            <small>交易流水</small>
          </div>
          <div nz-col [nzSpan]="6" (click)="goRefund()">
            <i class="anticon anticon-pay-circle-o bg-cyan text-white"></i>
            <small>退款</small>
          </div>
          <div nz-col [nzSpan]="6">
            <i class="anticon anticon-printer bg-grey text-white"></i>
            <small>票据补打</small>
          </div>
          <div nz-col [nzSpan]="6" (click)="goMember()">
            <i class="anticon anticon-team bg-purple text-white"></i>
            <small routerLink="/member/index">会员</small>
          </div>
          <div nz-col [nzSpan]="6" (click)="goInput()">
            <i class="anticon anticon-cloud bg-success text-white"></i>
            <small routerLink="/warehouse/put">入库</small>
          </div>
          <div nz-col [nzSpan]="6" (click)="goInventory()">
            <i class="anticon anticon-star-o bg-magenta text-white"></i>
            <small>盘点</small>
          </div>
          <div nz-col [nzSpan]="6">
            <i class="anticon anticon-scan bg-warning text-white"></i>
            <small>二维码</small>
          </div> 
        </div>
      </nz-spin>
    </div>
  </nz-dropdown>
  `,
  // 
})
export class HeaderIconComponent {
  // @ViewChild('refundModal') refundModal: RefundModalComponent;
  constructor(private router: Router
    , private modalHelper: ModalHelper
  ) {
  }
  loading = true;

  change() {
    setTimeout(() => (this.loading = false), 500);
  }
  goSale() {
    this.router.navigate(['warehouse/sale-water']);
  }

  goInput() {
    this.router.navigate(['warehouse/put']);
  }

  goInventory() {
    this.router.navigate(['warehouse/inventory']);
  }

  goMember() {
    this.router.navigate(['member/index']);
  }

  goRefund(): void {
    /*this.modalHelper
      .open(RefundModalComponent, {}, 950, {
        nzMask: true,
        nzMaskClosable: false,
        nzClosable: true,
        nzTitle: '退款',
      })
      .subscribe(isSave => {
        if (isSave) {
        }
      });*/
  }

  goHandover(): void {
    /*this.modalHelper
      .open(HandoverComponent, {}, 'md', {
        nzMask: true,
        nzMaskClosable: false,
        nzClosable: true,
        nzTitle: '交接班',
      })
      .subscribe(isSave => {
        if (isSave) {
        }
      });*/
  }
}
