using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers.DeTaiChuyenDe
{
    public class CapHoiDongController : Controller
    {

        QLKHDataContext dbc = new QLKHDataContext();
        // GET: CapHoiDong
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectCapHoiDong()
        {
            var lsCapHoiDong = dbc.khCapHoiDongs.ToList();
            return PartialView(lsCapHoiDong);
        }
    }
}