

using INNOVITCarousel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;



namespace INNOVITCarousel.Controllers
{
    public class CarouselSliderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
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
        }

        /*
       
        [HttpPost]
        public ActionResult UploadSliderImage(string fileupload)
        {
            if (fileupload != null)
            {
                string fileName = Path.GetFileName(fileupload.Fil . FileName);
                int fileSize = fileupload.ContentLength;
                int Size = fileSize / 1000;
                fileupload.SaveAs(Server.MapPath("~/SliderImages/" + fileName));

                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spAddNewSliderImage", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Name", fileName);
                    cmd.Parameters.AddWithValue("@FileSize", Size);
                    cmd.Parameters.AddWithValue("FilePath", "~/SliderImages/" + fileName);
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction("UploadSliderImage");
        }

    */



    }


    







}
 