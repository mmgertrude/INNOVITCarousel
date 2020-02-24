using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DNADigital.DataAccess.Models
{
    public class SystemSetting : BaseEntity
    {
        
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(50)")]
       // [EnumDataType(typeof(SettingsType))]
        [Required]
        [Display(Name = "Settings Type")]
        public SettingsType Settings_type { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [AllowHtml]
        [Column(TypeName = "nvarchar(max)")]
        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Text")]
        public string Text { get; set; }


    }

    internal class AllowHtmlAttribute : Attribute
    {
    }

    public enum SettingsType
    {
        Text,
        HTML
    }
}
