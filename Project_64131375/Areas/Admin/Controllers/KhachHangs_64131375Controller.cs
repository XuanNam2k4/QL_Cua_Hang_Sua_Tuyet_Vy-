using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_64131375.Models;

namespace Project_64131375.Areas.Admin.Controllers
{
    public class KhachHangs_64131375Controller : Controller
    {
        private Project_64131375Entities db = new Project_64131375Entities();

        // GET: Admin/KhachHangs_64131375
     
        public ActionResult Index(string maKH = "", string hoTenKH = "", string SDT = "", string Email = "", string DiaChi = "", string taiKhoan = "")
        {
            ViewBag.MaKH = maKH;
            ViewBag.HoTenKH = hoTenKH;
            ViewBag.SDT = SDT;
            ViewBag.Email = Email;
            ViewBag.DiaChi = DiaChi;
            ViewBag.TaiKhoan = taiKhoan;
            var khachHangs = db.KhachHangs.SqlQuery("KhachHang_TimKiem'" + maKH + "',N'" + hoTenKH + "',N'" + SDT + "',N'" + Email + "',N'" + DiaChi + "',N'" + taiKhoan + "'");

            if (khachHangs.Count() == 0)
            {
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            }
            return View(khachHangs.ToList());
        }




        // GET: Admin/KhachHangs_64131375/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: Admin/KhachHangs_64131375/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhachHangs_64131375/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,HoTenKH,SDT,Email,DiaChi,TaiKhoan,MatKhau,AnhKH")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }

        // GET: Admin/KhachHangs_64131375/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/KhachHangs_64131375/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,HoTenKH,SDT,Email,DiaChi,TaiKhoan,MatKhau,AnhKH")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: Admin/KhachHangs_64131375/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/KhachHangs_64131375/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
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
    }
}
