export class DataDictionary {
    id: string;
    group: number;
    code: string;
    value: string;
    desc: string;
    seq: number;
    creationTime: Date;
    constructor(data?: any) {
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
            this.group = data["group"];
            this.code = data["code"];
            this.value = data["value"];
            this.desc = data["desc"];
            this.seq = data["seq"];
            this.creationTime = data["creationTime"];
        }
    }
    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["group"] = this.group;
        data["code"] = this.code;
        data["value"] = this.value;
        data["desc"] = this.desc;
        data["seq"] = this.seq;
        data["creationTime"] = this.creationTime;
        return data;
    }
    static fromJS(data: any): DataDictionary {
        let result = new DataDictionary();
        result.init(data);
        return result;
    }
    static fromJSArray(dataArray: any[]): DataDictionary[] {
        let array = [];
        dataArray.forEach(result => {
            let item = new DataDictionary();
            item.init(result);
            array.push(item);
        });
        return array;
    }
    clone() {
        const json = this.toJSON();
        let result = new DataDictionary();
        result.init(json);
        return result;
    }
}