

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WF.RetailCloud.DataDictionarys;

namespace WF.RetailCloud.DataDictionarys.Dtos
{
    public class CreateOrUpdateDataDictionaryInput
    {
        [Required]
        public DataDictionaryEditDto DataDictionary { get; set; }

    }
}
