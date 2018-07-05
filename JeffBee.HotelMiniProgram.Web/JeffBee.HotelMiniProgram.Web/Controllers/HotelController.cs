using JeffBee.HotelMiniProgram.Bll;
using JeffBee.HotelMiniProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JeffBee.HotelMiniProgram.Web.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            List<HotelInfo> infoList = HotelInfoBll<HotelInfo>.GetList().Where(c=>c.Id>0).ToList();
            return View();
        }
    }
}