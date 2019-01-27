using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers
{
    public class ChucVuHoiDongController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: ChucVuHoiDong
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData(int page =1)
        {
            int take = 20;
            var skip = (page - 1) * take;
            var lsChucVu = dbc.dmChucVuHoiDongs.Skip(skip).Take(take).ToList();
            return PartialView(lsChucVu);
        }
        public ActionResult RenderPaginations()
        {
            var count = dbc.dmChucVuHoiDongs.Count();
            var page = count % 20 == 0 ? count / 20 : count / 20 + 1;
            return PartialView("/Views/Shared/PaginationsPartial.cshtml", page);
        }

        public ActionResult SelectChucVuHoiDong()
        {
            var lsChucVu = dbc.dmChucVuHoiDongs.ToList();
            return PartialView(lsChucVu);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}