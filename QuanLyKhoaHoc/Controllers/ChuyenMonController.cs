using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers
{
    public class ChuyenMonController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: ChuyenMon
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData(int page = 1)
        {
            int take = 2; // lấy 2 phần tử
            var skip = (page - 1) * take;
            var lsChuyenMon = dbc.dmChuyenMons.Skip(skip).Take(take).ToList();
            return PartialView(lsChuyenMon);
        }

        public ActionResult RenderPaginations()
        {
            var count = dbc.dmChuyenMons.Count();
            var page = count % 2 == 0 ? count / 2 : count / 2 + 1;
            return PartialView("/Views/Shared/PaginationsPartial.cshtml", page);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}