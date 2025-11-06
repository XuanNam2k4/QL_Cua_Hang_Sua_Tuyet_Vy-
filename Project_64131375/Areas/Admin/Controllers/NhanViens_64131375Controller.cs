using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Project_64131375.Models;

namespace Project_64131375.Areas.Admin.Controllers
{
    public class NhanViens_64131375Controller : Controller
    {
        private Project_64131375Entities db = new Project_64131375Entities();

        // GET: Admin/NhanViens_64131375




        string LayMaNV()
        {
            var maMax = db.NhanViens.ToList().Select(n => n.MaNV).Max();
            int maNV = int.Parse(maMax.Substring(2)) + 1;
            string NCC = String.Concat("0000", maNV.ToString());
            return "NV" + NCC.Substring(maNV.ToString().Length - 1);
        }



        // GET: Admin/NhanViens_64131375
        public ActionResult Index(string maNV = "", string hoTenNV = "", string SDT = "", string Email = "", string DiaChi = "", string tenDN = "", string maCV = "")
        {
            ViewBag.MaNV = maNV;
            ViewBag.HoTenNV = hoTenNV;
            ViewBag.SDT = SDT;
            ViewBag.Email = Email;
            ViewBag.DiaChi = DiaChi;
            ViewBag.TenDN = tenDN;
            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV");
            var nhanViens = db.NhanViens.SqlQuery("NhanVien_TimKiem'" + maNV + "',N'" + hoTenNV + "',N'" + SDT + "',N'" + Email + "',N'" + DiaChi + "',N'" + tenDN + "',N'" + maCV + "'");

            if (nhanViens.Count() == 0)
            {
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            }
            return View(nhanViens.ToList());
        }




        // Action đăng ký
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(NhanVien model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem mã chức vụ của nhân viên có phải là 'QL' hay không

                // Kiểm tra xem tên đăng nhập nhân viên đã tồn tại trong CSDL chưa
                bool isTenDNExists = db.NhanViens.Any(nv => nv.TenDN == model.TenDN);

                if (!isTenDNExists)
                {
                    var nhanVien = new NhanVien
                    {
                        MaNV = model.MaNV,
                        HoTenNV = model.HoTenNV,
                        SDT = model.SDT,
                        Email = model.Email,
                        DiaChi = model.DiaChi,
                        TenDN = model.TenDN,
                        MatKhau = HashPassword(model.MatKhau), // Mã hóa mật khẩu
                        MaCV = model.MaCV // Thiết lập mã chức vụ
                    };
                    // Lưu đối tượng NhanVien vào CSDL
                    db.NhanViens.Add(nhanVien);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã của nhân viên đã tồn tại");
                    ModelState.AddModelError("", "Vui lòng nhập tên khác");

                }
            }

            return View(model);
        }







        // GET: Admin/NhanViens_64131375/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanViens_64131375/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = LayMaNV();
            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV");
            return View();
        }





        // POST: Admin/NhanViens_64131375/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaNV,HoTenNV,AnhNV,SDT,Email,DiaChi,TenDN,MatKhau,MaCV")] NhanVien nhanVien)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.NhanViens.Add(nhanVien);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", nhanVien.MaCV);
        //    return View(nhanVien);
        //}




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,HoTenNV,AnhNV,SDT,Email,DiaChi,TenDN,MatKhau,MaCV")] NhanVien nhanVien)
        {
            string matKhau = Request["MatKhau"];
            string tenDN = Request["TenDN"];

            //System.Web.HttpPostedFileBase Avatar;
            var imgNV = Request.Files["AnhNV"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Content/assets/img/profiles/" + postedFileName);
            imgNV.SaveAs(path);
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tên đăng nhập nhân viên đã tồn tại trong CSDL chưa
                bool isTenDNExists = db.NhanViens.Any(nv => nv.TenDN == tenDN);
                if (!isTenDNExists)
                {
                    nhanVien.MatKhau = HashPassword(matKhau);
                    nhanVien.MaNV = LayMaNV();

                    nhanVien.MaNV = LayMaNV();
                    nhanVien.AnhNV = postedFileName;
                    db.NhanViens.Add(nhanVien);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã của nhân viên đã tồn tại");
                    ModelState.AddModelError("", "Vui lòng nhập tên khác");

                }
            }

            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", nhanVien.MaCV);
            return View(nhanVien);
        }






        // GET: Admin/NhanViens_64131375/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", nhanVien.MaCV);
            return View(nhanVien);
        }

        // POST: Admin/NhanViens_64131375/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MaNV,HoTenNV,AnhNV,SDT,Email,DiaChi,TenDN,MatKhau,MaCV")] NhanVien nhanVien)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(nhanVien).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", nhanVien.MaCV);
        //    return View(nhanVien);
        //}








        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,HoTenNV,AnhNV,SDT,Email,DiaChi,TenDN,MatKhau,MaCV")] NhanVien nhanVien)
        {
            var imgNV = Request.Files["AnhNV"];
            try
            {
                //Lấy thông tin từ input type=file có tên Avatar
                string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
                //Lưu hình đại diện về Server
                var path = Server.MapPath("/Content/assets/img/profiles/" + postedFileName);
                imgNV.SaveAs(path);
            }
            catch
            { }
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCV = new SelectList(db.ChucVus, "MaCV", "TenCV", nhanVien.MaCV);
            return View(nhanVien);
        }


        // GET: Admin/NhanViens_64131375/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanViens_64131375/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



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
