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
    public partial class TrangChu : Form
    {
        private bool isInitializing = true;
        private DatHang datHangForm = null; // Lưu reference của form DatHang

        public TrangChu()
        {
            InitializeComponent();
            ApplyHoverEffectToButtons();
            ApplyHoverEffectToPanels();
            
            // Gắn event handler cho button Đặt hàng
            buttondathang.Click += Buttondathang_Click;
            
            // Đánh dấu hoàn tất khởi tạo
            isInitializing = false;
        }

        // Cập nhật ngôn ngữ cho form TrangChu
        public void UpdateLanguage()
        {
            try
            {
                this.Text = LanguageManager.GetTranslation("TrangChu_Title");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật ngôn ngữ: " + ex.Message);
            }
        }

        // Áp dụng hiệu ứng hover cho tất cả các button
        private void ApplyHoverEffectToButtons()
        {
            try
            {
                new ButtonHoverEffect(button1, 1.15f);
                new ButtonHoverEffect(buttondathang, 1.15f);
                new ButtonHoverEffect(btsanpham, 1.15f);
                new ButtonHoverEffect(button4, 1.15f);
                new ButtonHoverEffect(button8, 1.15f);
                new ButtonHoverEffect(button7, 1.15f);
                new ButtonHoverEffect(button6, 1.15f);
                new ButtonHoverEffect(button5, 1.15f);

                new ButtonHoverEffect(button11, 1.1f);
                new ButtonHoverEffect(button10, 1.1f);
                new ButtonHoverEffect(button13, 1.1f);
                new ButtonHoverEffect(button9, 1.1f);
                new ButtonHoverEffect(button12, 1.1f);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi áp dụng hover effect cho button: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Áp dụng hiệu ứng hover cho panel
        private void ApplyHoverEffectToPanels()
        {
            try
            {
                new PanelHoverEffect(panelquanao1, 1.15f);
                new PanelHoverEffect(panelquanao2, 1.15f);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi áp dụng hover effect cho panel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện click button Sản phẩm
        private void btsanpham_Click(object sender, EventArgs e)
        {
            try
            {
                SanPham sanPhamForm = new SanPham();
                // Truyền reference của DatHang form vào SanPham form để khi click sản phẩm có thể cập nhật
                sanPhamForm.SetDatHangForm(GetOrCreateDatHangForm());
                sanPhamForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Sản Phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức để lấy hoặc tạo form DatHang
        private DatHang GetOrCreateDatHangForm()
        {
            if (datHangForm == null || datHangForm.IsDisposed)
            {
                datHangForm = new DatHang();
            }
            return datHangForm;
        }

        // Event khi bấm button Khách hàng (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Form Khách Hàng đang được phát triển", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        // Event khi bấm button Đặt hàng (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DatHang form = GetOrCreateDatHangForm();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Đặt Hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event khi bấm button Giỏ hàng (button4)
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                GioHang giaHangForm = new GioHang();
                giaHangForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Giỏ Hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event khi bấm button Hoá đơn (button8)
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                // HoaDon hoaDonForm = new HoaDon();
                // hoaDonForm.Show();
                MessageBox.Show("Form Hoá Đơn đang được phát triển", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Hoá Đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event khi bấm button Báo cáo (button7)
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                BaoCaoDoanhThu baoCaoForm = new BaoCaoDoanhThu();
                baoCaoForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Báo Cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event khi bấm button Nhân Viên (button6)
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                QuanLy quanLyForm = new QuanLy();
                quanLyForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Quản Lý Nhân Viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event khi bấm button Thống Kê Sản Phẩm (button5)
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ThongKeSanPham thongKeForm = new ThongKeSanPham();
                thongKeForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Thống Kê Sản Phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event khi bấm button TRANG CHỦ (button11)
        private void button11_Click(object sender, EventArgs e)
        {
            // Reload trang chủ
            MessageBox.Show("Bạn đang ở Trang Chủ", "Thông báo");
        }

        // Event khi bấm button TIN TỨC (button10)
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                TinTuc tinTucForm = new TinTuc();
                tinTucForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Tin Tức: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event khi bấm button TÀI KHOẢN (button13)
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                // TaiKhoan taiKhoanForm = new TaiKhoan();
                // taiKhoanForm.Show();
                MessageBox.Show("Form Tài Khoản đang được phát triển", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Tài Khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event khi bấm button THÔNG BÁO (button9)
        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Thông báo đang được phát triển", "Thông báo");
        }

        // Event khi bấm button Đăng Nhập (button12)
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                DangNhap dangNhapForm = new DangNhap();
                dangNhapForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Đăng Nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelquanao2_Paint(object sender, PaintEventArgs e)
        {

        }

        // Event khi bấm button Cài đặt
        private void Btcaidat_Click(object sender, EventArgs e)
        {
            try
            {
                Setting settingForm = new Setting();
                settingForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Setting: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        // Event khi bấm button Đặt hàng (buttondathang)
        private void Buttondathang_Click(object sender, EventArgs e)
        {
            try
            {
                DatHang form = GetOrCreateDatHangForm();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form Đặt Hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            // Khởi tạo form Giỏ Hàng
            GioHang frm = new GioHang();

            // Hiển thị form lên
            frm.ShowDialog();
        }
    }
}
