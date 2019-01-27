using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers.DeTaiChuyenDe
{
    public class DeTaiController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: DeTai
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData(int nam = 0, bool detai = true, int page = 1)
        {
            nam = nam == 0 ? DateTime.Now.Year : nam;
            //int take = 20;
            // int skip = take * (page - 1);
            var lsChuyenDe = from cd in dbc.khDeTais
                             join cb in dbc.khCanBos on cd.ID_cb equals cb.ID_cb into pv
                             from cb in pv.DefaultIfEmpty()
                             join tk in dbc.khCanBos on cd.ID_thu_ky equals tk.ID_cb into pK
                             from tk in pK.DefaultIfEmpty()
                             join dv in dbc.dmCoQuanChuTris on cd.ID_cq_ct equals dv.ID_cq_ct into pc
                             from dv in pc.DefaultIfEmpty()
                             where cd.Nam == nam && cd.De_tai == detai
                             select new DeTai
                             {
                                 ID_de_tai = cd.ID_de_tai,
                                 Ma_de_tai = cd.Ma_de_tai,
                                 Ten_de_tai_vn = cd.Ten_de_tai_vn,
                                 Ten_de_tai_en = cd.Ten_de_tai_en,
                                 ID_cb = cd.ID_cb,
                                 Ten_Can_Bo = cb.Ho_ten,
                                 ID_thu_ky = cd.ID_thu_ky,
                                 Ten_Thu_Ky = tk.Ho_ten,
                                 Id_Don_Vi = cd.ID_cq_ct.Value,
                                 Ten_Don_Vi = dv.Ten_cq,
                                 Tu_Ngay = cd.Tu_ngay,
                                 Den_Ngay = cd.Den_ngay,
                                 Nguon_von = cd.Kinh_phi_dk,
                             };
            var lst = lsChuyenDe.ToList();
            return PartialView(lst);
        }

        public ActionResult RenderPaginations(int nam = 0, bool detai = true)
        {
            nam = nam == 0 ? DateTime.Now.Year : nam;
            var count = dbc.khDeTais.Where(u => u.Nam == nam && u.De_tai == detai).Count();
            var page = count % 20 == 0 ? count / 20 : count / 20 + 1;
            return PartialView("/Views/Shared/PaginationsPartial.cshtml", page);
        }

        public ActionResult Create()
        {
            return View();
        }

        public void Save(khDeTai detai)
        {
            if (detai.ID_de_tai == -1)
            {
                dbc.khDeTais.InsertOnSubmit(detai);
                dbc.SubmitChanges();
            }
            else
            {
                var dt = dbc.khDeTais.FirstOrDefault(u => u.ID_de_tai == detai.ID_de_tai);
                if (dt != null)
                {
                    dt.Ma_de_tai = detai.Ma_de_tai;
                    dt.Ten_de_tai_vn = detai.Ten_de_tai_vn;
                    dt.Ten_de_tai_en = detai.Ten_de_tai_en;
                    dt.ID_cb = detai.ID_cb;
                    dt.ID_thu_ky = detai.ID_thu_ky;
                    dt.ID_loai_de_tai = detai.ID_loai_de_tai;
                    dt.ID_loai_hinh = detai.ID_loai_hinh;
                    dt.ID_linh_vuc = detai.ID_linh_vuc;
                    dt.ID_cq_ct = detai.ID_cq_ct;
                    dt.ID_cq_cq = detai.ID_cq_cq;
                    dt.ID_cap_ql = detai.ID_cap_ql;
                    dt.Muc_tieu_de_tai = detai.Muc_tieu_de_tai;
                    dt.Noi_dung = detai.Noi_dung;
                    dt.Du_kien_dt = detai.Du_kien_dt;
                    dt.Tu_ngay = detai.Tu_ngay;
                    dt.Den_ngay = detai.Den_ngay;
                    dt.Ngan_sach_nn = detai.Ngan_sach_nn;
                    dt.Nguon_khac = detai.Nguon_khac;
                    dt.Xet_duyet = detai.Xet_duyet;
                    dt.ID_Tinh_trang = detai.ID_Tinh_trang;
                    dt.De_tai = detai.De_tai;
                    dt.Nam = detai.Nam;
                    dt.Kinh_phi_dk = detai.Kinh_phi_dk;
                    dt.ID_cq_ph = detai.ID_cq_ph;
                    dt.ID_de_tai_cha = detai.ID_de_tai_cha;
                    dt.UserID = detai.UserID;
                    dt.De_tai_mat = detai.De_tai_mat;
                    dt.ID_khoa = detai.ID_khoa;
                    dt.Trang_thai = detai.Trang_thai;
                    dt.HocTrinh = detai.HocTrinh;
                    dt.ID_Cb_HuongDan = detai.ID_Cb_HuongDan;
                    dt.DeTaiKeHoach = detai.DeTaiKeHoach;
                    dbc.SubmitChanges();
                }
            }
        }

        public void Save_DT_CB(khDeTaiCanBoThamGia DeTai_CanBo)
        {
            var dt = dbc.khDeTaiCanBoThamGias.FirstOrDefault(u => u.ID_cb == DeTai_CanBo.ID_cb && u.ID_de_tai == DeTai_CanBo.ID_de_tai);
            if (dt != null)
            {
                dt.Nhiem_vu = DeTai_CanBo.Nhiem_vu;
                dt.Mo_ta = DeTai_CanBo.Mo_ta;
                dt.Tu_ngay = DeTai_CanBo.Tu_ngay;
                dt.Den_ngay = DeTai_CanBo.Den_ngay;
                dbc.SubmitChanges();
            }
            else
            {
                dbc.khDeTaiCanBoThamGias.InsertOnSubmit(DeTai_CanBo);
                dbc.SubmitChanges();
            }
        }

        public ActionResult NewDeTai()
        {
            dbc = new QLKHDataContext();
            var dt = dbc.khDeTais.OrderByDescending(u => u.ID_de_tai).FirstOrDefault();
            return PartialView(dt);
        }

        public ActionResult DanhSachCanBoThamGia(int id_DeTai = -1)
        {
            var lsCB = from dt in dbc.khDeTaiCanBoThamGias
                       join cb in dbc.khCanBos on dt.ID_cb equals cb.ID_cb into fb
                       from cb in fb.DefaultIfEmpty()
                       where dt.ID_de_tai == id_DeTai
                       select new DeTai_CanBo
                       {
                           ID_cb = dt.ID_cb,
                           Ma_cb = cb.Ma_cb,
                           Ten_Can_Bo = cb.Ho_ten,
                           ID_de_tai = dt.ID_de_tai,
                           Tu_Ngay = dt.Tu_ngay,
                           Den_Ngay = dt.Den_ngay,
                           Nhiem_Vu = dt.Nhiem_vu,
                           Mo_Ta = dt.Mo_ta,
                       };
            return PartialView(lsCB.ToList());
        }
    }
}