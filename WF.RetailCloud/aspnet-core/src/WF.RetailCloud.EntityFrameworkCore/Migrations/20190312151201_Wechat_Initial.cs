using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace WF.RetailCloud.Migrations
{
    public partial class Wechat_Initial : Migration
    {
        protected override void Up([NotNull] MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "WechatMessages",
              columns: table => new
              {
                  Id = table.Column<int>(nullable: false)
                      .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                  KeyWord = table.Column<string>(maxLength: 50, nullable: false),
                  MatchMode = table.Column<int>(nullable: false),
                  MsgType = table.Column<int>(nullable: false),
                  Content = table.Column<string>(maxLength: 200, nullable: true),
                  Title = table.Column<string>(maxLength: 200, nullable: true),
                  Desc = table.Column<string>(maxLength: 200, nullable: true),
                  PicLink = table.Column<string>(maxLength: 200, nullable: true),
                  Url = table.Column<string>(maxLength: 200, nullable: true),
                  TriggerType = table.Column<int>(nullable: false),
                  CreationTime = table.Column<DateTime>(nullable: false),
                  CreatorUserId = table.Column<long>(nullable: true),
                  LastModificationTime = table.Column<DateTime>(nullable: true),
                  LastModifierUserId = table.Column<long>(nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_WechatMessages", x => x.Id);
              });

            migrationBuilder.CreateTable(
              name: "WechatSubscribes",
              columns: table => new
              {
                  Id = table.Column<int>(nullable: false)
                      .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                  MsgType = table.Column<int>(nullable: false),
                  Content = table.Column<string>(maxLength: 200, nullable: true),
                  Title = table.Column<string>(maxLength: 200, nullable: true),
                  Desc = table.Column<string>(maxLength: 200, nullable: true),
                  PicLink = table.Column<string>(maxLength: 200, nullable: true),
                  Url = table.Column<string>(maxLength: 200, nullable: true),
                  CreationTime = table.Column<DateTime>(nullable: false),
                  CreatorUserId = table.Column<long>(nullable: true),
                  LastModificationTime = table.Column<DateTime>(nullable: true),
                  LastModifierUserId = table.Column<long>(nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_WechatSubscribes", x => x.Id);
              });

            migrationBuilder.CreateTable(
              name: "WechatUsers",
              columns: table => new
              {
                  Id = table.Column<long>(nullable: false)
                      .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                  UserType = table.Column<int>(nullable: false),
                  NickName = table.Column<string>(maxLength: 50, nullable: true),
                  OpenId = table.Column<string>(maxLength: 50, nullable: true),
                  UnionId = table.Column<string>(maxLength: 50, nullable: true),
                  WxOpenId = table.Column<string>(maxLength: 50, nullable: true),
                  UserId = table.Column<string>(maxLength: 36, nullable: true),
                  UserName = table.Column<string>(maxLength: 50, nullable: true),
                  Phone = table.Column<string>(maxLength: 20, nullable: true),
                  HeadImgUrl = table.Column<string>(maxLength: 500, nullable: true),
                  Address = table.Column<string>(maxLength: 500, nullable: true),
                  Integral = table.Column<decimal>(nullable: false),
                  BindStatus = table.Column<int>(nullable: false),
                  BindTime = table.Column<DateTime>(nullable: true),
                  UnBindTime = table.Column<DateTime>(nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_WechatUsers", x => x.Id);
              });
            
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "WechatMessages");

            migrationBuilder.DropTable(
               name: "WechatSubscribes");

            migrationBuilder.DropTable(
               name: "WechatUsers");
        }
    }
}

