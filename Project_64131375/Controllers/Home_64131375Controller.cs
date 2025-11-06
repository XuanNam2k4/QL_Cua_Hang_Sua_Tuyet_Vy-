using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_64131375.Models;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace Project_64131375.Controllers
{
    public class Home_64131375Controller : Controller
    {
        // GET: Home_64131375
        private Project_64131375Entities db = new Project_64131375Entities();
        // GET: Home_64131375

        string LayMaKH()
        {
            var maMax = db.KhachHangs.ToList().Select(n => n.MaKH).Max();
            int maKH = int.Parse(maMax.Substring(2)) + 1;
            string KH = String.Concat("0000", maKH.ToString());
            return "KH" + KH.Substring(maKH.ToString().Length - 1);
        }


        public ActionResult Index_64131375()
        {
            var model = new Home_64131375Model
            {
                SanPhamSuas = db.SanPhamSuas.Include(n => n.HangSanXuat).Include(n => n.LoaiSua).Include(n => n.NhaCungCap).ToList(),
                LoaiSuas = db.LoaiSuas.ToList(),
                CTHoaDons = db.CTHoaDons.ToList()
            };
            Session["DSLoaiSua"] = model.LoaiSuas;
            Session["SPdeXuat"] = model.SanPhamSuas;


            return View(model);
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }



        // GET: Home/Details/5
        public ActionResult DangKy_64131375()
        {


            return View();

        }
        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy_64131375(KhachHang _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.KhachHangs.FirstOrDefault(s => s.Email == _user.Email);

                _user.MaKH = LayMaKH();
                if (check == null)
                {
                    _user.MatKhau = GetMD5(_user.MatKhau);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KhachHangs.Add(_user);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Đăng ký thành công!";
                    return RedirectToAction("DangNhap_64131375");
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại!";
                    return View(_user);
                }


            }
            return RedirectToAction("DangKy_64131375");


        }




        public ActionResult QuenMatKhau_64131375()
        {

            return View();

        }

        public ActionResult DangNhap_64131375()
        {

            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
                TempData.Remove("SuccessMessage");
            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap_64131375(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = db.KhachHangs.Where(s => s.Email == email && s.MatKhau == f_password).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["idMaKH"] = data.FirstOrDefault().MaKH;
                    Session["HoTenKH"] = data.FirstOrDefault().HoTenKH;
                    Session["DiaChi"] = data.FirstOrDefault().DiaChi;


                    return RedirectToAction("Index_64131375");
                }
                else
                {
                    TempData["ErrorMessage"] = "Đăng nhập thất bại! tài khoản hoặc mật khẩu không chính xác";

                    ViewBag.ErrorMessage = TempData["ErrorMessage"];
                    TempData.Remove("ErrorMessage");
                    return View("DangNhap_64131375");
                }

            }
            return RedirectToAction("Index_64131375");
        }
        public ActionResult ThongTinKH_64131375()
        {
            if (Session["idMaKH"] != null)
            {
                KhachHang khachHang = db.KhachHangs.Find(Session["idMaKH"]);
                if (khachHang == null)
                {
                    return HttpNotFound();
                }
                return View(khachHang);

            }
            else
            {

                return View("DangNhap_64131375");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThongTinKH_64131375([Bind(Include = "HoTenKH, SDT, Email, DiaChi")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                // Lấy thông tin khách hàng từ cơ sở dữ liệu dựa trên khóa chính MaKH
                KhachHang existingKhachHang = db.KhachHangs.Find(Session["idMaKH"]);

                if (existingKhachHang != null)
                {

                    // Cập nhật các trường cụ thể
                    existingKhachHang.HoTenKH = khachHang.HoTenKH;
                    existingKhachHang.SDT = khachHang.SDT;
                    existingKhachHang.Email = khachHang.Email;
                    existingKhachHang.DiaChi = khachHang.DiaChi;
                    existingKhachHang.TaiKhoan = khachHang.Email;
                    Session["DiaChi"] = khachHang.DiaChi;
                    db.SaveChanges();


                }


                return RedirectToAction("ThongTinKH_64131375");
            }

            return View(khachHang);
        }

        public ActionResult ThayDoiMatKhau_64131375()
        {
            if (Session["idMaKH"] != null)
            {
                KhachHang khachHang = db.KhachHangs.Find(Session["idMaKH"]);
                if (khachHang == null)
                {
                    return HttpNotFound();
                }
                return View();

            }
            else
            {

                return View("DangNhap_64131375");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThayDoiMatKhau_64131375(string password, string changePassword)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                string makh = Session["idMaKH"].ToString();
                var data = db.KhachHangs.Where(s => s.MaKH == makh && s.MatKhau == f_password).ToList();
                if (data.Count() > 0)
                {
                    KhachHang existingKhachHang = db.KhachHangs.Find(makh);
                    var w_password = GetMD5(changePassword);
                    existingKhachHang.MatKhau = w_password;
                    db.SaveChanges();

                    TempData["SuccessMessage"] = "đổi mật khẩu thành công";

                    ViewBag.ErrorMessage = TempData["SuccessMessage"];
                    TempData.Remove("SuccessMessage");
                    return View("ThayDoiMatKhau_64131375");
                }
                else
                {
                    TempData["ErrorMessage"] = "mật khẩu không chính xác";

                    ViewBag.ErrorMessage = TempData["ErrorMessage"];
                    TempData.Remove("ErrorMessage");
                    return View("ThayDoiMatKhau_64131375");
                }

            }
            return RedirectToAction("ThayDoiMatKhau_64131375");
        }


        public ActionResult HoaDonKH_64131375()
        {
            if (Session["idMaKH"] != null)
            {
                string makh = Session["idMaKH"].ToString();
                var hoaDons = db.HoaDons.Where(s => s.MaKH == makh).Include(h => h.KhachHang).Include(h => h.NhanVien).ToList();
                if (hoaDons.Count() == 0)
                {
                    return RedirectToAction("Index_64131375");
                }
                return View(hoaDons);

            }
            else
            {
                return View("DangNhap_64131375");
            }

        }


        public ActionResult DangXuat_64131375()
        {
            Session.Clear();//remove session
            return RedirectToAction("DangNhap_64131375");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
