namespace WindowsFormsApp2.data
{
    using System;
    using System.Collections.Generic;

    public partial class SANPHAM
    {
        public SANPHAM()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            GIOHANG_TEMP = new HashSet<GIOHANG_TEMP>();
            SANPHAMDATHANGs = new HashSet<SANPHAMDATHANG>();
            TONKHOes = new HashSet<TONKHO>();
        }

        public int ma_sanpham { get; set; }

        public string ten_sanpham { get; set; }

        public int ma_danhmuc { get; set; }

        public int ma_thuonghieu { get; set; }

        public decimal gia_ban { get; set; }

        public decimal gia_nhap { get; set; }

        public string mau_sac { get; set; }

        public string hinh_anh { get; set; }

        public bool? trang_thai { get; set; }

        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        public virtual DANHMUC DANHMUC { get; set; }

        public virtual ICollection<GIOHANG_TEMP> GIOHANG_TEMP { get; set; }

        public virtual THUONGHIEU THUONGHIEU { get; set; }

        public virtual ICollection<SANPHAMDATHANG> SANPHAMDATHANGs { get; set; }

        public virtual ICollection<TONKHO> TONKHOes { get; set; }
    }
}
