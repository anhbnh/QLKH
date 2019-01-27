using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoaHoc.Models;

namespace QuanLyKhoaHoc.Controllers
{
    public class KhoaController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData(int page = 1)
        {
            int skip = (page - 1) * 20;
            int take = 20;
            var lsKhoa = dbc.dmKhoas.Skip(skip).Take(take).ToList();
            return PartialView(lsKhoa);
        }

        public ActionResult Create()
        {
            return View();
        }

        public void Save(dmKhoa khoa)
        {
            try
            {
                if (khoa.ID_khoa == -1)
                {
                    dbc.dmKhoas.InsertOnSubmit(khoa);
                    dbc.SubmitChanges();
                }
                else
                {
                    var dmk = dbc.dmKhoas.FirstOrDefault(u => u.ID_khoa == khoa.ID_khoa);
                    if (dmk != null)
                    {
                        dmk.Ma_khoa = khoa.Ma_khoa;
                        dmk.Ten_khoa = khoa.Ten_khoa;
                        dmk.Ten_khoa_en = khoa.Ten_khoa_en;
                        dbc.SubmitChanges();
                    }
                }
            }
            catch
            {
            }
        }

        public ActionResult RenderPaginations()
        {
            var count = dbc.dmKhoas.Count();
            var page = count % 20 == 0 ? count / 20 : count / 20 + 1;

            return PartialView("/Views/Shared/PaginationsPartial.cshtml", page);
        }

        public void Delete(int ID_khoa)
        {
            try
            {

                var dmk = dbc.dmKhoas.FirstOrDefault(u => u.ID_khoa == ID_khoa);
                if (dmk != null)
                {
                    dbc.dmKhoas.DeleteOnSubmit(dmk);
                    dbc.SubmitChanges();
                }
            }
            catch
            {
            }
        }

        public ActionResult SelectKhoa()
        {
            var lsKhoa = dbc.dmKhoas.ToList();
            return PartialView(lsKhoa);
        }
    }


}