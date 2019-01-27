using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers
{
    public class YeuCauKhoaHocController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: YeuCauKhoaHoc
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData(int page = 1)
        {
            int take = 20; // lấy 2 phần tử
            var skip = (page - 1) * take;
            var lsYeuCauKhoaHoc = dbc.dmYeuCauKhoaHocs.Skip(skip).Take(take).ToList();
            return PartialView(lsYeuCauKhoaHoc);
        }

        public ActionResult RenderPaginations()
        {
            var count = dbc.dmYeuCauKhoaHocs.Count();
            var page = count % 20 == 0 ? count / 20 : count / 20 + 1;
            return PartialView("/Views/Shared/PaginationsPartial.cshtml", page);
        }
    }
}