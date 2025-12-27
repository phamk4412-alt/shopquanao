using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ChiTietHoaDon : Form
    {
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }
    }

    public partial class CHITIETHOADON
    {
        public int ma_chitiet { get; set; }

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
