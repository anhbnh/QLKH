using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace QuanLyKhoaHoc.Models
{
    public class DataObject
    {


    }

    public class ChuyenNganhModel
    {
        public int ID_chuyen_nganh { get; set; }
        public string Ma_chuyen_nganh { get; set; }
        public string Chuyen_nganh { get; set; }
        public int ID_nganh { get; set; }
        public string Ten_nganh { get; set; }
        public string Chuyen_nganh_en { get; set; }
        public int? Ky_thuat { get; set; }
    }

    public class PhanTrang
    {
        public int page { get; set; }

        public string strUrl { get; set; }

        public PhanTrang() { }
    }

    public class kh_HoSoCanBo
    {
        public int ID_cb { get; set; }
        public string Ma_cb { get; set; }
        public string Ho_ten { get; set; }
        public string Link_Anh { get; set; }
        public DateTime? Ngay_sinh { get; set; }
        public string Noi_sinh { get; set; }
        public int? ID_gioi_tinh { get; set; }
        public string Gioi_tinh { get; set; }
        public int? ID_tt_hn { get; set; }
        public string TinhTrang_Honnhan { get; set; }
        public int? ID_dan_toc { get; set; }
        public string Dan_toc { get; set; }
        public string Ton_giao { get; set; }
        public string Dien_thoai_NR { get; set; }
        public string Di_dong { get; set; }
        public string Email { get; set; }
        public string Dia_chi_tt { get; set; }
        public string Dia_chi_qq { get; set; }
        public string Noi_o_hien_nay { get; set; }
        public string So_CMND { get; set; }
        public DateTime? Ngay_cap { get; set; }
        public string Noi_cap { get; set; }
        public bool? Doan { get; set; }
        public DateTime? Ngay_vao_doan { get; set; }
        public bool? Dang { get; set; }
        public DateTime? Ngay_vao_dang { get; set; }
        public int? ID_dv { get; set; }
        public string Don_vi { get; set; }
        public bool? Active { get; set; }
        public int? ID_hoc_vi { get; set; }
        public string Hoc_vi { get; set; }
        public int? ID_hoc_ham { get; set; }
        public string Hoc_ham { get; set; }
        public string NamDuocPhongHocHam { get; set; }
        public string NamDatHocVi { get; set; }
        public int? ID_chuc_vu { get; set; }
        public string Chuc_vu { get; set; }
        public int? ID_chuyen_mon { get; set; }
        public string Chuyen_mon { get; set; }
        public string Dien_thoai_CQ { get; set; }
        public string Fax { get; set; }
        public string Trinh_do_nn { get; set; }
        public string Lop { get; set; }
        public int? ID_chuc_danh { get; set; }
        public string Chuc_danh { get; set; }
        public string DienThoaiCoQuan { get; set; }
        public string LinhVucNghienCuu { get; set; }
        public int? ID_chuyen_nganh { get; set; }
        public string Chuyen_nganh { get; set; }
        public bool? LaSinhVien { get; set; }
        public string TenLop { get; set; }


        public kh_HoSoCanBo() { }
    }

}