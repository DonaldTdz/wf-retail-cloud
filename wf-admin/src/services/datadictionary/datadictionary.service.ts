import { Inject, Optional, Injectable } from "@angular/core";
import { Observer, Observable } from "rxjs";
import { CommonHttpClient } from "services/common-httpclient";
import { map } from "rxjs/operators";
import { PagedResultDto } from "@shared/component-base";
import { DataDictionary } from "entities";

@Injectable()
export class DataDictionaryService {
    private _commonhttp: CommonHttpClient;

    constructor(@Inject(CommonHttpClient) commonhttp: CommonHttpClient) {
        this._commonhttp = commonhttp;
    }
    //获取分页数据
    getAll(params: any): Observable<PagedResultDto> {
        let url_ = "/api/services/app/DataDictionary/GetPagedAsync";
        return this._commonhttp.get(url_, params).pipe(map(data => {
            const result = new PagedResultDto();
            result.items = data.items;
            result.totalCount = data.totalCount;
            return result;
        }));
    }
    /**
 * 获取单条数据
 * @param id 
 */
    getById(id: string): Observable<DataDictionary> {
        let _url = "/api/services/app/DataDictionary/GetByIdAsync";
        let param = { 'id': id };
        return this._commonhttp.get(_url, param).pipe(map(data => {
            return DataDictionary.fromJS(data);
        }));
    }

    /**
     * 更新与创建配置
     * @param input 
     */
    createOrUpdate(input: DataDictionary | null): Observable<DataDictionary> {
        let _url = "/api/services/app/DataDictionary/CreateOrUpdateAsync";
        return this._commonhttp.post(_url, { "DataDictionary": input }).pipe(map(data => {
            return data;
        }))
    }

    //根据group获取字典下拉列表
    getDropDownDtos(group: string): Observable<any> {
        let _url = "/api/services/app/DataDictionary/GetDropDownDtosByGroupAsync";
        return this._commonhttp.get(_url, { group: group }).pipe(map(data => {
            return data;
        }));
    }


    /**
     * 删除配置
     * @param id 
     */
    delete(id: string): Observable<any> {
        let _url = "/api/services/app/DataDictionary/DeleteAsync";
        let param = { 'id': id };
        return this._commonhttp.delete(_url, param);
    }

    // getWechatUserById(params: any): Observable<WechatUser> {
    //     let url_ = "/api/services/app/WechatUser/GetById";
    //     return this._commonhttp.get(url_, params).pipe(map(data => {
    //         return WechatUser.fromJS(data);
    //     }));
    // }

}
