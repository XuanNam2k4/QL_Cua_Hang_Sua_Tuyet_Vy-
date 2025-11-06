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
    public class CTHoaDons_64131375Controller : Controller
    {
        private Project_64131375Entities db = new Project_64131375Entities();

        // GET: Admin/CTHoaDons_64131375
        //public ActionResult Index(string maHD,string tenSua)
        //{

        //    var cthoaDons = db.CTHoaDons
        //                   .Include(h => h.HoaDon)
        //                   .Include(h => h.SanPhamSua)
        //                   .AsQueryable();

        //    // Kiểm tra chuỗi tìm kiếm không rỗng
        //    if (!string.IsNullOrEmpty(maHD))
        //    {
        //        cthoaDons = cthoaDons.Where(hd => hd.MaHD.ToString().Contains(maHD)); // Ép kiểu nếu cần
        //    }
        //    if (!string.IsNullOrEmpty(tenSua))
        //    {
        //        cthoaDons = cthoaDons.Where(hd => hd.SanPhamSua.TenSua.ToString().Contains(tenSua)); // Ép kiểu nếu cần
        //    }

        //    // Chuyển danh sách kết quả về dạng List
        //    var resultList = cthoaDons.ToList();

        //    // Thông báo nếu không có kết quả tìm kiếm
        //    if (!resultList.Any())
        //    {
        //        ViewBag.TB = "Không có thông tin tìm kiếm."; // Thêm thông báo
        //    }


        //    ViewBag.MaSua = new SelectList(db.SanPhamSuas, "MaSua", "TenSua");
        //    ViewBag.MaHD = maHD;
        //    ViewBag.TenSua = tenSua;

        //    return View(resultList.ToList());
        //}



        public ActionResult Index(string maHD, string tenSua, int? donGia)
        {
            // Lấy danh sách dữ liệu ban đầu
            var cthoaDons = db.CTHoaDons
                              .Include(h => h.HoaDon)
                              .Include(h => h.SanPhamSua)
                              .AsQueryable();

            // Tìm kiếm theo mã hóa đơn
            if (!string.IsNullOrEmpty(maHD))
            {
                cthoaDons = cthoaDons.Where(hd => hd.MaHD.ToString().Contains(maHD));
            }

            // Tìm kiếm theo tên sữa
            if (!string.IsNullOrEmpty(tenSua))
            {
                cthoaDons = cthoaDons.Where(hd => hd.SanPhamSua.TenSua.Contains(tenSua));
            }

            // Tìm kiếm theo đơn giá
            if (donGia.HasValue && donGia > 0)
            {
                cthoaDons = cthoaDons.Where(hd => hd.SanPhamSua.DonGia == donGia);
            }

            // Chuyển danh sách kết quả về dạng List
            var resultList = cthoaDons.ToList();

            // Thông báo nếu không có kết quả tìm kiếm
            if (!resultList.Any())
            {
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            }

            // Truyền dữ liệu lên View
            ViewBag.MaSua = new SelectList(db.SanPhamSuas, "MaSua", "TenSua");
            ViewBag.MaHD = maHD;
            ViewBag.TenSua = tenSua;
            ViewBag.DonGia = donGia; // Lưu lại giá trị đơn giá trên form tìm kiếm

            return View(resultList);
        }




        // GET: Admin/CTHoaDons_64131375/Details/5

        public ActionResult Details(string maHD, string maSua)
        {
            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maSua))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CTHoaDon cTHoaDon = db.CTHoaDons.Find(maHD, maSua);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }

            return View(cTHoaDon);
        }




        // GET: Admin/CTHoaDons_64131375/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
        //    if (cTHoaDon == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cTHoaDon);
        //}

        // GET: Admin/CTHoaDons_64131375/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaKH");
            ViewBag.MaSua = new SelectList(db.SanPhamSuas, "MaSua", "TenSua");
            return View();
        }

        // POST: Admin/CTHoaDons_64131375/Create
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

        // GET: Admin/CTHoaDons_64131375/Edit/5
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

        // POST: Admin/CTHoaDons_64131375/Edit/5
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

        //// GET: Admin/CTHoaDons_64131375/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
        //    if (cTHoaDon == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cTHoaDon);
        //}

        //// POST: Admin/CTHoaDons_64131375/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
        //    db.CTHoaDons.Remove(cTHoaDon);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        // GET: Admin/CTHoaDons_64131375/Delete/5
        public ActionResult Delete(string maHD, string maSua)
        {
            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maSua))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CTHoaDon cTHoaDon = db.CTHoaDons.Find(maHD, maSua);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }

            return View(cTHoaDon); // Trả về view để xác nhận xóa
        }

        // POST: Admin/CTHoaDons_64131375/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string maHD, string maSua)
        {
            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maSua))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CTHoaDon cTHoaDon = db.CTHoaDons.Find(maHD, maSua);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }

            db.CTHoaDons.Remove(cTHoaDon);
            db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

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
