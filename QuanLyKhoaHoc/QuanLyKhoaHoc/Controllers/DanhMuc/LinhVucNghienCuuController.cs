﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers
{
    public class LinhVucNghienCuuController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: LinhVucNghienCuu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadData(int page = 1)
        {
            int take = 20; // lấy 2 phần tử
            var skip = (page - 1) * take;
            var lsLinhVucNghienCuu = dbc.dmLinhVucNghienCuus.Skip(skip).Take(take).ToList();
            return PartialView(lsLinhVucNghienCuu);
        }

        public ActionResult RenderPaginations()
        {
            var count = dbc.dmLinhVucNghienCuus.Count();
            var page = count % 20 == 0 ? count / 20 : count / 20 + 1;
            return PartialView("/Views/Shared/PaginationsPartial.cshtml", page);
        }

        public ActionResult SelectLinhVucNghienCuu()
        {
            var lsLoaiHinh = dbc.dmLinhVucNghienCuus.ToList();
            return PartialView(lsLoaiHinh);
        }
    }
}