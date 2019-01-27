using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers.HoSoCanBo
{
    public class CanBoController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: CanBo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData(int idDonVi = 80)
        {
            var lsCanBo = (from cb in dbc.khCanBos
                           //join gt in dbc.dmGioiTinhs on cb.ID_gioi_tinh equals gt.ID_gioi_tinh
                           //join hn in dbc.dmTinhTrangHonNhans on cb.ID_tt_hn equals hn.ID_tt_hn
                           //join dt in dbc.dmDanTocs on cb.ID_dan_toc equals dt.ID_dan_toc
                           //join dv in dbc.dmDonViQuanLies on cb.ID_dv equals dv.ID_dv
                           //join hh in dbc.dmHocHams on cb.ID_hoc_ham equals hh.id_hoc_ham
                           //join hv in dbc.dmHocVis on cb.ID_hoc_vi equals hv.id_hoc_vi
                           //join cv in dbc.dmChucVuDonVis on cb.ID_chuc_vu equals cv.ID_chuc_vu
                           //join cd in dbc.dmChucDanhs on cb.ID_chuc_danh equals cd.ID_chuc_danh
                           //join cn in dbc.dmChuyenNganhDaoTaos on cb.ID_chuyen_nganh equals cn.ID_chuyen_nganh
                           //join cm in dbc.dmChuyenMons on cb.ID_chuyen_mon equals cm.ID_chuyen_mon
                           where cb.Active.Value == true && cb.ID_dv == idDonVi
                           select new kh_HoSoCanBo
                           {
                               ID_cb = cb.ID_cb,
                               Ma_cb = cb.Ma_cb,
                               Ho_ten = cb.Ho_ten,
                               Link_Anh = cb.Link_Anh,
                               Ngay_sinh = cb.Ngay_sinh,
                               Noi_sinh = cb.Noi_sinh,
                               // Gioi_tinh = gt.Gioi_tinh,
                               Gioi_tinh = dbc.dmGioiTinhs.FirstOrDefault(u => u.ID_gioi_tinh == cb.ID_gioi_tinh) != null ? dbc.dmGioiTinhs.FirstOrDefault(u => u.ID_gioi_tinh == cb.ID_gioi_tinh).Gioi_tinh : "Khác",
                               ID_gioi_tinh = cb.ID_gioi_tinh,
                               //   ID_tt_hn = cb.ID_tt_hn,
                               //    TinhTrang_Honnhan = hn.Tinh_trang,
                               //   ID_dan_toc = cb.ID_dan_toc,
                               //  Dan_toc = dt.Dan_toc,
                               //  Ton_giao = cb.Ton_giao,
                               //   Dien_thoai_NR = cb.Dien_thoai_NR,
                               //   Di_dong = cb.Di_dong,
                               //   Email = cb.Email,
                               //   Dia_chi_tt = cb.Dia_chi_tt,
                               //   Dia_chi_qq = cb.Dia_chi_qq,
                               //  Noi_o_hien_nay = cb.Noi_o_hien_nay,
                               //  So_CMND = cb.So_CMND,
                               //  Ngay_cap = cb.Ngay_cap,
                               //  Noi_cap = cb.Noi_cap,
                               //  Doan = cb.Doan,
                               //  Ngay_vao_doan = cb.Ngay_vao_doan,
                               //  Dang = cb.Dang,
                               //  Ngay_vao_dang = cb.Ngay_vao_dang,
                               //  ID_dv = cb.ID_dv,
                               Don_vi = dbc.dmDonViQuanLies.FirstOrDefault(u => u.ID_dv == cb.ID_dv) != null ? dbc.dmDonViQuanLies.FirstOrDefault(u => u.ID_dv == cb.ID_dv).Ten_dv : "Khác",
                              // Active = cb.Active,
                               //ID_hoc_vi = cb.ID_hoc_vi,
                               Hoc_vi = dbc.dmHocVis.FirstOrDefault(u => u.id_hoc_vi == cb.ID_hoc_vi) != null? dbc.dmHocVis.FirstOrDefault(u => u.id_hoc_vi == cb.ID_hoc_vi).Hoc_vi : "Khác",
                              // ID_hoc_ham = cb.ID_hoc_ham,
                               Hoc_ham = dbc.dmHocHams.FirstOrDefault(u => u.id_hoc_ham == cb.ID_hoc_ham) != null ? dbc.dmHocHams.FirstOrDefault(u => u.id_hoc_ham == cb.ID_hoc_ham).Hoc_ham : "Khác",
                               NamDuocPhongHocHam = cb.NamDuocPhongHocHam,
                            //   NamDatHocVi = cb.NamDatHocVi,
                             //  ID_chuc_vu = cb.ID_chuc_vu,
                               Chuc_vu = dbc.dmChucVuDonVis.FirstOrDefault(u => u.ID_chuc_vu == cb.ID_chuc_vu) != null ? dbc.dmChucVuDonVis.FirstOrDefault(u => u.ID_chuc_vu == cb.ID_chuc_vu).Chuc_vu : "Khác",
                              // ID_chuyen_mon = cb.ID_chuyen_mon,
                             //  Chuyen_mon = cm.Ten_Chuyen_mon,
                             //  Dien_thoai_CQ = cb.Dien_thoai_CQ,
                             //  Fax = cb.Fax,
                             //  Trinh_do_nn = cb.Trinh_do_nn,
                             //  Lop = cb.Lop,
                             //  ID_chuc_danh = cb.ID_chuc_danh,
                               Chuc_danh = dbc.dmChucDanhs.FirstOrDefault(u => u.ID_chuc_danh == cb.ID_chuc_danh) != null ? dbc.dmChucDanhs.FirstOrDefault(u => u.ID_chuc_danh == cb.ID_chuc_danh).Chuc_danh : "Khác",
                               //  DienThoaiCoQuan = cb.DienThoaiCoQuan,
                             //  LinhVucNghienCuu = cb.LinhVucNghienCuu,
                              // ID_chuyen_nganh = cb.ID_chuyen_nganh,
                             //  Chuyen_nganh = cn.Chuyen_nganh,
                             //  LaSinhVien = cb.LaSinhVien,
                              // TenLop = cb.TenLop,
                           }).ToList();

            return PartialView(lsCanBo);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Profile( int id_CanBo)
        {
            return View();
        }

    }
}