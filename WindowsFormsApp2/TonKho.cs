namespace WindowsFormsApp2
{
    using System;
    using System.Collections.Generic;

    public partial class TONKHO
    {
        public int ma_tonkho { get; set; }

        public int ma_sanpham { get; set; }

        public string kich_thuoc { get; set; }

        public int so_luong { get; set; }

        public DateTime? cap_nhat_cuoi { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }

        private void TONKHO_Load(object sender, EventArgs e)
        {

        }

        private void btsua_Click(object sender, EventArgs e)
        {

        }

        private void btthem_Click(object sender, EventArgs e)
        {

        }
    }
}
