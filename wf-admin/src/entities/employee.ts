export class Employee {
    id: string;
    unionid: string;
    name: string;
    mobile: string;
    email: string;
    active: boolean;
    department: string;
    isLeaderInDepts: string;
    position: string;
    avatar: string;
    hiredDate: Date;
    jobNumber: string;
    creationTime: Date;
    roleSelected: boolean;
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
            this.unionid = data["unionid"];
            this.name = data["name"];
            this.mobile = data["mobile"];
            this.email = data["email"];
            this.active = data["active"];
            this.department = data["department"];
            this.isLeaderInDepts = data["isLeaderInDepts"];
            this.position = data["position"];
            this.avatar = data["avatar"];
            this.hiredDate = data["hiredDate"];
            this.jobNumber = data["jobNumber"];
            this.creationTime = data["creationTime"];
        }
    }
    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["unionid"] = this.unionid;
        data["name"] = this.name;
        data["mobile"] = this.mobile;
        data["email"] = this.email;
        data["active"] = this.active;
        data["department"] = this.department;
        data["isLeaderInDepts"] = this.isLeaderInDepts;
        data["position"] = this.position;
        data["avatar"] = this.avatar;
        data["hiredDate"] = this.hiredDate;
        data["jobNumber"] = this.jobNumber;
        data["creationTime"] = this.creationTime;
        return data;
    }
    static fromJS(data: any): Employee {
        let result = new Employee();
        result.init(data);
        return result;
    }
    static fromJSArray(dataArray: any[]): Employee[] {
        let array = [];
        dataArray.forEach(result => {
            let item = new Employee();
            item.init(result);
            array.push(item);
        });
        return array;
    }
    clone() {
        const json = this.toJSON();
        let result = new Employee();
        result.init(json);
        return result;
    }
}