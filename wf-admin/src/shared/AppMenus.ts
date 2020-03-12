import { Menu } from '@delon/theme';
import { type } from 'os';

// 全局的左侧导航菜单
export class AppMenus {
    //平台管理菜单
    static Menus: Menu[] = [
        {
            text: "首页",// 无本地化显示字符
            //i18n: "HomePage",// 本地化主键(ABP本地化)
            acl: "",// 权限
            icon: { type: "icon", value: "home" },// 图标
            link: "/app/home", // url 地址
            // hide: true,  // 强制隐藏
            // ...还有更多选项，请查看 Menu成员
        },
        {
            text: "基础数据",
            icon: { type: "icon", value: "profile" },
            link: "/app/base",
            group: true,
            children: [
                {
                    text: "商品管理",
                    link: "/app/base/goodses",
                    reuse: false
                },
                {
                    text: "店铺管理",
                    link: "/app/base/shops",
                    reuse: false
                }
            ]
        },
        {
            text: "采购管理",
            icon: { type: "icon", value: "gift" },
            link: "/app/purchase",
            group: true,
            children: [
                {
                    text: "供应商管理",
                    link: "/app/purchase/suppliers",
                    reuse: false
                },
                {
                    text: "一键采购",
                    link: "/app/purchase/purchases",
                    reuse: false
                },
                {
                    text: "采购订单",
                    link: "/app/purchase/orders",
                    reuse: false
                }
            ]
        },
        {
            text: "仓储管理",
            icon: { type: "icon", value: "appstore" },
            link: "/app/warehouse ",
            group: true,
            children: [
                {
                    text: "仓库管理",
                    link: "/app/warehouse/warehouses",
                    reuse: false
                },
                {
                    text: "库存预警",
                    link: "/app/warehouse/purchases",
                    reuse: false
                },
                {
                    text: "出入库",
                    link: "/app/warehouse/depot",
                    reuse: false
                },
                {
                    text: "出入库流水",
                    link: "/app/warehouse/water",
                    reuse: false
                },
                {
                    text: "实时库存",
                    link: "/app/warehouse/real-stock",
                    reuse: false
                }
            ]
        },
        {
            text: "财务管理",
            icon: { type: "icon", value: "setting" },
            link: "/app/system",
            group: true,
            children: [
                {
                    text: "用户管理",
                    link: "/app/system/users",
                    reuse: false
                },
                {
                    text: "角色管理",
                    link: "/app/system/roles",
                    reuse: false
                },
                {
                    text: "数据字典",
                    link: "/app/system/datadictionary",
                    reuse: false
                },
            ]
        },
        {
            text: "钉钉管理",
            icon: { type: "icon", value: "dingding" },
            link: "/app/talk",
            group: true,
            children: [
                {
                    text: "组织架构",
                    link: "/app/talk/organization",
                    reuse: false
                },
                {
                    text: "钉钉配置",
                    link: "/app/talk/config",
                    reuse: false
                }
            ]
        },
        {
            text: "系统管理",
            icon: { type: "icon", value: "setting" },
            link: "/app/system",
            group: true,
            children: [
                {
                    text: "用户管理",
                    link: "/app/system/users",
                    reuse: false
                },
                {
                    text: "角色管理",
                    link: "/app/system/roles",
                    reuse: false
                },
                {
                    text: "数据字典",
                    link: "/app/system/datadictionary",
                    reuse: false
                },
            ]
        }
    ];
    //店铺收银菜单
    static ShopMenus: Menu[] = [
        {
            text: "主页",// 无本地化显示字符
            //i18n: "HomePage",// 本地化主键(ABP本地化)
            acl: "",// 权限
            icon: { type: "icon", value: "home" },// 图标
            link: "/app/home", // url 地址
            // hide: true,  // 强制隐藏
            // ...还有更多选项，请查看 Menu成员
        },
        {
            text: "微信配置",
            icon: { type: "icon", value: "wechat" },
            link: "/app/wechat/config",
            reuse: false
        },
        {
            text: "钉钉管理",
            icon: { type: "icon", value: "dingding" },
            link: "/app/talk",
            group: true,
            children: [
                {
                    text: "组织架构",
                    link: "/app/talk/organization",
                    reuse: false
                },
                {
                    text: "钉钉配置",
                    link: "/app/talk/config",
                    reuse: false
                }
            ]
        },
        {
            text: "系统管理",
            icon: { type: "icon", value: "setting" },
            link: "/app/system",
            group: true,
            children: [
                {
                    text: "用户管理",
                    link: "/app/system/users",
                    reuse: false
                },
                {
                    text: "角色管理",
                    link: "/app/system/roles",
                    reuse: false
                },
                {
                    text: "数据字典",
                    link: "/app/system/datadictionary",
                    reuse: false
                },
            ]
        }
    ];
    //商城会员菜单
    static MallMenus: Menu[] = [
        {
            text: "主页",// 无本地化显示字符
            //i18n: "HomePage",// 本地化主键(ABP本地化)
            acl: "",// 权限
            icon: { type: "icon", value: "home" },// 图标
            link: "/app/home", // url 地址
            // hide: true,  // 强制隐藏
            // ...还有更多选项，请查看 Menu成员
        },
        {
            text: "微信配置",
            icon: { type: "icon", value: "wechat" },
            link: "/app/wechat/config",
            reuse: false
        },
        {
            text: "钉钉管理",
            icon: { type: "icon", value: "dingding" },
            link: "/app/talk",
            group: true,
            children: [
                {
                    text: "组织架构",
                    link: "/app/talk/organization",
                    reuse: false
                },
                {
                    text: "钉钉配置",
                    link: "/app/talk/config",
                    reuse: false
                }
            ]
        },
        {
            text: "系统管理",
            icon: { type: "icon", value: "setting" },
            link: "/app/system",
            group: true,
            children: [
                {
                    text: "用户管理",
                    link: "/app/system/users",
                    reuse: false
                },
                {
                    text: "角色管理",
                    link: "/app/system/roles",
                    reuse: false
                },
                {
                    text: "数据字典",
                    link: "/app/system/datadictionary",
                    reuse: false
                },
            ]
        }
    ];
}