using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace INNOVITCarousel.Models
{
    public class Picture
    {
        [Display(Name = "Picture Id")]
        public int pictureId { get; set; }

        [Required]
        [Display(Name = "Picture Name")]
        [Column(TypeName = "nvarchar(40)")]
        public string Filename { get; set; }

        [Display(Name = "Picture File path")]
        [Column(TypeName = "nvarchar(100)")]
        public string FilePath { get; set; }


    }
}
