using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_64131375.Models;

namespace Project_64131375.Areas.Admin.Controllers
{
    public class ThongKe_64131375Controller : Controller
    {
        private Project_64131375Entities db = new Project_64131375Entities();

        // GET: Admin/ThongKe_64131375



        public ActionResult Index(DateTime? fromDate, DateTime? toDate)
        {

            ViewBag.ValueFromDate = fromDate?.ToString("yyyy-MM-dd");
            ViewBag.ValueToDate = toDate?.ToString("yyyy-MM-dd");
            ViewBag.printFromDate = fromDate?.ToString("dd 'tháng' MM 'năm' yyyy");
            ViewBag.printToDate = toDate?.ToString("dd 'tháng' MM 'năm' yyyy");

            var salesReport = db.Database.SqlQuery<ThongKeBanHangModel_64131375>(
                    "EXEC GetSalesReport @FromDate, @ToDate",
                    new SqlParameter("FromDate", fromDate ?? SqlDateTime.MinValue),
                    new SqlParameter("ToDate", toDate ?? SqlDateTime.MaxValue)
                ).ToList();

            return View(salesReport);

        }

        // GET: admin/ThongKe_64131375/ThongKe_64131375
        public ActionResult ThongKe_64131375(string id)
        {
            var cTHoaDons = db.CTHoaDons.Include(c => c.HoaDon).Include(c => c.SanPhamSua);
            return View(cTHoaDons.ToList());
        }







        // GET: Admin/ThongKe_64131375/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cTHoaDon);
        }

        // GET: Admin/ThongKe_64131375/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaKH");
            ViewBag.MaSua = new SelectList(db.SanPhamSuas, "MaSua", "TenSua");
            return View();
        }

        // POST: Admin/ThongKe_64131375/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaSua,SoLuongBan,DonGiaBan")] CTHoaDon cTHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.CTHoaDons.Add(cTHoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaKH", cTHoaDon.MaHD);
            ViewBag.MaSua = new SelectList(db.SanPhamSuas, "MaSua", "TenSua", cTHoaDon.MaSua);
            return View(cTHoaDon);
        }

        // GET: Admin/ThongKe_64131375/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaKH", cTHoaDon.MaHD);
            ViewBag.MaSua = new SelectList(db.SanPhamSuas, "MaSua", "TenSua", cTHoaDon.MaSua);
            return View(cTHoaDon);
        }

        // POST: Admin/ThongKe_64131375/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaSua,SoLuongBan,DonGiaBan")] CTHoaDon cTHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTHoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaKH", cTHoaDon.MaHD);
            ViewBag.MaSua = new SelectList(db.SanPhamSuas, "MaSua", "TenSua", cTHoaDon.MaSua);
            return View(cTHoaDon);
        }

        // GET: Admin/ThongKe_64131375/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cTHoaDon);
        }

        // POST: Admin/ThongKe_64131375/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
            db.CTHoaDons.Remove(cTHoaDon);
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
