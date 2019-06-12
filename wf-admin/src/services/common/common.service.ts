import { Inject, Optional, Injectable } from "@angular/core";
import { Observer, Observable } from "rxjs";
import { CommonHttpClient } from "services/common-httpclient";
import { map } from "rxjs/operators";

@Injectable()
export class CommonService {
    private _commonhttp: CommonHttpClient;

    constructor(@Inject(CommonHttpClient) commonhttp: CommonHttpClient) {
        this._commonhttp = commonhttp;
    }

    changePassword(currentPassword: string, newPassword: string): Observable<boolean> {
        let url_ = "/api/services/app/User/ChangePassword";
        let params = { 'currentPassword': currentPassword, 'newPassword': newPassword };
        return this._commonhttp.post(url_, params).pipe(map(data => {
            console.log(data);
            return <boolean>data;
        }));
    }
}
