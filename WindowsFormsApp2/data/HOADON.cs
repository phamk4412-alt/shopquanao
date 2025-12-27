namespace WindowsFormsApp2.data
{
    using System;
    using System.Collections.Generic;

    public partial class HOADON
    {
        public HOADON()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            SANPHAMDATHANGs = new HashSet<SANPHAMDATHANG>();
        }

        public int ma_hoadon { get; set; }

        public int? ma_khachhang { get; set; }

        public int ma_nhanvien { get; set; }

        public DateTime? ngay_dat_hang { get; set; }

        public string dia_chi_giao_hang { get; set; }

        public string sdt_giao_hang { get; set; }

        public decimal tong_tien { get; set; }

        public decimal giam_gia { get; set; }

        public decimal phi_van_chuyen { get; set; }

        public decimal thanh_toan { get; set; }

        public string phuong_thuc_thanh_toan { get; set; }

        public string trang_thai { get; set; }

        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual ICollection<SANPHAMDATHANG> SANPHAMDATHANGs { get; set; }
    }
}
