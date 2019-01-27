using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKhoaHoc.Controllers.DeTaiChuyenDe
{
    public class ThamDinhController : Controller
    {
        // GET: ThamDinh
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NoiDungThamDinh()
        {
            return View();
        }
    }
}