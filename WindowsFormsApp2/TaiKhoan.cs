namespace WindowsFormsApp2
{
    using System;
    using System.Collections.Generic;

    public partial class TAIKHOAN
    {
        public int ma_taikhoan { get; set; }

        public string ten_dang_nhap { get; set; }

        public string mat_khau { get; set; }

        public int ma_nhanvien { get; set; }

        public string quyen_han { get; set; }

        public bool? trang_thai { get; set; }

        public DateTime? ngay_tao { get; set; }

        public DateTime? lan_dang_nhap_cuoi { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
