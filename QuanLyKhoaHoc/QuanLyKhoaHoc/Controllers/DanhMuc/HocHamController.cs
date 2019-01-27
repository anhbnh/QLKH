using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers
{
    public class HocHamController : Controller
    {

        QLKHDataContext dbc = new QLKHDataContext();
        // GET: HocHam
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectHocHam()
        {
            var lsHocHam = dbc.dmHocHams.ToList();
            return PartialView(lsHocHam);
        }

        
    }
}