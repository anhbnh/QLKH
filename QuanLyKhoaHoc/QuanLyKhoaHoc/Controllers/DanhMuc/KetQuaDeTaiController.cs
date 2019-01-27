using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers
{
    public class KetQuaDeTaiController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: KetQuaDeTai
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadData(int page = 1)
        {
            int take = 20; // lấy 2 phần tử
            var skip = (page - 1) * take;
            var lsLinhVucDeTai = dbc.dmLinhVucDeTais.Skip(skip).Take(take).ToList();
            return PartialView(lsLinhVucDeTai);
        }
        public ActionResult RenderPaginations()
        {
            var count = dbc.dmLinhVucDeTais.Count();
            var page = count % 20 == 0 ? count / 20 : count / 20 + 1;
            return PartialView("/Views/Shared/PaginationsPartial.cshtml", page);
        }
    }
}