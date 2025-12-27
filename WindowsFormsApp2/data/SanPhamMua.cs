using System;

namespace WindowsFormsApp2.data
{
    public class SanPhamMua
    {
        public int ma_hoadon { get; set; }
        public string ma_sanpham { get; set; }
        public string ten_sanpham { get; set; }
        public int so_luong { get; set; }
        public decimal don_gia { get; set; }
        public decimal thanh_tien { get; set; }
        public DateTime ngay_mua { get; set; }

        public SanPhamMua() { }

        public SanPhamMua(int ma_hoadon, string ma_sanpham, string ten_sanpham, int so_luong, decimal don_gia, decimal thanh_tien, DateTime ngay_mua)
        {
            this.ma_hoadon = ma_hoadon;
            this.ma_sanpham = ma_sanpham;
            this.ten_sanpham = ten_sanpham;
            this.so_luong = so_luong;
            this.don_gia = don_gia;
            this.thanh_tien = thanh_tien;
            this.ngay_mua = ngay_mua;
        }
    }
}
