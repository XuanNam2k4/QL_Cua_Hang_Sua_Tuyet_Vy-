using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_64131375.Models;

namespace Project_64131375.Areas.Admin.Controllers
{
    public class SanPhamSuas_64131375Controller : Controller
    {
        private Project_64131375Entities db = new Project_64131375Entities();

        // GET: Admin/SanPhamSuas_64131375





        public bool IsQuantityValid(int soLuong)
        {
            // Lấy giá trị số lượng tối đa từ bảng ThamSo
            var soLuongToiDa = db.ThamSoes.FirstOrDefault(ts => ts.MaTS == "TS001")?.GiaTri;

            if (!string.IsNullOrEmpty(soLuongToiDa))
            {
                var soLuongToiDaInt = int.Parse(soLuongToiDa);
                // Kiểm tra số lượng sữa
                if (soLuong > soLuongToiDaInt)
                {
                    return false;
                }
            }

            return true;
        }



        public string getSanPhamSua(string LoaiSua)
        {
            var maxMaSua = db.SanPhamSuas.Where(n => n.MaLoaiSua == LoaiSua).Max(n => n.MaSua);
            int maSua = int.Parse(maxMaSua.Substring(LoaiSua.Length)) + 1;
            string LS = String.Concat("00", maSua.ToString());
            return LoaiSua + LS.ToString();
        }
        [HttpPost]
        public JsonResult GenerateMaSua(string LoaiSua)
        {
            string maSua = getSanPhamSua(LoaiSua); // Gọi hàm getSanPhamSua để tạo mã nhạc cụ
            return Json(maSua);
        }

























        // GET: Admin/SanPhamSuas_64131375
        public ActionResult Index(string maSua = "", string TenSua = "", string HanSuDung = "",
         string DonGiaMin = "", string DonGiaMax = "", string maLoaiSua = "", string maNCC = "", string maHSX = "", string SoLuong = "")
        {
            string min = DonGiaMin, max = DonGiaMax, soLuong = SoLuong;
            ViewBag.MaSua = maSua;
            ViewBag.TenSua = TenSua;
            ViewBag.HanSuDung = HanSuDung;
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
            if (max == "")
            {
                max = Int32.MaxValue.ToString();
                ViewBag.DonGiaMax = "";// Int32.MaxValue.ToString(); 
            }
            else
            {
                ViewBag.DonGiaMax = DonGiaMax;
                max = DonGiaMax;
            }
            ViewBag.SoLuong = SoLuong;
            ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua");
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            var sanphamSuas = db.SanPhamSuas.SqlQuery("SanPhamSua_TimKiem'" + maSua + "',N'" + TenSua + "',N'" + HanSuDung + "','" + min + "','" + max + "','" + SoLuong + "','" + maNCC + "'");

            if (SoLuong == "")
            {
                sanphamSuas = db.SanPhamSuas.SqlQuery("SanPhamSua_TimKiem'" + maSua + "',N'" + TenSua + "',N'" + HanSuDung + "','" + min + "','" + max + "','" + maLoaiSua + "','" + maNCC + "','" + maHSX + "'");
            }
            if (sanphamSuas.Count() == 0)
            {
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            }
            return View(sanphamSuas.ToList());
        }










        // GET: Admin/SanPhamSuas_64131375/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPhamSua sanPhamSua = db.SanPhamSuas.Find(id);
            if (sanPhamSua == null)
            {
                return HttpNotFound();
            }
            return View(sanPhamSua);
        }

        // GET: Admin/SanPhamSuas_64131375/Create
        public ActionResult Create()
        {
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX");
            ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            return View();
        }

        // POST: Admin/SanPhamSuas_64131375/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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






        //code này mới sữa từ chatgtp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSua,TenSua,MoTa,AnhSua,SoLuong,HanSuDung,DonGia,MaLoaiSua,MaNCC,MaHSX")] SanPhamSua sanPhamSua)
        {
            // Kiểm tra file upload
            var imgSua = Request.Files["AnhSua"];
            if (imgSua == null || imgSua.ContentLength == 0)
            {
                ModelState.AddModelError("AnhSua", "Vui lòng chọn ảnh sản phẩm sữa.");
                LoadDropDownLists(sanPhamSua);
                return View(sanPhamSua);
            }

            string postedFileName = Path.GetFileName(imgSua.FileName);
            string path = Server.MapPath("/Content/assets/img/SanPhamSua/" + postedFileName);

            try
            {
                // Lưu file ảnh vào server
                imgSua.SaveAs(path);
                sanPhamSua.AnhSua = postedFileName;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AnhSua", "Không thể lưu ảnh: " + ex.Message);
                LoadDropDownLists(sanPhamSua);
                return View(sanPhamSua);
            }

            // Kiểm tra ModelState
            if (ModelState.IsValid)
            {
                // Kiểm tra số lượng
                if (!IsQuantityValid(sanPhamSua.SoLuong))
                {
                    ModelState.AddModelError("SoLuong", "Số lượng sản phẩm vượt quá giới hạn cho phép.");
                    LoadDropDownLists(sanPhamSua);
                    return View(sanPhamSua);
                }

                // Gán mã sữa
                sanPhamSua.MaSua = Request.Form["MaSua"]?.Trim();

                // Kiểm tra khóa ngoại
                if (!db.LoaiSuas.Any(l => l.MaLoaiSua == sanPhamSua.MaLoaiSua))
                    ModelState.AddModelError("MaLoaiSua", "Mã loại sữa không tồn tại.");

                if (!db.NhaCungCaps.Any(n => n.MaNCC == sanPhamSua.MaNCC))
                    ModelState.AddModelError("MaNCC", "Mã nhà cung cấp không tồn tại.");

                if (!db.HangSanXuats.Any(h => h.MaHSX == sanPhamSua.MaHSX))
                    ModelState.AddModelError("MaHSX", "Mã hãng sản xuất không tồn tại.");

                if (!ModelState.IsValid)
                {
                    LoadDropDownLists(sanPhamSua);
                    return View(sanPhamSua);
                }

                // Lưu vào database
                try
                {
                    db.SanPhamSuas.Add(sanPhamSua);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            ModelState.AddModelError(validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Lỗi khi lưu dữ liệu: " + ex.Message);
                }
            }

            // Load lại danh sách dropdown nếu có lỗi
            LoadDropDownLists(sanPhamSua);
            return View(sanPhamSua);
        }

        //này code mới
        // Hàm tiện ích để load danh sách dropdown
        private void LoadDropDownLists(SanPhamSua sanPhamSua)
        {
            ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua", sanPhamSua.MaLoaiSua);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", sanPhamSua.MaNCC);
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", sanPhamSua.MaHSX);
        }



























        // GET: Admin/SanPhamSuas_64131375/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPhamSua sanPhamSua = db.SanPhamSuas.Find(id);
            if (sanPhamSua == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", sanPhamSua.MaHSX);
            ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua", sanPhamSua.MaLoaiSua);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", sanPhamSua.MaNCC);
            return View(sanPhamSua);
        }

        // POST: Admin/SanPhamSuas_64131375/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSua,TenSua,MoTa,AnhSua,SoLuong,HanSuDung,DonGia,MaLoaiSua,MaNCC,MaHSX")] SanPhamSua sanPhamSua)
        {
            var imgSua = Request.Files["AnhSua"];
            try
            {
                //Lấy thông tin từ input type=file có tên Avatar
                string postedFileName = System.IO.Path.GetFileName(imgSua.FileName);
                //Lưu hình đại diện về Server
                var path = Server.MapPath("/Content/assets/img/SanPhamSua/" + postedFileName);
                imgSua.SaveAs(path);
            }
            catch
            { }
            if (ModelState.IsValid)
            {
                db.Entry(sanPhamSua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", sanPhamSua.MaHSX);
            ViewBag.MaLoaiSua = new SelectList(db.LoaiSuas, "MaLoaiSua", "TenLoaiSua", sanPhamSua.MaLoaiSua);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", sanPhamSua.MaNCC);
            return View(sanPhamSua);
        }








        // GET: Admin/SanPhamSuas_64131375/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPhamSua sanPhamSua = db.SanPhamSuas.Find(id);
            if (sanPhamSua == null)
            {
                return HttpNotFound();
            }
            return View(sanPhamSua);
        }

        // POST: Admin/SanPhamSuas_64131375/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPhamSua sanPhamSua = db.SanPhamSuas.Find(id);
            db.SanPhamSuas.Remove(sanPhamSua);
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
