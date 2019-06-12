import 'rxjs/add/operator/finally';
import 'rxjs/add/operator/map';
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, from as _observableFrom, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from 'entities';
import { API_BASE_URL } from '@shared/service-proxies/service-proxies';
import { map } from "rxjs/operators";
import { CommonHttpClient } from 'services/common-httpclient';

@Injectable()
export class EmployeeServiceProxy {
    private _commonhttp: CommonHttpClient;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Inject(CommonHttpClient) commonhttp: CommonHttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this._commonhttp = commonhttp;
    }

    getAll(params: any): Observable<PagedResultDtoOfEmployee> {
        let url_ = "/api/services/app/Employee/GetEmployeeListByIdAsync";
        return this._commonhttp.get(url_, params).map(data => {
            if (data) {
                return PagedResultDtoOfEmployee.fromJS(data);
            } else {
                return null;
            }
        });
    }


    //获取人员下拉列表
    getDropDownDtos(): Observable<any> {
        let _url = "/api/services/app/Employee/GetDropDownDtosAsync";
        return this._commonhttp.get(_url).pipe(map(data => {
            return data;
        }));
    }
    // getEmployeeById(id: string): Observable<Employee> {
    //     let url_ = "/api/services/app/Employee/GetByIdAsync?id=" + id;
    //     return this._commonhttp.get(url_).map(data => {
    //         if (data) {
    //             return Employee.fromJS(data);
    //         } else {
    //             return null;
    //         }
    //     });
    // }
    // getEmployee(params: any): Observable<PagedResultDtoOfEmployee> {
    //     let url_ = "/api/services/app/Employee/GetPagedEmployeeAsync";
    //     return this._gyhttp.get(url_, params).map(data => {
    //         if (data) {
    //             return PagedResultDtoOfEmployee.fromJS(data);
    //         } else {
    //             return null;
    //         }
    //     });
    // // }
    // updateEmployeeArea(params: any): Observable<Employee> {
    //     let url_ = "/api/services/app/Employee/EditEmployeeAreaInfoAsync";
    //     return this._commonhttp.post(url_, params).map(data => {
    //         return data;
    //     });
    // }
}

export class PagedResultDtoOfEmployee implements IPagedResultDtoOfEmployee {
    totalCount: number;
    items: Employee[];

    constructor(data?: IPagedResultDtoOfEmployee) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.totalCount = data["totalCount"];
            if (data["items"] && data["items"].constructor === Array) {
                this.items = [];
                for (let item of data["items"])
                    this.items.push(Employee.fromJS(item));
            }
        }
    }

    static fromJS(data: any): PagedResultDtoOfEmployee {
        let result = new PagedResultDtoOfEmployee();
        result.init(data);
        return result;
    }
    static fromJSArray(dataArray: any[]): PagedResultDtoOfEmployee[] {
        let array = [];
        dataArray.forEach(result => {
            let item = new PagedResultDtoOfEmployee();
            item.init(result);
            array.push(item);
        });
        return array;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["totalCount"] = this.totalCount;
        if (this.items && this.items.constructor === Array) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        return data;
    }

    clone() {
        const json = this.toJSON();
        let result = new PagedResultDtoOfEmployee();
        result.init(json);
        return result;
    }
}
export class SwaggerException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}
export interface IPagedResultDtoOfEmployee {
    totalCount: number;
    items: Employee[];
}