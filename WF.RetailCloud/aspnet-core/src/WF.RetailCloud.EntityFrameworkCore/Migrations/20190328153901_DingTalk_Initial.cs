using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace WF.RetailCloud.Migrations
{
    public partial class DingTalk_Initial : Migration
    {
        protected override void Up([NotNull] MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Organizations",
              columns: table => new
              {
                  Id = table.Column<long>(nullable: false)
                      .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                  DepartmentName = table.Column<string>(maxLength: 100, nullable: false),
                  ParentId = table.Column<long>(nullable: true),
                  Order = table.Column<long>(nullable: true),
                  DeptHiding = table.Column<bool>(nullable: true),
                  OrgDeptOwner = table.Column<string>(maxLength: 100, nullable: true),
                  CreationTime = table.Column<DateTime>(nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Organizations", x => x.Id);
              });

            migrationBuilder.CreateTable(
             name: "Employees",
             columns: table => new
             {
                 Id = table.Column<string>(maxLength: 200, nullable: false)
                     .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                 Unionid = table.Column<string>(maxLength: 200, nullable: true),
                 Name = table.Column<string>(maxLength: 50, nullable: true),
                 Mobile = table.Column<string>(maxLength: 11, nullable: true),
                 Email = table.Column<string>(maxLength: 100, nullable: true),
                 Active = table.Column<bool>(nullable: true),
                 Department = table.Column<string>(maxLength: 300, nullable: true),
                 IsLeaderInDepts = table.Column<string>(maxLength: 300, nullable: true),
                 Position = table.Column<string>(maxLength: 100, nullable: true),
                 Avatar = table.Column<string>(maxLength: 200, nullable: true),
                 HiredDate = table.Column<DateTime>(nullable: true),
                 JobNumber = table.Column<string>(maxLength: 100, nullable: true),
                 CreationTime = table.Column<DateTime>(nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Employees", x => x.Id);
             });

            migrationBuilder.CreateTable(
             name: "DingTalkConfigs",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                 Type = table.Column<int>(nullable: false),
                 Code = table.Column<string>(maxLength: 50, nullable: false),
                 Value = table.Column<string>(maxLength: 500, nullable: true),
                 Remark = table.Column<string>(maxLength: 500, nullable: true),
                 Seq = table.Column<int>(nullable: true),
                 CreationTime = table.Column<DateTime>(nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_DingTalkConfigs", x => x.Id);
             });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
              name: "Organizations");

            migrationBuilder.DropTable(
               name: "Employees");

            migrationBuilder.DropTable(
               name: "DingTalkConfigs");
        }
    }
}

