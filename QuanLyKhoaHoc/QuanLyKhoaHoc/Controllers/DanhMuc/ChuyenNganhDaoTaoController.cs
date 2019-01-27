using QuanLyKhoaHoc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKhoaHoc.Controllers
{
    public class ChuyenNganhDaoTaoController : Controller
    {
        QLKHDataContext dbc = new QLKHDataContext();
        // GET: ChuyenNganhDaoTao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData(int page =1)
        {
            var lsChuyenNganhDaoTao = (from cn in dbc.dmChuyenNganhDaoTaos
                                       join n in dbc.dmNganhDaoTaos on cn.ID_nganh equals n.ID_nganh
                                       select new ChuyenNganhModel
                                       {
                                           ID_chuyen_nganh = cn.ID_chuyen_nganh,
                                           Ma_chuyen_nganh = cn.Ma_chuyen_nganh,
                                           ID_nganh = cn.ID_nganh,
                                           Ten_nganh = n.Ten_nganh,
                                           Chuyen_nganh = cn.Chuyen_nganh,
                                           Chuyen_nganh_en = cn.Chuyen_nganh_en,
                                           Ky_thuat = cn.Ky_thuat,
                                       }).ToList();
            int skip = (page - 1) * 20;
            int take = 20;
            var lst = lsChuyenNganhDaoTao.Skip(skip).Take(take).ToList();
            return PartialView(lst);
        }

        public ActionResult RenderPaginations()
        {
            var count =  dbc.dmChuyenNganhDaoTaos.Count();
            var page = count % 20 == 0 ? count / 20 : count / 20 + 1;
            return PartialView("/Views/Shared/PaginationsPartial.cshtml",page);
        }

        public ActionResult SelectChuyenNganh()
        {
            var lsChuyenNganh = dbc.dmChuyenNganhDaoTaos.ToList();
            return PartialView(lsChuyenNganh);
        }

        public ActionResult Create()
        {
            return View();
        }

        public void Create1(dmChuyenNganhDaoTao chuyennganhdaotao)
        {
            try
            {
                dbc.dmChuyenNganhDaoTaos.InsertOnSubmit(chuyennganhdaotao);
                dbc.SubmitChanges();
            }
            catch
            {
            }
        }


        public void Update(dmChuyenNganhDaoTao chuyennganhdaotao)
        {
            try
            {
                var cn = dbc.dmChuyenNganhDaoTaos.FirstOrDefault(u => u.ID_chuyen_nganh == chuyennganhdaotao.ID_chuyen_nganh);
                if (cn != null)
                {
                    cn.Ma_chuyen_nganh = chuyennganhdaotao.Ma_chuyen_nganh;
                    cn.Chuyen_nganh = chuyennganhdaotao.Chuyen_nganh;
                    cn.Chuyen_nganh_en = chuyennganhdaotao.Chuyen_nganh_en;
                    cn.ID_nganh = chuyennganhdaotao.ID_nganh;

                    dbc.SubmitChanges();
                }
            }
            catch
            {

            }
        }

        public void Delete(int ID_chuyen_nganh)
        {
            try
            {
                var cn = dbc.dmChuyenNganhDaoTaos.FirstOrDefault(u => u.ID_chuyen_nganh == ID_chuyen_nganh);
                if (cn != null)
                {
                    dbc.dmChuyenNganhDaoTaos.DeleteOnSubmit(cn);
                    dbc.SubmitChanges();
                }
            }
            catch
            {

            }
        }

    }
}