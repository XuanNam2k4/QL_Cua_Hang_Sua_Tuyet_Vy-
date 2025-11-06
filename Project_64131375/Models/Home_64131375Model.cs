using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_64131375.Models
{
    public class Home_64131375Model
    {
        public IEnumerable<SanPhamSua> SanPhamSuas { get; set; }
        public IEnumerable<LoaiSua> LoaiSuas { get; set; }
        public IEnumerable<CTHoaDon> CTHoaDons { get; set; }
    }
}