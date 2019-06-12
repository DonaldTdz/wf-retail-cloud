export class Organization {
    id: string;
    departmentName: string;
    parentId: number;
    Order: number;
    deptHiding: boolean;
    orgDeptOwner: string;
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
            this.departmentName = data["departmentName"];
            this.parentId = data["parentId"];
            this.Order = data["Order"];
            this.deptHiding = data["deptHiding"];
            this.orgDeptOwner = data["orgDeptOwner"];
            this.creationTime = data["creationTime"];
        }
    }
    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["departmentName"] = this.departmentName;
        data["parentId"] = this.parentId;
        data["Order"] = this.Order;
        data["deptHiding"] = this.deptHiding;
        data["orgDeptOwner"] = this.orgDeptOwner;
        data["creationTime"] = this.creationTime;
        return data;
    }
    static fromJS(data: any): Organization {
        let result = new Organization();
        result.init(data);
        return result;
    }
    static fromJSArray(dataArray: any[]): Organization[] {
        let array = [];
        dataArray.forEach(result => {
            let item = new Organization();
            item.init(result);
            array.push(item);
        });
        return array;
    }
    clone() {
        const json = this.toJSON();
        let result = new Organization();
        result.init(json);
        return result;
    }
}