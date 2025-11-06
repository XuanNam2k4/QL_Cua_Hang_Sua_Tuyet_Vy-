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
    public class HangSanXuats_64131375Controller : Controller
    {
        private Project_64131375Entities db = new Project_64131375Entities();

        // GET: Admin/HangSanXuats_64131375

        string LayMaHSX()
        {
            var maMax = db.HangSanXuats.ToList().Select(n => n.MaHSX).Max();
            int maHSX = int.Parse(maMax.Substring(3)) + 1;
            string HSX = String.Concat("00", maHSX.ToString());
            return "HSX" + HSX.Substring(maHSX.ToString().Length - 1);
        }




        public ActionResult Index(string maHSX = "", string TenHSX = "", string DiaChi = "", string SDT = "")
        {
            ViewBag.MaHSX = maHSX;
            ViewBag.TenHSX = TenHSX;
            ViewBag.DiaChi = DiaChi;
            ViewBag.SDT = SDT;
            var hangSanXuats = db.HangSanXuats.SqlQuery("HangSanXuat_TimKiem'" + maHSX + "',N'" + TenHSX + "',N'" + DiaChi + "',N'" + SDT + "'");

            if (hangSanXuats.Count() == 0)
            {
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            }
            return View(hangSanXuats.ToList());
        }



        // GET: Admin/HangSanXuats_64131375/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
            if (hangSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(hangSanXuat);
        }

        // GET: Admin/HangSanXuats_64131375/Create
        public ActionResult Create()
        {
            ViewBag.MaHSX = LayMaHSX();
            return View();
        }

        // POST: Admin/HangSanXuats_64131375/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHSX,TenHSX,DiaChi,SDT")] HangSanXuat hangSanXuat)
        {
            if (ModelState.IsValid)
            {
                hangSanXuat.MaHSX = LayMaHSX();
                db.HangSanXuats.Add(hangSanXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hangSanXuat);
        }



        // GET: Admin/HangSanXuats_64131375/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
            if (hangSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(hangSanXuat);
        }

        // POST: Admin/HangSanXuats_64131375/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHSX,TenHSX,DiaChi,SDT")] HangSanXuat hangSanXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangSanXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hangSanXuat);
        }

        // GET: Admin/HangSanXuats_64131375/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
            if (hangSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(hangSanXuat);
        }

        // POST: Admin/HangSanXuats_64131375/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
            db.HangSanXuats.Remove(hangSanXuat);
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
