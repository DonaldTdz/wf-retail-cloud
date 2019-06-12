import { Inject, Optional, Injectable } from "@angular/core";
import { Observer, Observable } from "rxjs";
import { CommonHttpClient } from "services/common-httpclient";
import { map } from "rxjs/operators";
import { DingTalkConfig } from "entities";
import { PagedResultDto } from "@shared/component-base";

@Injectable()
export class TalkConfigService {
    private _commonhttp: CommonHttpClient;

    constructor(@Inject(CommonHttpClient) commonhttp: CommonHttpClient) {
        this._commonhttp = commonhttp;
    }
    //获取分页数据
    getAll(params: any): Observable<PagedResultDto> {
        let url_ = "/api/services/app/DingTalkConfig/GetPagedByTypeAsync";
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
    getMessageById(id: string): Observable<DingTalkConfig> {
        let _url = "/api/services/app/DingTalkConfig/GetByIdAsync";
        let param = { 'id': id };
        return this._commonhttp.get(_url, param).pipe(map(data => {
            return DingTalkConfig.fromJS(data);
        }));
    }

    /**
     * 更新与创建配置
     * @param input 
     */
    createOrUpdate(input: DingTalkConfig): Observable<DingTalkConfig> {
        let _url = "/api/services/app/DingTalkConfig/CreateOrUpdateAsync";
        return this._commonhttp.post(_url, input).pipe(map(data => {
            return data;
        }))
    }


    /**
     * 删除配置
     * @param id 
     */
    delete(id: string): Observable<any> {
        let _url = "/api/services/app/DingTalkConfig/DeleteAsync";
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
