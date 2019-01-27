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

        public ActionResult LoadData(int idDonVi = 1)
        {
            var lsCanBo = (from cb in dbc.khCanBos
                           where cb.Active.Value == true && cb.ID_dv == idDonVi
                           select new kh_HoSoCanBo
                           {
                               ID_cb = cb.ID_cb,
                               Ma_cb = cb.Ma_cb,
                               Ho_ten = cb.Ho_ten,
                               Link_Anh = cb.Link_Anh,
                               Ngay_sinh = cb.Ngay_sinh,
                               Noi_sinh = cb.Noi_sinh != null ? cb.Noi_sinh : "Cập nhật",
                               Gioi_tinh = dbc.dmGioiTinhs.FirstOrDefault(u => u.ID_gioi_tinh == cb.ID_gioi_tinh) != null ? dbc.dmGioiTinhs.FirstOrDefault(u => u.ID_gioi_tinh == cb.ID_gioi_tinh).Gioi_tinh : "Khác",
                               ID_gioi_tinh = cb.ID_gioi_tinh,
                               Don_vi = dbc.dmDonViQuanLies.FirstOrDefault(u => u.ID_dv == cb.ID_dv) != null ? dbc.dmDonViQuanLies.FirstOrDefault(u => u.ID_dv == cb.ID_dv).Ten_dv : "Khác",
                               Hoc_vi = dbc.dmHocVis.FirstOrDefault(u => u.id_hoc_vi == cb.ID_hoc_vi) != null ? dbc.dmHocVis.FirstOrDefault(u => u.id_hoc_vi == cb.ID_hoc_vi).Hoc_vi : "Khác",
                               Hoc_ham = dbc.dmHocHams.FirstOrDefault(u => u.id_hoc_ham == cb.ID_hoc_ham) != null ? dbc.dmHocHams.FirstOrDefault(u => u.id_hoc_ham == cb.ID_hoc_ham).Hoc_ham : "Khác",
                               NamDuocPhongHocHam = cb.NamDuocPhongHocHam,
                               Chuc_vu = dbc.dmChucVuDonVis.FirstOrDefault(u => u.ID_chuc_vu == cb.ID_chuc_vu) != null ? dbc.dmChucVuDonVis.FirstOrDefault(u => u.ID_chuc_vu == cb.ID_chuc_vu).Chuc_vu : "Khác",
                               Chuc_danh = dbc.dmChucDanhs.FirstOrDefault(u => u.ID_chuc_danh == cb.ID_chuc_danh) != null ? dbc.dmChucDanhs.FirstOrDefault(u => u.ID_chuc_danh == cb.ID_chuc_danh).Chuc_danh : "Khác",

                           }).ToList();

            return PartialView(lsCanBo);
        }

        public ActionResult SelectCanBo(string ma_cb = "", int page = 1)
        {
            // cái này dùng join nhé.
            // sao nó thành cái // nhỉ a
            
            //var lsCanBo = (from cb in dbc.khCanBos
            //               where cb.Active.Value == true && (cb.Ma_cb.Contains(ma_cb) || cb.Ho_ten.Contains(ma_cb))
            //               select new kh_HoSoCanBo
            //               {
            //                   ID_cb = cb.ID_cb,
            //                   Ma_cb = cb.Ma_cb,
            //                   Ho_ten = cb.Ho_ten,
            //                   Link_Anh = cb.Link_Anh,
            //                   Ngay_sinh = cb.Ngay_sinh,
            //                   Noi_sinh = !string.IsNullOrEmpty(cb.Noi_sinh)  ? cb.Noi_sinh : "Cập nhật",
            //                   Gioi_tinh = dbc.dmGioiTinhs.FirstOrDefault(u => u.ID_gioi_tinh == cb.ID_gioi_tinh) != null ? dbc.dmGioiTinhs.FirstOrDefault(u => u.ID_gioi_tinh == cb.ID_gioi_tinh).Gioi_tinh : "Khác",
            //                   ID_gioi_tinh = cb.ID_gioi_tinh,
            //                   Don_vi = dbc.dmDonViQuanLies.FirstOrDefault(u => u.ID_dv == cb.ID_dv) != null ? dbc.dmDonViQuanLies.FirstOrDefault(u => u.ID_dv == cb.ID_dv).Ten_dv : "Khác",
            //                   Hoc_vi = dbc.dmHocVis.FirstOrDefault(u => u.id_hoc_vi == cb.ID_hoc_vi) != null ? dbc.dmHocVis.FirstOrDefault(u => u.id_hoc_vi == cb.ID_hoc_vi).Hoc_vi : "Khác",
            //                   Hoc_ham = dbc.dmHocHams.FirstOrDefault(u => u.id_hoc_ham == cb.ID_hoc_ham) != null ? dbc.dmHocHams.FirstOrDefault(u => u.id_hoc_ham == cb.ID_hoc_ham).Hoc_ham : "Khác",
            //                   NamDuocPhongHocHam = cb.NamDuocPhongHocHam,
            //                   Chuc_vu = dbc.dmChucVuDonVis.FirstOrDefault(u => u.ID_chuc_vu == cb.ID_chuc_vu) != null ? dbc.dmChucVuDonVis.FirstOrDefault(u => u.ID_chuc_vu == cb.ID_chuc_vu).Chuc_vu : "Khác",
            //                   Chuc_danh = dbc.dmChucDanhs.FirstOrDefault(u => u.ID_chuc_danh == cb.ID_chuc_danh) != null ? dbc.dmChucDanhs.FirstOrDefault(u => u.ID_chuc_danh == cb.ID_chuc_danh).Chuc_danh : "Khác",

            //               }).ToList();
            // tu lam tiep di
            // cai nay phai dung left join anh ak
            //http://stackoverflow.com/questions/3404975/left-outer-join-in-linq
            // nos baos loi 
            //sao nó lại không có gì nhỉ a

            int take = 20;
            int skip = (page - 1) * take;
            ma_cb = ma_cb.Replace('_' ,' ');
           var lsCanBo = (from cb in dbc.khCanBos.Where(cb => cb.Active.Value == true && (cb.Ma_cb.Contains(ma_cb) || cb.Ho_ten.Contains(ma_cb))).Skip(skip).Take(take).ToList()
                           join gt in dbc.dmGioiTinhs.ToList() on cb.ID_gioi_tinh equals gt.ID_gioi_tinh into lgt
                           from gt in lgt.DefaultIfEmpty()
                           join dv in dbc.dmDonViQuanLies.ToList() on cb.ID_dv equals dv.ID_dv into ldv
                           from dv in ldv.DefaultIfEmpty()
                           join hv in dbc.dmHocVis.ToList() on cb.ID_hoc_vi equals hv.id_hoc_vi into lhv
                           from hv in lhv.DefaultIfEmpty()
                           join hh in dbc.dmHocHams.ToList() on cb.ID_hoc_ham equals hh.id_hoc_ham into lhh
                           from hh in lhh.DefaultIfEmpty()
                           join cv in dbc.dmChucVuDonVis.ToList() on cb.ID_chuc_vu equals cv.ID_chuc_vu into lcv
                           from cv in lcv.DefaultIfEmpty()
                           join cd in dbc.dmChucDanhs.ToList() on cb.ID_chuc_danh equals cd.ID_chuc_danh into lcd
                           from cd in lcd.DefaultIfEmpty()

                           select new kh_HoSoCanBo
                           {
                               ID_cb = cb.ID_cb,
                               Ma_cb = cb.Ma_cb,
                               Ho_ten = cb.Ho_ten,
                               Link_Anh = cb.Link_Anh,
                               Ngay_sinh = cb.Ngay_sinh,
                               Noi_sinh = !string.IsNullOrEmpty(cb.Noi_sinh) ? cb.Noi_sinh : "Cập nhật",
                               Gioi_tinh = !string.IsNullOrEmpty(gt.Gioi_tinh) ? gt.Gioi_tinh : "Khác",
                               ID_gioi_tinh = cb.ID_gioi_tinh,
                               Don_vi =(dv!=null && !string.IsNullOrEmpty(dv.Ten_dv)) ? dv.Ten_dv : "Khác",
                               Hoc_vi = (hv !=null && !string.IsNullOrEmpty(hv.Hoc_vi)) ? hv.Hoc_vi : "Khác",
                               Hoc_ham = ( hh !=null && !string.IsNullOrEmpty(hh.Hoc_ham)) ? hh.Hoc_ham : "Khác",
                               NamDuocPhongHocHam = cb.NamDuocPhongHocHam,
                               Chuc_vu = (cv == null || string.IsNullOrEmpty(cv.Chuc_vu)) ? "Khác" : cv.Chuc_vu,
                               Chuc_danh =(cd!=null && !string.IsNullOrEmpty(cd.Chuc_danh)) ? cd.Chuc_danh : "Khác",
                               Di_dong= cb.Di_dong,
                               Email = cb.Email,

                           }).ToList();
           
            return PartialView(lsCanBo);
        }

        public ActionResult RenderPaginations(string ma_cb = "")
        {
            var count = dbc.khCanBos.Where(u => u.Ma_cb.Contains(ma_cb) || u.Ho_ten.Contains(ma_cb)).Count();
            var page = count % 20 == 0 ? count / 20 : count / 20 + 1;
            return PartialView("/Views/Shared/PaginationsPartial.cshtml", page);
        }


        public ActionResult Create(int id_donvi = 1)
        {
            return View();
        }

        public ActionResult Profile(int id_CanBo = 3251)
        {
            khCanBo kh = dbc.khCanBos.FirstOrDefault(u => u.ID_cb == id_CanBo);
            return View(kh);
        }

        public void Save(khCanBo canbo)
        {
            try
            {
                if (canbo.ID_cb == -1)
                {
                    canbo.Active = true;
                    dbc.khCanBos.InsertOnSubmit(canbo);
                    dbc.SubmitChanges();
                }
                else
                {
                    var cb = dbc.khCanBos.FirstOrDefault(u => u.ID_cb == canbo.ID_cb);
                    if (cb != null)
                    {
                        cb.Ma_cb = canbo.Ma_cb;
                        cb.Ho_ten = canbo.Ho_ten;
                        cb.Link_Anh = canbo.Link_Anh;
                        cb.Ngay_sinh = canbo.Ngay_sinh;
                        cb.Noi_sinh = canbo.Noi_sinh;
                        cb.ID_gioi_tinh = canbo.ID_gioi_tinh;
                        cb.ID_tt_hn = canbo.ID_tt_hn;
                        cb.ID_dan_toc = canbo.ID_dan_toc;
                        cb.Ton_giao = canbo.Ton_giao;
                        cb.Dien_thoai_NR = canbo.Dien_thoai_NR;
                        cb.Di_dong = canbo.Di_dong;
                        cb.Email = canbo.Email;
                        cb.Dia_chi_tt = canbo.Dia_chi_tt;
                        cb.Dia_chi_qq = canbo.Dia_chi_qq;
                        cb.Noi_o_hien_nay = canbo.Noi_o_hien_nay;
                        cb.So_CMND = canbo.So_CMND;
                        cb.Ngay_cap = canbo.Ngay_cap;
                        cb.Noi_cap = canbo.Noi_cap;
                        cb.Doan = canbo.Doan;
                        cb.Ngay_vao_doan = canbo.Ngay_vao_doan;
                        cb.Dang = canbo.Dang;
                        cb.Ngay_vao_dang = canbo.Ngay_vao_dang;
                        cb.ID_dv = canbo.ID_dv;
                        cb.ID_hoc_vi = canbo.ID_hoc_vi;
                        cb.ID_hoc_ham = canbo.ID_hoc_ham;
                        cb.NamDuocPhongHocHam = canbo.NamDuocPhongHocHam;
                        cb.NamDatHocVi = canbo.NamDatHocVi;
                        cb.ID_chuc_vu = canbo.ID_chuc_vu;
                        cb.ID_chuyen_mon = canbo.ID_chuyen_mon;
                        cb.Dien_thoai_CQ = canbo.Dien_thoai_CQ;
                        cb.Fax = canbo.Fax;
                        cb.Trinh_do_nn = canbo.Trinh_do_nn;
                        cb.ID_chuc_danh = canbo.ID_chuc_danh;
                        cb.LinhVucNghienCuu = canbo.LinhVucNghienCuu;
                        cb.ID_chuyen_nganh = canbo.ID_chuyen_nganh;
                        cb.LaSinhVien = canbo.LaSinhVien;
                        cb.TenLop = canbo.TenLop;
                        dbc.SubmitChanges();
                    }

                }
            }
            catch
            {

            }
        }

        public JsonResult Upload()
        {
            string strfilename = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                //Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string date = DateTime.Now.ToString("ddMMyyyhhmm");
                fileName = date + fileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("/img/Avatars/") + fileName); //File will be saved in application root
                strfilename = fileName;
            }
            return Json(strfilename);
        }
    }
}