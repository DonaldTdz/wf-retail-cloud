using WF.RetailCloud.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace WF.RetailCloud.Migrations
{
    [DbContext(typeof(RetailCloudDbContext))]
    [Migration("20190312151201_Wechat_Initial")]
    public partial class Wechat_Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {

        }
    }
}

