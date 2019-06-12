import { Component, OnInit, Injector } from '@angular/core';
import { NzFormatEmitEvent, NzTreeNode, NzDropdownContextComponent } from 'ng-zorro-antd';
import { AppComponentBase } from '@shared/app-component-base';
import { EmployeeServiceProxy, PagedResultDtoOfEmployee, OrganizationServiceProxy } from 'services'
import { Employee } from 'entities'

@Component({
  selector: 'app-organization',
  templateUrl: './organization.component.html',
  styleUrls: ['./organization.component.scss'],
  providers: [EmployeeServiceProxy, OrganizationServiceProxy]
})
export class OrganizationComponent extends AppComponentBase implements OnInit {

  constructor(injector: Injector, private employeeService: EmployeeServiceProxy, private organizationService: OrganizationServiceProxy) { super(injector); }
  syncDataLoading = false
  activedNode: NzTreeNode;
  nodes = [];
  loading = false;
  employeeList: Employee[] = [];
  tempNode: string;
  isSelectedAll: boolean = false; // 是否全选
  checkboxCount: number = 0; // 所有Checkbox数量
  checkedLength: number = 0; // 已选中的数量
  search: any = {};
  ngOnInit() {
    this.refreshData(null);
    this.getTrees();
  }

  refreshData(departId: string, reset = false, search?: boolean) {
    this.resetCheckBox();
    if (reset) {
      this.query.pageIndex = 1;
      this.search = {};
    }
    if (search) {
      this.query.pageIndex = 1;
    }
    this.loading = true;
    let params: any = {};
    params.SkipCount = this.query.skipCount();
    params.MaxResultCount = this.query.pageSize;
    params.departId = departId;
    params.Name = this.search.name;
    params.Mobile = this.search.mobile;
    this.employeeService.getAll(params).subscribe((result: PagedResultDtoOfEmployee) => {
      this.loading = false;
      this.employeeList = result.items;
      this.query.total = result.totalCount;
    })
  }

  openFolder(data: NzTreeNode | NzFormatEmitEvent): void {
    if (data instanceof NzTreeNode) {
      if (!data.isExpanded) {
        data.origin.isLoading = true;
        setTimeout(() => {
          data.isExpanded = !data.isExpanded;
          data.origin.isLoading = false;
        }, 500);
      } else {
        data.isExpanded = !data.isExpanded;
      }
    } else {
      // change node's expand status
      if (!data.node.isExpanded) {
        // close to open
        data.node.origin.isLoading = true;
        setTimeout(() => {
          data.node.isExpanded = !data.node.isExpanded;
          data.node.origin.isLoading = false;
        }, 500);
      } else {
        data.node.isExpanded = !data.node.isExpanded;
      }
    }
  }

  // 选中节点
  activeNode(data: NzFormatEmitEvent): void {
    if (this.activedNode) {
      this.activedNode = null;
    }
    data.node.isSelected = true;

    this.activedNode = data.node;
    this.query.pageIndex = 1;
    this.query.pageSize = 10;
    this.search = {};
    this.tempNode = data.node.key;

    this.refreshData(data.node.key);
  }

  resetCheckBox() {
    this.isSelectedAll = false; // 是否全选
    this.checkboxCount = 0; // 所有Checkbox数量
    this.checkedLength = 0; // 已选中的数量
  }

  syncData() {
    this.syncDataLoading = true;
    this.organizationService.synchronousOrganizationAsync().subscribe(() => {
      this.notify.info(this.l('同步成功！'), '');
      this.syncDataLoading = false;
      this.getTrees();
      this.refreshData(null);
    });
  }

  getTrees() {
    this.organizationService.GetTreesAsync().subscribe((data) => {
      this.nodes = data;
    });
  }

  checkAll(e) {
    let v = this.isSelectedAll;
    this.employeeList.forEach(u => {
      u.roleSelected = v;
    });
    if (this.isSelectedAll == false) {
      this.checkedLength = 0;
    } else {
      this.checkedLength = this.employeeList.filter(v => v.roleSelected).length;
    }
  }

  isCancelCheck(x: any) {
    this.checkedLength = this.employeeList.filter(v => v.roleSelected).length;
    this.checkboxCount = this.employeeList.length;
    if (this.checkboxCount - this.checkedLength > 0) {
      this.isSelectedAll = false;
    } else {
      this.isSelectedAll = true;
    }
  }
}
