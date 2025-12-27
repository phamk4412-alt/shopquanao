namespace WindowsFormsApp2.data
{
    using System;
    using System.Collections.Generic;

    public partial class DANHMUC
    {
        public int ma_danhmuc { get; set; }

        public string ten_danhmuc { get; set; }

        public string mo_ta { get; set; }

        public bool trang_thai { get; set; }

        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
