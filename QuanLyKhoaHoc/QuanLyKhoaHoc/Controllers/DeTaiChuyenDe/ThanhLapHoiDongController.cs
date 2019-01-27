using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers.DeTaiChuyenDe
{
    public class ThanhLapHoiDongController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();

        // GET: ThanhLapHoiDong
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachHoiDong()
        {
            var lsHoiDong = dbc.khThanhLapHoiDongs.ToList();
            return PartialView(lsHoiDong);
        }

        public ActionResult ThongTinHoiDong()
        {
            return PartialView();
        }

        public ActionResult LoadChiTietHoiDong(int id_HoiDong = -1)
        {
            var lsCTietHoiDOng = from ct in dbc.khThanhLapHoiDongChiTiets
                                 join hd in dbc.khThanhLapHoiDongs on ct.ID_hd equals hd.ID_hd
                                 join cb in dbc.khCanBos on ct.ID_cb equals cb.ID_cb into ps
                                 from cb in ps.DefaultIfEmpty()
                                 join cvdv in dbc.dmChucVuDonVis on cb.ID_chuc_vu equals cvdv.ID_chuc_vu into pv
                                 from cvdv in pv.DefaultIfEmpty()
                                 join dv in dbc.dmDonViQuanLies on cb.ID_dv equals dv.ID_dv into pd
                                 from dv in pd.DefaultIfEmpty()
                                 join cvhd in dbc.dmChucVuHoiDongs on ct.ID_chuc_vu_hd equals cvhd.ID_chuc_vu_hd into ph
                                 from cvhd in ph.DefaultIfEmpty()
                                 where ct.ID_hd == id_HoiDong
                                 select new ChiTietHoiDong
                                 {
                                     ID_hd_chi_tiet = ct.ID_hd_chi_tiet,
                                     ID_hd = ct.ID_hd,
                                     Ten_hd = hd.Ten_hd,
                                     ID_cb = ct.ID_cb,
                                     Ma_cb = cb.Ma_cb!=null ? cb.Ma_cb : "",
                                     Ho_ten = cb.Ho_ten!=null ? cb.Ho_ten : "",
                                     Chuc_vu_dv = cvdv.Chuc_vu != null ? cvdv.Chuc_vu : "",
                                     SDT = cb.Di_dong != null ? cb.Di_dong : "",
                                     Ten_Don_Vi = dv.Ten_dv !=null ? dv.Ten_dv : "",
                                     ID_chuc_vu_hd = ct.ID_chuc_vu_hd ,
                                     Chuc_vu_hd = cvhd.Chuc_vu!=null ? cvhd.Chuc_vu : "",
                                     Ghi_chu = ct.Ghi_chu,
                                 };
            var ls = lsCTietHoiDOng.ToList();
            return PartialView(ls);
        }


        public void Save_HoiDong(khThanhLapHoiDong hoidong)
        { 
            
        }
    }
}