using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.data;

namespace WindowsFormsApp2
{
    public partial class GioHang : Form
    {
        private List<SanPhamMua> sanPhamMuaList = new List<SanPhamMua>();
        private int invoiceId = -1;
        private decimal totalPrice = 0;

        public GioHang()
        {
            InitializeComponent();
        }

        public GioHang(List<SanPhamMua> items, int ma_hoadon, decimal tong_tien)
        {
            InitializeComponent();
            sanPhamMuaList = items ?? new List<SanPhamMua>();
            invoiceId = ma_hoadon;
            totalPrice = tong_tien;
            DisplayCartItems();
        }

        // Hiển thị danh sách sản phẩm trong giỏ hàng
        private void DisplayCartItems()
        {
            try
            {
                // Cập nhật title của form
                this.Text = $"Giỏ Hàng - Hoá Đơn #{invoiceId} - Tổng: {totalPrice:N0}đ";

                // Tìm control DataGridView để hiển thị dữ liệu
                Control[] dataGridControls = this.Controls.Find("dataGridView1", true);
                
                if (dataGridControls.Length > 0 && dataGridControls[0] is DataGridView dgv)
                {
                    dgv.DataSource = null; // Xóa dữ liệu cũ
                    dgv.DataSource = sanPhamMuaList; // Gắn danh sách mới

                    // Cập nhật tiêu đề cột
                    if (dgv.Columns.Count > 0)
                    {
                        dgv.Columns["ma_hoadon"].HeaderText = "Mã Hoá Đơn";
                        dgv.Columns["ma_sanpham"].HeaderText = "Mã Sản Phẩm";
                        dgv.Columns["ten_sanpham"].HeaderText = "Tên Sản Phẩm";
                        dgv.Columns["so_luong"].HeaderText = "Số Lượng";
                        dgv.Columns["don_gia"].HeaderText = "Đơn Giá";
                        dgv.Columns["thanh_tien"].HeaderText = "Thành Tiền";
                        dgv.Columns["ngay_mua"].HeaderText = "Ngày Mua";
                    }
                }
                else
                {
                    // Nếu không có DataGridView, hiển thị thông qua MessageBox
                    string cartInfo = $"Giỏ Hàng - Hoá Đơn #{invoiceId}\n";
                    cartInfo += $"{'='*50}\n";
                    foreach (var item in sanPhamMuaList)
                    {
                        cartInfo += $"Mã SP: {item.ma_sanpham}\n";
                        cartInfo += $"Tên: {item.ten_sanpham}\n";
                        cartInfo += $"Số lượng: {item.so_luong}\n";
                        cartInfo += $"Đơn giá: {item.don_gia:N0}đ\n";
                        cartInfo += $"Thành tiền: {item.thanh_tien:N0}đ\n";
                        cartInfo += $"Ngày mua: {item.ngay_mua:dd/MM/yyyy HH:mm:ss}\n";
                        cartInfo += $"{'-'*50}\n";
                    }
                    cartInfo += $"Tổng Cộng: {totalPrice:N0}đ";
                    
                    MessageBox.Show(cartInfo, "Thông tin Giỏ Hàng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị giỏ hàng: " + ex.Message, "Lỗi");
            }
        }

        public int GetInvoiceId()
        {
            return invoiceId;
        }

        public List<SanPhamMua> GetSanPhamMuaList()
        {
            return sanPhamMuaList;
        }

        public decimal GetTotalPrice()
        {
            return totalPrice;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
