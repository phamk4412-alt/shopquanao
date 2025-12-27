using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WindowsFormsApp2.data;

namespace WindowsFormsApp2
{
    public class DatabaseHelper
    {
        private string connectionString = "data source=Admin\\SQLEXPRESS;initial catalog=QLQA;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True";

        public DatabaseHelper()
        {
        }

        // L?y t?t c? s?n ph?m t? database
        public List<SANPHAM> GetAllProducts()
        {
            List<SANPHAM> products = new List<SANPHAM>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ma_sanpham, ten_sanpham, ma_danhmuc, ma_thuonghieu, gia_ban, gia_nhap, mau_sac, hinh_anh, trang_thai FROM SANPHAM";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 30;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var product = new SANPHAM
                                {
                                    ma_sanpham = reader["ma_sanpham"].ToString(),
                                    ten_sanpham = reader["ten_sanpham"] != DBNull.Value ? reader["ten_sanpham"].ToString() : "",
                                    ma_danhmuc = (int)reader["ma_danhmuc"],
                                    ma_thuonghieu = (int)reader["ma_thuonghieu"],
                                    gia_ban = (decimal)reader["gia_ban"],
                                    gia_nhap = (decimal)reader["gia_nhap"],
                                    mau_sac = reader["mau_sac"] != DBNull.Value ? reader["mau_sac"].ToString() : "",
                                    hinh_anh = reader["hinh_anh"] != DBNull.Value ? reader["hinh_anh"].ToString() : "",
                                    trang_thai = reader["trang_thai"] != DBNull.Value ? (bool?)reader["trang_thai"] : false
                                };
                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("L?i khi l?y d? li?u s?n ph?m: " + ex.Message);
            }

            return products;
        }

        // Thêm s?n ph?m vào database
        public bool AddProduct(SANPHAM product)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Ki?m tra xem c?t ma_sanpham có ph?i IDENTITY không
                    // N?u là STRING (VARCHAR), không c?n IDENTITY_INSERT
                    string query = @"INSERT INTO SANPHAM (ma_sanpham, ten_sanpham, ma_danhmuc, ma_thuonghieu, gia_ban, gia_nhap, mau_sac, hinh_anh, trang_thai)
                                    VALUES (@ma_sanpham, @ten_sanpham, @ma_danhmuc, @ma_thuonghieu, @gia_ban, @gia_nhap, @mau_sac, @hinh_anh, @trang_thai)";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 30;
                        cmd.Parameters.AddWithValue("@ma_sanpham", product.ma_sanpham ?? "");
                        cmd.Parameters.AddWithValue("@ten_sanpham", product.ten_sanpham ?? "");
                        cmd.Parameters.AddWithValue("@ma_danhmuc", product.ma_danhmuc);
                        cmd.Parameters.AddWithValue("@ma_thuonghieu", product.ma_thuonghieu);
                        cmd.Parameters.AddWithValue("@gia_ban", product.gia_ban);
                        cmd.Parameters.AddWithValue("@gia_nhap", product.gia_nhap);
                        cmd.Parameters.AddWithValue("@mau_sac", product.mau_sac ?? "");
                        cmd.Parameters.AddWithValue("@hinh_anh", product.hinh_anh ?? "");
                        cmd.Parameters.AddWithValue("@trang_thai", product.trang_thai ?? false);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                // N?u l?i IDENTITY_INSERT, th? l?i v?i IDENTITY_INSERT ON
                if (ex.Message.Contains("IDENTITY_INSERT"))
                {
                    return AddProductWithIdentityInsert(product);
                }
                throw new Exception("L?i khi thêm s?n ph?m: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("L?i khi thêm s?n ph?m: " + ex.Message);
            }
        }

        // Thêm s?n ph?m v?i IDENTITY_INSERT ON
        private bool AddProductWithIdentityInsert(SANPHAM product)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    string query = @"SET IDENTITY_INSERT SANPHAM ON;
                                    INSERT INTO SANPHAM (ma_sanpham, ten_sanpham, ma_danhmuc, ma_thuonghieu, gia_ban, gia_nhap, mau_sac, hinh_anh, trang_thai)
                                    VALUES (@ma_sanpham, @ten_sanpham, @ma_danhmuc, @ma_thuonghieu, @gia_ban, @gia_nhap, @mau_sac, @hinh_anh, @trang_thai);
                                    SET IDENTITY_INSERT SANPHAM OFF;";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 30;
                        cmd.Parameters.AddWithValue("@ma_sanpham", product.ma_sanpham ?? "");
                        cmd.Parameters.AddWithValue("@ten_sanpham", product.ten_sanpham ?? "");
                        cmd.Parameters.AddWithValue("@ma_danhmuc", product.ma_danhmuc);
                        cmd.Parameters.AddWithValue("@ma_thuonghieu", product.ma_thuonghieu);
                        cmd.Parameters.AddWithValue("@gia_ban", product.gia_ban);
                        cmd.Parameters.AddWithValue("@gia_nhap", product.gia_nhap);
                        cmd.Parameters.AddWithValue("@mau_sac", product.mau_sac ?? "");
                        cmd.Parameters.AddWithValue("@hinh_anh", product.hinh_anh ?? "");
                        cmd.Parameters.AddWithValue("@trang_thai", product.trang_thai ?? false);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("L?i khi thêm s?n ph?m (v?i IDENTITY_INSERT): " + ex.Message);
            }
        }

        // C?p nh?t s?n ph?m trong database
        public bool UpdateProduct(SANPHAM product)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE SANPHAM SET 
                                    ten_sanpham = @ten_sanpham, 
                                    ma_danhmuc = @ma_danhmuc, 
                                    ma_thuonghieu = @ma_thuonghieu, 
                                    gia_ban = @gia_ban, 
                                    gia_nhap = @gia_nhap, 
                                    mau_sac = @mau_sac, 
                                    hinh_anh = @hinh_anh, 
                                    trang_thai = @trang_thai
                                    WHERE ma_sanpham = @ma_sanpham";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 30;
                        cmd.Parameters.AddWithValue("@ma_sanpham", product.ma_sanpham ?? "");
                        cmd.Parameters.AddWithValue("@ten_sanpham", product.ten_sanpham ?? "");
                        cmd.Parameters.AddWithValue("@ma_danhmuc", product.ma_danhmuc);
                        cmd.Parameters.AddWithValue("@ma_thuonghieu", product.ma_thuonghieu);
                        cmd.Parameters.AddWithValue("@gia_ban", product.gia_ban);
                        cmd.Parameters.AddWithValue("@gia_nhap", product.gia_nhap);
                        cmd.Parameters.AddWithValue("@mau_sac", product.mau_sac ?? "");
                        cmd.Parameters.AddWithValue("@hinh_anh", product.hinh_anh ?? "");
                        cmd.Parameters.AddWithValue("@trang_thai", product.trang_thai ?? false);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("L?i khi c?p nh?t s?n ph?m: " + ex.Message);
            }
        }

        // Xóa s?n ph?m kh?i database
        public bool DeleteProduct(string ma_sanpham)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM SANPHAM WHERE ma_sanpham = @ma_sanpham";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 30;
                        cmd.Parameters.AddWithValue("@ma_sanpham", ma_sanpham ?? "");

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("L?i khi xóa s?n ph?m: " + ex.Message);
            }
        }

        // Ki?m tra xem mã s?n ph?m ?ã t?n t?i hay ch?a
        public bool ProductExists(string ma_sanpham)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM SANPHAM WHERE ma_sanpham = @ma_sanpham";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                        cmd.CommandTimeout = 30;
                        cmd.Parameters.AddWithValue("@ma_sanpham", ma_sanpham ?? "");
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("L?i khi ki?m tra s?n ph?m: " + ex.Message);
            }
        }

        // L?y mã nhân viên ??u tiên t? database
        private int GetOrCreateEmployee()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Ki?m tra nhân viên ?ã t?n t?i
                    string checkQuery = "SELECT TOP 1 ma_nhanvien FROM NHANVIEN WHERE trang_thai = 1 ORDER BY ma_nhanvien";
                    using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                    {
                        cmd.CommandTimeout = 30;
                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int employeeId))
                        {
                            return employeeId;
                        }
                    }
                    
                    // N?u không có nhân viên, t?o nhân viên m?c ??nh
                    string insertQuery = @"INSERT INTO NHANVIEN (ho_ten, sdt, email, chuc_vu, luong, ngay_vao_lam, trang_thai)
                                          VALUES (@ho_ten, @sdt, @email, @chuc_vu, @luong, @ngay_vao_lam, @trang_thai);
                                          SELECT SCOPE_IDENTITY();";
                    
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.CommandTimeout = 30;
                        cmd.Parameters.AddWithValue("@ho_ten", "Nhân viên m?c ??nh");
                        cmd.Parameters.AddWithValue("@sdt", "0000000000");
                        cmd.Parameters.AddWithValue("@email", "default@example.com");
                        cmd.Parameters.AddWithValue("@chuc_vu", "Bán hàng");
                        cmd.Parameters.AddWithValue("@luong", 0);
                        cmd.Parameters.AddWithValue("@ngay_vao_lam", DateTime.Now);
                        cmd.Parameters.AddWithValue("@trang_thai", true);
                        
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            if (decimal.TryParse(result.ToString(), out decimal employeeIdDecimal))
                            {
                                return (int)employeeIdDecimal;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetOrCreateEmployee: " + ex.Message);
            }
            
            return -1;
        }

        // L?u hoá ??n vào database
        public int CreateInvoice(int? ma_khachhang, string dia_chi_giao_hang, string sdt_giao_hang, decimal tong_tien)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // L?y nhân viên ho?c t?o m?i n?u ch?a có
                    int ma_nhanvien = GetOrCreateEmployee();
                    
                    if (ma_nhanvien == -1)
                    {
                        throw new Exception("Không th? l?y ho?c t?o nhân viên. Vui lòng ki?m tra k?t n?i database.");
                    }
                    
                    string query = @"INSERT INTO HOADON (ma_khachhang, ma_nhanvien, ngay_dat_hang, dia_chi_giao_hang, sdt_giao_hang, tong_tien, giam_gia, phi_van_chuyen, thanh_toan, phuong_thuc_thanh_toan, trang_thai)
                                    VALUES (@ma_khachhang, @ma_nhanvien, @ngay_dat_hang, @dia_chi_giao_hang, @sdt_giao_hang, @tong_tien, @giam_gia, @phi_van_chuyen, @thanh_toan, @phuong_thuc_thanh_toan, @trang_thai);
                                    SELECT SCOPE_IDENTITY();";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 30;
                        cmd.Parameters.AddWithValue("@ma_khachhang", ma_khachhang ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ma_nhanvien", ma_nhanvien);
                        cmd.Parameters.AddWithValue("@ngay_dat_hang", DateTime.Now);
                        cmd.Parameters.AddWithValue("@dia_chi_giao_hang", dia_chi_giao_hang ?? "");
                        cmd.Parameters.AddWithValue("@sdt_giao_hang", sdt_giao_hang ?? "");
                        cmd.Parameters.AddWithValue("@tong_tien", tong_tien);
                        cmd.Parameters.AddWithValue("@giam_gia", 0);
                        cmd.Parameters.AddWithValue("@phi_van_chuyen", 0);
                        cmd.Parameters.AddWithValue("@thanh_toan", tong_tien);
                        cmd.Parameters.AddWithValue("@phuong_thuc_thanh_toan", "Ti?n m?t");
                        cmd.Parameters.AddWithValue("@trang_thai", "Ch? xác nh?n");

                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int invoiceId))
                        {
                            return invoiceId;
                        }
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("L?i khi l?u hoá ??n: " + ex.Message);
            }
        }

        // L?u chi ti?t hoá ??n
        public bool AddInvoiceDetail(int ma_hoadon, string ma_sanpham, int so_luong, decimal don_gia)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO CHITIETHOADON (ma_hoadon, ma_sanpham, so_luong, don_gia, thanh_tien)
                                    VALUES (@ma_hoadon, @ma_sanpham, @so_luong, @don_gia, @thanh_tien)";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 30;
                        cmd.Parameters.AddWithValue("@ma_hoadon", ma_hoadon);
                        cmd.Parameters.AddWithValue("@ma_sanpham", ma_sanpham ?? "");
                        cmd.Parameters.AddWithValue("@so_luong", so_luong);
                        cmd.Parameters.AddWithValue("@don_gia", don_gia);
                        cmd.Parameters.AddWithValue("@thanh_tien", so_luong * don_gia);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("L?i khi l?u chi ti?t hoá ??n: " + ex.Message);
            }
        }

        // L?u s?n ph?m ?ã thêm vào b?ng SANPHAMDATHANG
        public bool AddSanPhamDatHang(int ma_hoadon, int ma_sanpham, string ten_sanpham, string hinh_anh, int so_luong, decimal gia, decimal thanh_tien)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO SANPHAMDATHANG (ma_hoadon, ma_sanpham, ten_sanpham, hinh_anh, so_luong, gia, thanh_tien)
                                    VALUES (@ma_hoadon, @ma_sanpham, @ten_sanpham, @hinh_anh, @so_luong, @gia, @thanh_tien)";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 30;
                        cmd.Parameters.AddWithValue("@ma_hoadon", ma_hoadon);
                        cmd.Parameters.AddWithValue("@ma_sanpham", ma_sanpham);
                        cmd.Parameters.AddWithValue("@ten_sanpham", ten_sanpham ?? "");
                        cmd.Parameters.AddWithValue("@hinh_anh", hinh_anh ?? "");
                        cmd.Parameters.AddWithValue("@so_luong", so_luong);
                        cmd.Parameters.AddWithValue("@gia", gia);
                        cmd.Parameters.AddWithValue("@thanh_tien", thanh_tien);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("L?i khi l?u s?n ph?m ?ã thêm: " + ex.Message);
            }
        }

        // L?u d? li?u ??t hàng vào b?ng DuLieuDatHang
        public bool AddDuLieuDatHang(int ma_hoadon, int ma_sanpham, string ten_sanpham, string hinh_anh, 
                                     int so_luong, decimal gia_don, decimal tong_tien)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO DuLieuDatHang (ma_hoadon, ma_sanpham, ten_sanpham, hinh_anh, so_luong, gia_don, tong_tien, ngay_dat_hang)
                                    VALUES (@ma_hoadon, @ma_sanpham, @ten_sanpham, @hinh_anh, @so_luong, @gia_don, @tong_tien, @ngay_dat_hang)";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 30;
                        cmd.Parameters.AddWithValue("@ma_hoadon", ma_hoadon);
                        cmd.Parameters.AddWithValue("@ma_sanpham", ma_sanpham);
                        cmd.Parameters.AddWithValue("@ten_sanpham", ten_sanpham ?? "");
                        cmd.Parameters.AddWithValue("@hinh_anh", hinh_anh ?? "");
                        cmd.Parameters.AddWithValue("@so_luong", so_luong);
                        cmd.Parameters.AddWithValue("@gia_don", gia_don);
                        cmd.Parameters.AddWithValue("@tong_tien", tong_tien);
                        cmd.Parameters.AddWithValue("@ngay_dat_hang", DateTime.Now);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("L?i khi l?u d? li?u ??t hàng: " + ex.Message);
            }
        }
    }
}
