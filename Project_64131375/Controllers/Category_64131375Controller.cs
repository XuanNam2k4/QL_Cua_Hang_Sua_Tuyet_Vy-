using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_64131375.Models;


namespace Project_64131375.Controllers
{
    public class Category_64131375Controller : Controller
    {
        private Project_64131375Entities db = new Project_64131375Entities();

        // GET: Category_64131375


        public ActionResult TimKiemSanPhamSua_64131375(string TenSua = "", string DonGiaMin = "", string DonGiaMax = "", string maLoaiSua = "")
        {
            string min, max;

            ViewBag.TenSua = TenSua;
            if (DonGiaMin == "")
            {
                ViewBag.DonGiaMin = "";
                min = "0";
            }
            else
            {
                ViewBag.DonGiaMin = DonGiaMin;
                min = DonGiaMin;
            }
            if (DonGiaMax == "")
            {
                max = Int32.MaxValue.ToString();
                ViewBag.DonGiaMax = "";// Int32.MaxValue.ToString(); 
            }
            else
            {
                ViewBag.DonGiaMax = DonGiaMax;
                max = DonGiaMax;
            }
            ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua");
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            var sanPhamSuas = db.SanPhamSuas.SqlQuery("SanPhamSua_TimKiem'" + "" + "',N'" + TenSua + "',N'" + "" + "','" + min + "','" + max + "','" + maLoaiSua + "'");



            if (sanPhamSuas.Count() == 0)
            {
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            }
            return View(sanPhamSuas.ToList());
        }






        //// GET: Category_64131375/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SanPhamSua sanPhamSua = db.SanPhamSuas.Find(id);
        //    if (sanPhamSua == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sanPhamSua);
        //}

        //// GET: Category_64131375/Create
        //public ActionResult Create()
        //{
        //    ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX");
        //    ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua");
        //    ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
        //    return View();
        //}

        //// POST: Category_64131375/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaSua,TenSua,MoTa,AnhSua,SoLuong,HanSuDung,DonGia,MaLoaiSua,MaNCC,MaHSX")] SanPhamSua sanPhamSua)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SanPhamSuas.Add(sanPhamSua);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", sanPhamSua.MaHSX);
        //    ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua", sanPhamSua.MaLoaiSua);
        //    ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", sanPhamSua.MaNCC);
        //    return View(sanPhamSua);
        //}

        //// GET: Category_64131375/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SanPhamSua sanPhamSua = db.SanPhamSuas.Find(id);
        //    if (sanPhamSua == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", sanPhamSua.MaHSX);
        //    ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua", sanPhamSua.MaLoaiSua);
        //    ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", sanPhamSua.MaNCC);
        //    return View(sanPhamSua);
        //}

        //// POST: Category_64131375/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MaSua,TenSua,MoTa,AnhSua,SoLuong,HanSuDung,DonGia,MaLoaiSua,MaNCC,MaHSX")] SanPhamSua sanPhamSua)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sanPhamSua).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", sanPhamSua.MaHSX);
        //    ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua", sanPhamSua.MaLoaiSua);
        //    ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", sanPhamSua.MaNCC);
        //    return View(sanPhamSua);
        //}

        //// GET: Category_64131375/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SanPhamSua sanPhamSua = db.SanPhamSuas.Find(id);
        //    if (sanPhamSua == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sanPhamSua);
        //}

        //// POST: Category_64131375/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    SanPhamSua sanPhamSua = db.SanPhamSuas.Find(id);
        //    db.SanPhamSuas.Remove(sanPhamSua);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
