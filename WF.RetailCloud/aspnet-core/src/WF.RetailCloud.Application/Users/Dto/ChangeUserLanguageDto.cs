using System.ComponentModel.DataAnnotations;

namespace WF.RetailCloud.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
