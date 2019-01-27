using QuanLyKhoaHoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKhoaHoc.Controllers
{
    public class NganhController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: Nganh
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderPartial()
        {
            var listNganh = dbc.dmNganhDaoTaos.ToList();
            return PartialView(listNganh);
        }
    }
}