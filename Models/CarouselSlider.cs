using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INNOVITCarousel.Models
{
    public class CarouselSlider
    {

        //Write field and property of CarouselSlider as we have in the database table.
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> FileSize { get; set; }
        public string FilePath { get; set; }
    }
}
