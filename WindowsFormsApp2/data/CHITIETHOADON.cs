namespace WindowsFormsApp2.data
{
    using System;
    using System.Collections.Generic;

    public partial class CHITIETHOADON
    {
        public int ma_chitiethoadon { get; set; }

        public int ma_hoadon { get; set; }

        public int ma_sanpham { get; set; }

        public string kich_thuoc { get; set; }

        public int so_luong { get; set; }

        public decimal don_gia { get; set; }

        public decimal thanh_tien { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
