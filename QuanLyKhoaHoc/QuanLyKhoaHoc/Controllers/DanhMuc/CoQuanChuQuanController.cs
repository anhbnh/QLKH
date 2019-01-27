using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers
{
    public class CoQuanChuQuanController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: CoQuanChuQuan
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadData(int page = 1)
        {
            int take = 20; // lấy 2 phần tử
            var skip = (page - 1) * take;
            var lsCoQuanChuQuan = dbc.dmCoQuanChuQuans.Skip(skip).Take(take).ToList();
            return PartialView(lsCoQuanChuQuan);
        }

        public ActionResult RenderPaginations()
        {
            var count = dbc.dmCoQuanChuQuans.Count();
            var page = count % 20 == 0 ? count / 20 : count / 20 + 1;
            return PartialView("/Views/Shared/PaginationsPartial.cshtml", page);
        }

        public ActionResult SelectCoQuanChuQuan()
        {
            var lsCoQuan = dbc.dmCoQuanChuQuans.ToList();
            return PartialView(lsCoQuan);
        }
    }
}