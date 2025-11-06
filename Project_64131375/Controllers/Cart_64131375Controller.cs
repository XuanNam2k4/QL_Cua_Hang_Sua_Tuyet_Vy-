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
    public class Cart_64131375Controller : Controller
    {
        private Project_64131375Entities db = new Project_64131375Entities();


        // GET: Cart_64131375
        public ActionResult Index_64131375()
        {
            return View((List<Cart_64131375Model>)Session["cart"]);
        }

        //// GET: Cart_64131375/Details/5
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

        //// GET: Cart_64131375/Create
        //public ActionResult Create()
        //{
        //    ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX");
        //    ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua");
        //    ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
        //    return View();
        //}

        //// POST: Cart_64131375/Create
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

        //// GET: Cart_64131375/Edit/5
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

        //// POST: Cart_64131375/Edit/5
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

        //// GET: Cart_64131375/Delete/5
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

        //// POST: Cart_64131375/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    SanPhamSua sanPhamSua = db.SanPhamSuas.Find(id);
        //    db.SanPhamSuas.Remove(sanPhamSua);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        public ActionResult AddToCart(string id, int quantity)
        {
            if (Session["cart"] == null)
            {
                List<Cart_64131375Model> cart = new List<Cart_64131375Model>();
                cart.Add(new Cart_64131375Model { Product = db.SanPhamSuas.Find(id), Quantity = quantity });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<Cart_64131375Model> cart = (List<Cart_64131375Model>)Session["cart"];
                //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa???
                int index = isExist(id);
                if (index != -1)
                {
                    //nếu sp tồn tại trong giỏ hàng thì cộng thêm số lượng
                    cart[index].Quantity += quantity;
                }
                else
                {
                    //nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                    cart.Add(new Cart_64131375Model { Product = db.SanPhamSuas.Find(id), Quantity = quantity });
                    //Tính lại số sản phẩm trong giỏ hàng
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }

        public ActionResult UpdateCart(string id, int quantity)
        {
            if (Session["cart"] != null)
            {
                List<Cart_64131375Model> cart = (List<Cart_64131375Model>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    // Cập nhật số lượng sản phẩm trong giỏ hàng
                    cart[index].Quantity = quantity;
                    Session["cart"] = cart;
                    return Json(new { Message = "Cập nhật thành công", JsonRequestBehavior.AllowGet });
                }
            }
            return Json(new { Message = "Cập nhật thất bại", JsonRequestBehavior.AllowGet });
        }

        private int isExist(string id)
        {
            List<Cart_64131375Model> cart = (List<Cart_64131375Model>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.MaSua.Equals(id))
                    return i;
            return -1;
        }

        //xóa sản phẩm khỏi giỏ hàng theo id
        public ActionResult Remove(string Id)
        {
            List<Cart_64131375Model> li = (List<Cart_64131375Model>)Session["cart"];
            li.RemoveAll(x => x.Product.MaSua == Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
        // lấy số lượng sản phẩm trong giỏ    
        public ActionResult GetCartItemCount()
        {
            List<Cart_64131375Model> cart = (List<Cart_64131375Model>)Session["cart"];
            if (cart != null)
            {
                return Json(cart.Count, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
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
