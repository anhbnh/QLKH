using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers.DeTaiChuyenDe
{
    public class ThangDiemController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: ThangDiem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThangDiemTheoNam()
        {

            var lsNam = dbc.khThangDiems.ToList();
            return PartialView(lsNam);
        }

        public ActionResult ThongTinThangDiem(int id_BD = 96)
        {
            var bangdiem = dbc.khThangDiems.FirstOrDefault(u => u.ID_bd == id_BD);
            return PartialView(bangdiem);
        }
        public ActionResult ThangDiemChiTiet(int id_BD = 96)
        {
            var ctBangDiem = dbc.khThangDiemChiTiets.Where(u => u.ID_bd == id_BD).ToList();
            return PartialView(ctBangDiem);
        }

        public ActionResult Id_ThangDiem()
        {
            dbc =new  QLKHDataContext();
            var ThangD = dbc.khThangDiems.OrderByDescending(u => u.ID_bd).FirstOrDefault();
            return PartialView(ThangD);
        }

        public void Save_ThangDiem(khThangDiem ThangDiem)
        {
            if (ThangDiem.ID_bd == -1)
            {
                dbc.khThangDiems.InsertOnSubmit(ThangDiem);
                dbc.SubmitChanges();
            }
            else
            {
                var td = dbc.khThangDiems.FirstOrDefault(u => u.ID_bd == ThangDiem.ID_bd);
                if (td != null)
                {
                    td.Nam = ThangDiem.Nam;
                    td.So = ThangDiem.So;
                    td.Diem_tran = ThangDiem.Diem_tran;
                    td.Ten_bd = ThangDiem.Ten_bd;
                    td.ID_loai_hoi_dong = ThangDiem.ID_loai_hoi_dong;
                    dbc.SubmitChanges();
                }
            }
        }

        public void Save_CTThangDiem(khThangDiemChiTiet CTThangDiem)
        {
            if (CTThangDiem.ID_tc_dg == -1)
            {
                dbc.khThangDiemChiTiets.InsertOnSubmit(CTThangDiem);
                dbc.SubmitChanges();
            }
            else
            {
                var td = dbc.khThangDiemChiTiets.FirstOrDefault(u => u.ID_tc_dg == CTThangDiem.ID_tc_dg);
                if (td != null)
                {
                    td.Tieu_chuan_danh_gia = CTThangDiem.Tieu_chuan_danh_gia;
                    td.Diem = CTThangDiem.Diem;
                    dbc.SubmitChanges();
                }
            }
        }
    }
}