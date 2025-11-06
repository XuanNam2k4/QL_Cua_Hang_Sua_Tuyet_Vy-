using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_64131375.Models;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace Project_64131375.Controllers
{
    public class Payment_64131375Controller : Controller
    {
        private Project_64131375Entities db = new Project_64131375Entities();

        // GET: Payment_64131375


        string LayMaHD()
        {
            var maMax = db.HoaDons.ToList().Select(n => n.MaHD).Max();
            int maHD = int.Parse(maMax.Substring(2)) + 1;
            string HD = String.Concat("0000", maHD.ToString());
            return "HD" + HD.Substring(maHD.ToString().Length - 1);
        }
        public ActionResult Index_64131375()
        {
            if (Session["idMaKH"] == null)
            {
                return RedirectToAction("DangNhap_64131375", "Home_64131375");
            }
            else
            {
                //lấy thông giỏ hàng từ biến session
                var lstCart = (List<Cart_64131375Model>)Session["cart"];
                //gán dữ liệu cho bảng Order
                string maHoaDon = LayMaHD();
                HoaDon hoaDon = new HoaDon();

                hoaDon.MaHD = maHoaDon;
                hoaDon.NgayDH = DateTime.Now;
                hoaDon.NgayGH = DateTime.Now.AddDays(3);
                hoaDon.MaKH = Session["idMaKH"].ToString();
                hoaDon.MaNV = null;
                hoaDon.TinhTrangDuyet = false;
                hoaDon.TinhTrangDonHang = false;
                int tong = 0;
                foreach (var item in lstCart)
                {
                    tong += (item.Product.DonGia * item.Quantity);
                }
                hoaDon.TongTien = tong;
                // lưu
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                //Lấy hoaDon vừa mới tạo để lưu vào bảng CTHoaDon.
                List<CTHoaDon> dsctHD = new List<CTHoaDon>();

                foreach (var item in lstCart)
                {
                    CTHoaDon cthd = new CTHoaDon();
                    cthd.MaHD = maHoaDon;
                    cthd.MaSua = item.Product.MaSua;
                    cthd.SoLuongBan = item.Quantity;
                    cthd.DonGiaBan = item.Product.DonGia;

                    dsctHD.Add(cthd);

                }
                db.CTHoaDons.AddRange(dsctHD);
                db.SaveChanges();
                Session.Remove("cart");
                Session["count"] = null;

            }
            return View();
        }



        //    // GET: Payment_64131375/Details/5
        //    public ActionResult Details(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        HoaDon hoaDon = db.HoaDons.Find(id);
        //        if (hoaDon == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(hoaDon);
        //    }

        //    // GET: Payment_64131375/Create
        //    public ActionResult Create()
        //    {
        //        ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTenKH");
        //        ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV");
        //        return View();
        //    }

        //    // POST: Payment_64131375/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "MaHD,NgayDH,NgayGH,MaKH,MaNV,TongTien,TinhTrangDuyet,TinhTrangDonHang")] HoaDon hoaDon)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.HoaDons.Add(hoaDon);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTenKH", hoaDon.MaKH);
        //        ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV", hoaDon.MaNV);
        //        return View(hoaDon);
        //    }

        //    // GET: Payment_64131375/Edit/5
        //    public ActionResult Edit(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        HoaDon hoaDon = db.HoaDons.Find(id);
        //        if (hoaDon == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTenKH", hoaDon.MaKH);
        //        ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV", hoaDon.MaNV);
        //        return View(hoaDon);
        //    }

        //    // POST: Payment_64131375/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "MaHD,NgayDH,NgayGH,MaKH,MaNV,TongTien,TinhTrangDuyet,TinhTrangDonHang")] HoaDon hoaDon)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(hoaDon).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTenKH", hoaDon.MaKH);
        //        ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoTenNV", hoaDon.MaNV);
        //        return View(hoaDon);
        //    }

        //    // GET: Payment_64131375/Delete/5
        //    public ActionResult Delete(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        HoaDon hoaDon = db.HoaDons.Find(id);
        //        if (hoaDon == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(hoaDon);
        //    }

        //    // POST: Payment_64131375/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(string id)
        //    {
        //        HoaDon hoaDon = db.HoaDons.Find(id);
        //        db.HoaDons.Remove(hoaDon);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //}
    }
}
