using Project_64131375.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_64131375.Areas.Admin.Controllers
{
    public class TaiKhoan_64131375Controller : Controller
    {
        // GET: Admin/TaiKhoan_64131375


        private Project_64131375Entities db = new Project_64131375Entities();
        // GET: Admin/TaiKhoan_64131375
        public ActionResult DangNhap_64131375()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap_64131375(DangNhapModel_64131375 model)
        {
            if (ModelState.IsValid)
            {
                // Tìm nhân viên dựa trên tên đăng nhập 
                var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.TenDN == model.TenDN);

                if (nhanVien != null)
                {
                    // kiểm tra mã hóa mật khẩu
                    if (nhanVien.MatKhau == HashPassword(model.MatKhau) /*&& nhanVien.MaCV=="QL"*/)
                    {
                        //if (nhanVien.MaCV == "QL")
                        //{
                        // Đăng nhập thành công với quyền admin
                        // Thực hiện các thao tác cần thiết
                        FormsAuthentication.SetAuthCookie(model.TenDN, true);
                        Session["HoTen"] = nhanVien.HoTenNV;
                        Session["MaCV"] = nhanVien.MaCV;
                        Session["MaNV"] = nhanVien.MaNV;
                        return RedirectToAction("Index", "Home_64131375");

                        //}
                        //else if (nhanVien.MaCV == "BH")
                        //{
                        //    FormsAuthentication.SetAuthCookie(model.TenDN, true);
                        //    Session["HoTen"] = nhanVien.HoTenNV;
                        //    return RedirectToAction("Index", "Home");
                        //}

                    }
                    else ModelState.AddModelError("", "Mật khẩu không chính xác");

                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác");
                }
            }

            return View(model);
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("DangNhap_64131375", "TaiKhoan_64131375");
        }

        //Mã hóa mật khẩu sử dụng SHA256
        //private string HashPassword(string password)
        //{
        //    using (SHA256 sha256 = SHA256.Create())
        //    {
        //        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        StringBuilder builder = new StringBuilder();
        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString("x2"));
        //        }
        //        return builder.ToString();
        //    }
        //}
        public static string HashPassword(string str)
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
    }



}
