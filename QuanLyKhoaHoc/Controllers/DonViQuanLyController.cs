using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;


namespace QuanLyKhoaHoc.Controllers
{
    public class DonViQuanLyController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: DonViQuanLy
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DanhSachDonViQuanLy()
        {
            var lsDonVi = dbc.dmDonViQuanLies.ToList();
            return PartialView(lsDonVi);
        }

    }
}