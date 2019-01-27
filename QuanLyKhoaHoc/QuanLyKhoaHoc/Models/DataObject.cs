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

    public class LoaiHoiDong
    {

        public int ID_loai_hoi_dong { get; set; }
        public string Ma_loai_hoi_dong { get; set; }
        public string Ten_loai_hoi_dong { get; set; }

        public int selectIdLoai { get; set; }
        public LoaiHoiDong() { }
    }

    public class ChiTietHoiDong
    {
        public int ID_hd_chi_tiet { get; set; }
        public int ID_hd { get; set; }
        public string Ten_hd { get; set; }
        public int ID_cb { get; set; }
        public string Ma_cb { get; set; }
        public string Ho_ten { get; set; }
        public string SDT { get; set; }
        public string Chuc_vu_dv { get; set; }
        public string Ten_Don_Vi { get; set; }
        public int ID_chuc_vu_hd { get; set; }
        public string Chuc_vu_hd { get; set; }
        public string Ghi_chu { get; set; }
        public ChiTietHoiDong() { }
    }

    public class DeTai
    {
        public int ID_de_tai { get; set; }
        public string Ma_de_tai { get; set; }
        public string Ten_de_tai_vn { get; set; }
        public string Ten_de_tai_en { get; set; }
        public int ID_cb { get; set; }
        public string Ten_Can_Bo { get; set; }
        public int ID_thu_ky { get; set; }
        public string Ten_Thu_Ky { get; set; }
        public DateTime? Tu_Ngay { get; set; }
        public DateTime? Den_Ngay { get; set; }
        public DateTime? Ngay_Xet { get; set; }
        public decimal? Nguon_von { get; set; }
        public int Id_Don_Vi { get; set; }
        public string Ten_Don_Vi { get; set; }
        public string Chuc_Vu { get; set; }
    }

    public class DeTai_CanBo
    {
        public int ID_de_tai { get; set; }
        public int ID_cb { get; set; }
        public string Ma_cb { get; set; }
        public string Ten_Can_Bo { get; set; }
        public DateTime? Tu_Ngay { get; set; }
        public DateTime? Den_Ngay { get; set; }
        public string Nhiem_Vu { get; set; }
        public string Mo_Ta { get; set; }
    }

    public class DeTai_TuyenChon
    {
        public int ID_xet_detai { get; set; }
        public int ID_de_tai { get; set; }
        public string Ma_de_tai { get; set; }
        public string Ten_de_tai_vn { get; set; }
        public string Ten_de_tai_en { get; set; }
        public int ID_cb { get; set; }
        public string Ten_Can_Bo { get; set; }
        public int ID_thu_ky { get; set; }
        public string Ten_Thu_Ky { get; set; }
        public DateTime? Tu_Ngay { get; set; }
        public DateTime? Den_Ngay { get; set; }
        public string Ngay_Xet { get; set; }
        public decimal? Nguon_von { get; set; }
        public int Id_Don_Vi { get; set; }
        public string Ten_Don_Vi { get; set; }
        public string Chuc_Vu { get; set; }

    }
}