using System;
using System.Collections.Generic;
using System.Text;

namespace WF.RetailCloud.DingTalk.Organizations.Dtos
{
    public class DingDepartmentDto : DingBase
    {
        public List<DingDepartment> department { get; set; }
    }

    public class DingDepartment
    {
        public int id { get; set; }

        public string name { get; set; }

        public int parentid { get; set; }

        public bool createDeptGroup { get; set; }

        public bool autoAddUser { get; set; }
    }
}

