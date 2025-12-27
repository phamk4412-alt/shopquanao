namespace WindowsFormsApp2.data
{
    using System;
    using System.Collections.Generic;

    public partial class TONKHO
    {
        public int ma_tonkho { get; set; }

        public int ma_sanpham { get; set; }

        public string kich_thuoc { get; set; }

        public int so_luong_ton { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
