using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;


namespace QuanLyKhoaHoc.Controllers
{
    public class HocViController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: HocVi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectHocVi()
        {
            var lsHocVi = dbc.dmHocVis.ToList();
            return PartialView(lsHocVi);
        }
    }
}