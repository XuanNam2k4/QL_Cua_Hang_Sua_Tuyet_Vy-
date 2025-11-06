using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_64131375.Areas.Admin.Controllers
{
    public class Home_64131375Controller : Controller
    {
        // GET: Admin/Home_64131375
        public ActionResult Index()
        {
            if (Session["HoTen"] != null)
            {
                return View();
            }
            else return RedirectToAction("DangNhap_64131375", "TaiKhoan_64131375");
        }
    }
}