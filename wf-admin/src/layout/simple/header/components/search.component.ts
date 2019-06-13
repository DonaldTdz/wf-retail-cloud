import {
  Component,
  OnInit,
  ViewChild,
  HostListener,
  ElementRef,
  OnDestroy,
} from '@angular/core';
import { Subject, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, flatMap } from 'rxjs/operators';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'layout-simple-header-search',
  template: `
  <i class="anticon anticon-search"></i>
  <div class="input ant-select-auto-complete ant-select" [class.show]="show">
    <input #ipt placeholder="站内搜索" nz-input [nzAutocomplete]="searchAuto"
      [(ngModel)]="q"
      (input)="search$.next($event.target?.value)"
      (blur)="show=false">
  </div>
  <nz-autocomplete #searchAuto>
    <nz-auto-option *ngFor="let item of list" [nzValue]="item">
      {{item}}
    </nz-auto-option>
  </nz-autocomplete>
  `,
  host: {
    '[class.ad-header-search]': 'true',
    '[class.item]': 'true',
  },
  preserveWhitespaces: false,
})
export class LayoutSimpleHeaderSearchComponent implements OnInit, OnDestroy {
  @ViewChild('ipt') private ipt: ElementRef<any>;
  show = false;
  q: string;
  search$ = new Subject<string>();
  list: any[] = [];

  constructor(private http: _HttpClient) {
    this.search$
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        flatMap((q: string) => {
          // via http
          // return http.get<any[]>('/search', { q });
          return of([ '搜索提示一', '搜索提示二', '搜索提示三' ]);
        })
      )
      .subscribe(res => this.list = res);
  }

  @HostListener('click')
  _click() {
    this.ipt.nativeElement.focus();
    this.show = true;
  }

  ngOnInit(): void {}

  ngOnDestroy(): void {}
}
