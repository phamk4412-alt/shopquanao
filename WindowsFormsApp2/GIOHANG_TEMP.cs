namespace WindowsFormsApp2
{
    using System;
    using System.Collections.Generic;

    public partial class GIOHANG_TEMP
    {
        public int ma_giohang { get; set; }

        public int? ma_khachhang { get; set; }

        public int ma_sanpham { get; set; }

        public string kich_thuoc { get; set; }

        public int so_luong { get; set; }

        public decimal don_gia { get; set; }

        public DateTime? ngay_tao { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
