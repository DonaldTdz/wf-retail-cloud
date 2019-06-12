using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace WF.RetailCloud.Migrations
{
    public partial class Common_Initial : Migration
    {
        protected override void Up([NotNull] MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "DataDictionarys",
              columns: table => new
              {
                  Id = table.Column<long>(nullable: false)
                      .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                  Group = table.Column<int>(nullable: false),
                  Code = table.Column<string>(maxLength: 50, nullable: true),
                  Value = table.Column<string>(maxLength: 500, nullable: true),
                  Desc = table.Column<string>(maxLength: 500, nullable: true),
                  Seq = table.Column<int>(nullable: true),
                  CreationTime = table.Column<DateTime>(nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_DataDictionarys", x => x.Id);
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "DataDictionarys");
        }
    }
}

