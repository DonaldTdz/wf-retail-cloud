import { Menu } from '@delon/theme';
import { type } from 'os';

// 全局的左侧导航菜单
export class AppMenus {
    // new
    static Menus: Menu[] = [
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