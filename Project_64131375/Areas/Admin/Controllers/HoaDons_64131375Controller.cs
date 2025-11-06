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
    public class HoaDons_64131375Controller : Controller
    {
        private Project_64131375Entities db = new Project_64131375Entities();

        // GET: Admin/HoaDons_64131375


        public ActionResult Index()
        {
           
            var hoaDons = db.HoaDons.Include(h => h.KhachHang).Include(h => h.NhanVien);
            return View(hoaDons.ToList());
        }

        [HttpPost]
        public ActionResult Index(string maHD,string tenKH,string tenNV)
        {
            // Include dữ liệu liên kết
            var hoaDons = db.HoaDons
                            .Include(h => h.KhachHang)
                            .Include(h => h.NhanVien)
                            .AsQueryable();

            // Kiểm tra chuỗi tìm kiếm không rỗng
            if (!string.IsNullOrEmpty(maHD))
            {
                hoaDons = hoaDons.Where(hd => hd.MaHD.ToString().Contains(maHD)); // Ép kiểu nếu cần
            }

            if (!string.IsNullOrEmpty(tenKH))
            {
                hoaDons = hoaDons.Where(hd => hd.KhachHang.HoTenKH.Contains(tenKH)); // Lấy tên khách hàng

            }


            if (!string.IsNullOrEmpty(tenNV))
            {
                hoaDons = hoaDons.Where(hd => hd.NhanVien.HoTenNV.Contains(tenNV)); // Lấy tên nhân viên

            }


            // Thông báo khi không có dữ liệu
            if (!hoaDons.Take(1).Any()) // Tối ưu hóa kiểm tra
            {
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            }

            // Giữ lại dữ liệu trên form
            ViewBag.mahd = maHD;
            ViewBag.tenKH = tenKH;
            ViewBag.tenNV = tenNV;

            // Trả về View với danh sách tìm kiếm
            return View(hoaDons.ToList());
        }


        public ActionResult HoaDonDaDuyet_64131375(string maHD, string tenKH, string tenNV)
        {
            // Include dữ liệu liên kết
            var hoaDons = db.HoaDons
                            .Include(h => h.KhachHang)
                            .Include(h => h.NhanVien)
                            .AsQueryable();

            // Kiểm tra chuỗi tìm kiếm không rỗng
            if (!string.IsNullOrEmpty(maHD))
            {
                hoaDons = hoaDons.Where(hd => hd.MaHD.ToString().Contains(maHD)); // Ép kiểu nếu cần
            }

            if (!string.IsNullOrEmpty(tenKH))
            {
                hoaDons = hoaDons.Where(hd => hd.KhachHang.HoTenKH.Contains(tenKH)); // Lấy tên khách hàng

            }


            if (!string.IsNullOrEmpty(tenNV))
            {
                hoaDons = hoaDons.Where(hd => hd.NhanVien.HoTenNV.Contains(tenNV)); // Lấy tên nhân viên

            }


            // Thông báo khi không có dữ liệu
            if (!hoaDons.Take(1).Any()) // Tối ưu hóa kiểm tra
            {
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            }

            // Giữ lại dữ liệu trên form
            ViewBag.mahd = maHD;
            ViewBag.tenKH = tenKH;
            ViewBag.tenNV = tenNV;

            // Trả về View với danh sách tìm kiếm
            return View(hoaDons.ToList());
        }


        //public ActionResult HoaDonDaDuyet_64131375()
        //{
        //    var hoaDons = db.HoaDons.Include(h => h.KhachHang).Include(h => h.NhanVien);
        //    return View(hoaDons.ToList());
        //}
        //public ActionResult HoaDonChuaDuyet_64131375(string maHD, string tenKH, string tenNV)
        //{
        //    var hoaDons = db.HoaDons.Include(h => h.KhachHang).Include(h => h.NhanVien);
        //    return View(hoaDons.ToList());
        //}

        public ActionResult HoaDonChuaDuyet_64131375(string maHD, string tenKH, string tenNV)
        {
            // Include dữ liệu liên kết
            var hoaDons = db.HoaDons
                            .Include(h => h.KhachHang)
                            .Include(h => h.NhanVien)
                            .AsQueryable();

            // Kiểm tra chuỗi tìm kiếm không rỗng
            if (!string.IsNullOrEmpty(maHD))
            {
                hoaDons = hoaDons.Where(hd => hd.MaHD.ToString().Contains(maHD)); // Ép kiểu nếu cần
            }

            if (!string.IsNullOrEmpty(tenKH))
            {
                hoaDons = hoaDons.Where(hd => hd.KhachHang.HoTenKH.Contains(tenKH)); // Lấy tên khách hàng

            }


            if (!string.IsNullOrEmpty(tenNV))
            {
                hoaDons = hoaDons.Where(hd => hd.NhanVien.HoTenNV.Contains(tenNV)); // Lấy tên nhân viên

            }


            // Thông báo khi không có dữ liệu
            if (!hoaDons.Take(1).Any()) // Tối ưu hóa kiểm tra
            {
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            }

            // Giữ lại dữ liệu trên form
            ViewBag.mahd = maHD;
            ViewBag.tenKH = tenKH;
            ViewBag.tenNV = tenNV;

            // Trả về View với danh sách tìm kiếm
            return View(hoaDons.ToList());
        }



        public ActionResult ChiTietHoaDon_64131375(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cTHoaDons = db.CTHoaDons.Include(c => c.HoaDon).Include(c => c.SanPhamSua).Where(n => n.MaHD == id);
            ViewBag.MaNC = new SelectList(db.SanPhamSuas, "MaSua", "TenSua");
            if (cTHoaDons == null)
            {
                return HttpNotFound();
            }
            return View(cTHoaDons.ToList());
        }







        // GET: Admin/HoaDons_64131375/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/HoaDons_64131375/Create
        //public ActionResult Create()
        //{
        //    ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTenKH");
        //    ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV");
        //    return View();
        //}



        public ActionResult Create()
        {
            var sanPhamSuas = db.SanPhamSuas.Include(n => n.HangSanXuat).Include(n => n.LoaiSua).Include(n => n.NhaCungCap);
            //ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTenKH");
            //ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV");
            return View(sanPhamSuas.ToList());
        }



        // POST: Admin/HoaDons_64131375/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,NgayDH,NgayGH,MaKH,MaNV,TongTien,TinhTrangDuyet,TinhTrangDonHang")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTenKH", hoaDon.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV", hoaDon.MaNV);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons_64131375/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTenKH", hoaDon.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV", hoaDon.MaNV);
            return View(hoaDon);
        }

        // POST: Admin/HoaDons_64131375/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MaHD,NgayDH,NgayGH,MaKH,MaNV,TongTien,TinhTrangDuyet,TinhTrangDonHang")] HoaDon hoaDon)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(hoaDon).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTenKH", hoaDon.MaKH);
        //    ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV", hoaDon.MaNV);
        //    return View(hoaDon);
        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the existing HoaDon from the database
                var existingHoaDon = db.HoaDons.Find(hoaDon.MaHD);
                if (existingHoaDon.TinhTrangDuyet == false)
                {
                    // Update the necessary fields
                    existingHoaDon.NgayGH = hoaDon.NgayGH;
                    existingHoaDon.TinhTrangDuyet = true;
                    existingHoaDon.MaNV = (string)Session["MaNV"];

                    // Mark the fields as modified in the entity state
                    db.Entry(existingHoaDon).Property(x => x.NgayGH).IsModified = true;
                    db.Entry(existingHoaDon).Property(x => x.TinhTrangDuyet).IsModified = true;
                    db.Entry(existingHoaDon).Property(x => x.MaNV).IsModified = true;
                }
                else
                {
                    // Update the necessary fields
                    existingHoaDon.TinhTrangDonHang = hoaDon.TinhTrangDonHang;
                    db.Entry(existingHoaDon).Property(x => x.TinhTrangDonHang).IsModified = true;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hoaDon);
        }







        // GET: Admin/HoaDons_64131375/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDons_64131375/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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
