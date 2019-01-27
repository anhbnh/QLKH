using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;


namespace QuanLyKhoaHoc.Controllers
{
    public class DanTocController : Controller
    {
 
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: DanToc
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectDanToc()
        {
            var lsDanToc = dbc.dmDanTocs.ToList();
            return PartialView(lsDanToc);
        }
    }
}