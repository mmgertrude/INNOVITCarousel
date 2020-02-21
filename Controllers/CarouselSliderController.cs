using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using INNOVITCarousel.Models;
using System.Data.SqlClient;
using System.Data;

namespace INNOVITCarousel.Controllers
{
    public class CarouselSliderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /*
        [HttpGet]
        public ActionResult UploadSliderImage()
        {
            List<CarouselSlider> sliderimages = new List<CarouselSlider>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllSliderImage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CarouselSlider slider = new CarouselSlider();
                    slider.ID = Convert.ToInt32(rdr["ID"]);
                    slider.Name = rdr["Name"].ToString();
                    slider.FileSize = Convert.ToInt32(rdr["FileSize"]);
                    slider.FilePath = rdr["FilePath"].ToString();

                    sliderimages.Add(slider);
                }
            }
            return View(sliderimages);
        }*/



    }


    







}