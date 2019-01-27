using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers.DeTaiChuyenDe
{
    public class TuyenChonController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: TuyenChon
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachDeTaiTuyenChon(int nam = 0, bool detai = true, bool duyet = true)
        {
            nam = nam == 0 ? DateTime.Now.Year : nam;
            var lsTuyenChon = from ct in dbc.khDeTais.Where(u => u.Nam == nam && u.De_tai == detai).ToList()
                              join cb in dbc.khCanBos.ToList() on ct.ID_cb equals cb.ID_cb into lcb
                              from cb in lcb.DefaultIfEmpty()
                              join cv in dbc.dmChucVuDonVis.ToList() on cb.ID_chuc_vu equals cv.ID_chuc_vu into lcv
                              from cv in lcv.DefaultIfEmpty()
                              join dv in dbc.dmCoQuanChuQuans.ToList() on ct.ID_cq_cq equals dv.ID_cq_cq into ldv
                              from dv in ldv.DefaultIfEmpty()
                              join xd in dbc.khXetDuyetDeTais.ToList() on ct.ID_de_tai equals xd.ID_de_tai into lxd
                              from xd in lxd.DefaultIfEmpty()
                              select new DeTai_TuyenChon
                              {
                                  ID_xet_detai = (xd != null) ? xd.ID_xet_detai : -1,
                                  ID_de_tai = ct.ID_de_tai,
                                  Ma_de_tai = ct.Ma_de_tai,
                                  Ten_de_tai_vn = ct.Ten_de_tai_vn,
                                  Ten_Can_Bo = (cb != null && !string.IsNullOrEmpty(cb.Ho_ten)) ? cb.Ho_ten : "",
                                  Ten_Don_Vi = (dv != null && !string.IsNullOrEmpty(dv.Ten_cq)) ? dv.Ten_cq : "",
                                  Ngay_Xet = (xd != null) ? xd.Ngay_xet.Day + "/" + xd.Ngay_xet.Month + "/" + xd.Ngay_xet.Year : "",
                              };

            var ls = duyet ? lsTuyenChon.Where(u => u.ID_xet_detai > 0).ToList() : lsTuyenChon.Where(u => u.ID_xet_detai == -1).ToList();
            return PartialView(ls);
        }

        public ActionResult ThongTinBoXungDeTai(int id_detai = -1)
        {
            var dt = dbc.khDeTais.FirstOrDefault(u => u.ID_de_tai == id_detai);
            var dtct = new khDeTaiChiTiet();
            if (dt != null)
            {
                dtct.ID_de_tai = dt.ID_de_tai;
                dtct.Ngay_dang_ky = dt.Tu_ngay != null ? dt.Tu_ngay : DateTime.Now;
            }

            return View(dtct);
        }


    }
}