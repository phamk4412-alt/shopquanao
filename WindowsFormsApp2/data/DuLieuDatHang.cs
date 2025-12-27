using System;

namespace WindowsFormsApp2.data
{
    public class DuLieuDatHang
    {
        public int ma_hoadon { get; set; }
        public int ma_sanpham { get; set; }
        public string ten_sanpham { get; set; }
        public string hinh_anh { get; set; }
        public int so_luong { get; set; }
        public decimal gia_don { get; set; }
        public decimal tong_tien { get; set; }
        public DateTime ngay_dat_hang { get; set; }

        public DuLieuDatHang() { }

        public DuLieuDatHang(int ma_hoadon, int ma_sanpham, string ten_sanpham, string hinh_anh, 
                            int so_luong, decimal gia_don, decimal tong_tien, DateTime ngay_dat_hang)
        {
            this.ma_hoadon = ma_hoadon;
            this.ma_sanpham = ma_sanpham;
            this.ten_sanpham = ten_sanpham;
            this.hinh_anh = hinh_anh;
            this.so_luong = so_luong;
            this.gia_don = gia_don;
            this.tong_tien = tong_tien;
            this.ngay_dat_hang = ngay_dat_hang;
        }
    }
}
