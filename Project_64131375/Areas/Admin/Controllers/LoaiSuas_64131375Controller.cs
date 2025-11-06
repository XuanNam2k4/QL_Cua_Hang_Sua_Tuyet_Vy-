using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_64131375.Models;

namespace Project_64131375.Areas.Admin.Controllers
{
    public class LoaiSuas_64131375Controller : Controller
    {
        private Project_64131375Entities db = new Project_64131375Entities();

        // GET: Admin/LoaiSuas_64131375



        public ActionResult Index(string maLoaiSua = "", string tenLoaiSua = "")
        {
            ViewBag.MaLoaiSua = maLoaiSua;
            ViewBag.TenLoaiSua = tenLoaiSua;
            var loaiSuas = db.LoaiSuas.SqlQuery("LoaiSua_TimKiem'" + maLoaiSua + "',N'" + tenLoaiSua + "'");
            if (loaiSuas.Count() == 0)
            {
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            }
            return View(loaiSuas.ToList());
        }






        // GET: Admin/LoaiSuas_64131375/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSua loaiSua = db.LoaiSuas.Find(id);
            if (loaiSua == null)
            {
                return HttpNotFound();
            }
            return View(loaiSua);
        }

        // GET: Admin/LoaiSuas_64131375/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSuas_64131375/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MaLoaiSua,TenLoaiSua,AnhLoaiSua")] LoaiSua loaiSua)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.LoaiSuas.Add(loaiSua);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(loaiSua);
        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiSua,TenLoaiSua,AnhLoaiSua")] LoaiSua loaiSua)
        {
            var imgLoaiSua = Request.Files["AnhLoaiSua"];

            string postedFileName = System.IO.Path.GetFileName(imgLoaiSua.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Content/assets/img/LoaiSua/" + postedFileName);
            imgLoaiSua.SaveAs(path);
            if (ModelState.IsValid)
            {
                loaiSua.AnhLoaiSua = postedFileName;
                db.LoaiSuas.Add(loaiSua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiSua);
        }





        // GET: Admin/LoaiSuas_64131375/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSua loaiSua = db.LoaiSuas.Find(id);
            if (loaiSua == null)
            {
                return HttpNotFound();
            }
            return View(loaiSua);
        }

        // POST: Admin/LoaiSuas_64131375/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MaLoaiSua,TenLoaiSua,AnhLoaiSua")] LoaiSua loaiSua)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(loaiSua).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(loaiSua);
        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MaLoaiSua,TenLoaiSua,AnhLoaiSua")] LoaiSua loaiSua)
        //{
        //    var imgLoaiSua = Request.Files["AnhLoaiSua"];
        //    //Lấy thông tin từ input type=file có tên Avatar
        //    string postedFileName = System.IO.Path.GetFileName(imgLoaiSua.FileName);
        //    //Lưu hình đại diện về Server
        //    var path = Server.MapPath("/Content/assets/img/LoaiSua/" + postedFileName);
        //    imgLoaiSua.SaveAs(path);


        //    if (ModelState.IsValid)
        //    {

        //        db.Entry(loaiSua).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua", loaiSua.MaLoaiSua);

        //    return View(loaiSua);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiSua,TenLoaiSua,AnhLoaiSua")] LoaiSua loaiSua)
        {
            // Lấy đối tượng gốc từ database
            var dbLoaiSua = db.LoaiSuas.Find(loaiSua.MaLoaiSua);

            if (dbLoaiSua == null)
            {
                return HttpNotFound(); // Nếu không tìm thấy loại sữa trong DB
            }

            // Lấy thông tin ảnh đã chọn từ input file
            var imgLoaiSua = Request.Files["AnhLoaiSua"];

            // Kiểm tra nếu có file mới được tải lên
            if (imgLoaiSua != null && imgLoaiSua.ContentLength > 0)
            {
                // Lấy tên file
                string postedFileName = System.IO.Path.GetFileName(imgLoaiSua.FileName);

                // Đường dẫn đến thư mục lưu ảnh
                var folderPath = Server.MapPath("/Content/assets/img/LoaiSua/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath); // Tạo thư mục nếu chưa tồn tại
                }

                // Đường dẫn đầy đủ để lưu ảnh
                var path = Path.Combine(folderPath, postedFileName);

                // Lưu ảnh vào thư mục
                imgLoaiSua.SaveAs(path);

                // Cập nhật ảnh mới vào database
                dbLoaiSua.AnhLoaiSua = postedFileName;
            }

            // Cập nhật các thuộc tính khác (không đổi ảnh nếu không tải lên)
            dbLoaiSua.TenLoaiSua = loaiSua.TenLoaiSua;

            // Kiểm tra ModelState hợp lệ trước khi lưu vào database
            if (ModelState.IsValid)
            {
                db.Entry(dbLoaiSua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua", loaiSua.MaLoaiSua);
            return View(loaiSua);
        }




        // GET: Admin/LoaiSuas_64131375/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSua loaiSua = db.LoaiSuas.Find(id);
            if (loaiSua == null)
            {
                return HttpNotFound();
            }
            return View(loaiSua);
        }

        // POST: Admin/LoaiSuas_64131375/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiSua loaiSua = db.LoaiSuas.Find(id);
            db.LoaiSuas.Remove(loaiSua);
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
