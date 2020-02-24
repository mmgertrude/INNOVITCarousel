using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using INNOVITCarousel.Models;
using System.Data;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace INNOVITCarousel.Controllers
{
    public class PictureController : Controller
    {
        private readonly ApplicationDBContext _context;
        
        public PictureController(ApplicationDBContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var pictureList = new List<Picture>();
            
            return View(pictureList);
        }

    }
}