using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers
{
    public class ChucDanhController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: ChucDanh
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectChucDanh()
        {
            var lsChucDanh = dbc.dmChucDanhs.ToList();
            return PartialView(lsChucDanh);
        }
    }
}