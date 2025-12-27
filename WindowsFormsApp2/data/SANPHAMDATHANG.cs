namespace WindowsFormsApp2.data
{
    using System;
    using System.Collections.Generic;

    public partial class SANPHAMDATHANG
    {
        public int ma_sanphamdathang { get; set; }

        public int ma_hoadon { get; set; }

        public int ma_sanpham { get; set; }

        public string ten_sanpham { get; set; }

        public string hinh_anh { get; set; }

        public int so_luong { get; set; }

        public decimal gia { get; set; }

        public decimal thanh_tien { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
