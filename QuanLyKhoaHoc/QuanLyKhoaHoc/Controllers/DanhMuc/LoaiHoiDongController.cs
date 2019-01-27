using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers
{
    public class LoaiHoiDongController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: LoaiHoiDong
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData(int page = 1)
        {
            int take = 20; // lấy 2 phần tử
            var skip = (page - 1) * take;
            var lsLoaiHoiDong = dbc.dmLoaiHoiDongs.Skip(skip).Take(take).ToList();
            return PartialView(lsLoaiHoiDong);
        }

        public ActionResult RenderPaginations()
        {
            var count = dbc.dmLoaiHoiDongs.Count();
            var page = count % 20 == 0 ? count / 20 : count / 20 + 1;
            return PartialView("/Views/Shared/PaginationsPartial.cshtml", page);
        }

        public ActionResult SelectLoaiHoiDong()
        {
            var lsLoaiHoiDong = dbc.dmLoaiHoiDongs.ToList();
                                //select new LoaiHoiDong
                                //{
                                //    ID_loai_hoi_dong= tb.ID_loai_hoi_dong,
                                //    Ma_loai_hoi_dong=tb.Ma_loai_hoi_dong,
                                //    Ten_loai_hoi_dong=tb.Ten_loai_hoi_dong,
                                //    selectIdLoai =idHoiDong,
                                //};
            return PartialView(lsLoaiHoiDong);
        }

    }
}