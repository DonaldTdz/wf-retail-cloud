

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WF.RetailCloud.DingTalk.Organizations;

namespace WF.RetailCloud.DingTalk.Organizations.Dtos
{
    public class CreateOrUpdateOrganizationInput
    {
        [Required]
        public OrganizationEditDto Organization { get; set; }

    }
}
