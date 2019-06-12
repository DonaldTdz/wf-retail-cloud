export class DingTalkConfig {
    id: string;
    type: number;
    code: string;
    value: string;
    remark: string;
    seq: number;
    creationTime: Date;
    typeName: string;
    constructor(data?: IDingTalkConfig) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }
    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.type = data["type"];
            this.code = data["code"];
            this.value = data["value"];
            this.remark = data["remark"];
            this.seq = data["seq"];
            this.creationTime = data["creationTime"];
            this.typeName = data["typeName"];
        }
    }
    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["type"] = this.type;
        data["code"] = this.code;
        data["value"] = this.value;
        data["remark"] = this.remark;
        data["seq"] = this.seq;
        data["creationTime"] = this.creationTime;
        data["typeName"] = this.typeName;
        return data;
    }
    static fromJS(data: any): DingTalkConfig {
        let result = new DingTalkConfig();
        result.init(data);
        return result;
    }
    static fromJSArray(dataArray: any[]): DingTalkConfig[] {
        let array = [];
        dataArray.forEach(result => {
            let item = new DingTalkConfig();
            item.init(result);
            array.push(item);
        });
        return array;
    }
    clone() {
        const json = this.toJSON();
        let result = new DingTalkConfig();
        result.init(json);
        return result;
    }
}
export interface IDingTalkConfig {
    id: string;
    type: number;
    code: string;
    value: string;
    remark: string;
    seq: number;
    creationTime: Date;
}