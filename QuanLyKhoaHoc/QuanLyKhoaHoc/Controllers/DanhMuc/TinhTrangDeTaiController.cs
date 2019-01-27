using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers
{
    public class TinhTrangDeTaiController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: TinhTrangDeTai
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData(int page = 1)
        {
            int take = 20; // lấy 2 phần tử
            var skip = (page - 1) * take;
            var lsTinhTrangDeTai = dbc.dmTinhTrangDeTais.Skip(skip).Take(take).ToList();
            return PartialView(lsTinhTrangDeTai);
        }

        public ActionResult RenderPaginations()
        {
            var count = dbc.dmTinhTrangDeTais.Count();
            var page = count % 20 == 0 ? count / 20 : count / 20 + 1;
            return PartialView("/Views/Shared/PaginationsPartial.cshtml", page);
        }

        public ActionResult SelectTinhTrangDeTai()
        {
            var lsTinhTrang = dbc.dmTinhTrangDeTais.ToList();
            return PartialView(lsTinhTrang);
        }
    }
}