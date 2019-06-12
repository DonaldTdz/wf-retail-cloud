export class Account {
    id: string;
    companyId: number;
    type: number;
    initial: number;
    amount: number;
    ending: number;
    desc: string;
    refId: string;
    creationTime: Date;
    typeName: string;
    constructor(data?: IAccount) {
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
            this.companyId = data["companyId"];
            this.type = data["type"];
            this.initial = data["initial"];
            this.amount = data["amount"];
            this.ending = data["ending"];
            this.desc = data["desc"];
            this.refId = data["refId"];
            this.typeName = data["typeName"];
            this.creationTime = data["creationTime"];
        }
    }
    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["companyId"] = this.companyId;
        data["type"] = this.type;
        data["initial"] = this.initial;
        data["amount"] = this.amount;
        data["ending"] = this.ending;
        data["desc"] = this.desc;
        data["refId"] = this.refId;
        data["typeName"] = this.typeName;
        data["creationTime"] = this.creationTime;
        return data;
    }
    static fromJS(data: any): Account {
        let result = new Account();
        result.init(data);
        return result;
    }
    static fromJSArray(dataArray: any[]): Account[] {
        let array = [];
        dataArray.forEach(result => {
            let item = new Account();
            item.init(result);
            array.push(item);
        });
        return array;
    }
    clone() {
        const json = this.toJSON();
        let result = new Account();
        result.init(json);
        return result;
    }
}
export interface IAccount {
    id: string;
    companyId: number;
    type: number;
    initial: number;
    amount: number;
    ending: number;
    desc: string;
    refId: string;
    creationTime: Date;
}