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
    public partial class SanPham : Form
    {
        private List<SANPHAM> danhSachSanPham = new List<SANPHAM>();
        private int selectedRowIndex = -1;
        private string selectedImagePath = "";
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private DatHang datHangForm = null; // Reference ??n form DatHang

        public SanPham()
        {
            InitializeComponent();
            LoadDataFromDatabase();
        }

        // Ph??ng th?c công khai ?? thi?t l?p reference c?a DatHang form
        public void SetDatHangForm(DatHang form)
        {
            datHangForm = form;
        }

        // Load d? li?u t? database vào DataGridView
        private void LoadDataFromDatabase()
        {
            try
            {
                danhSachSanPham = dbHelper.GetAllProducts();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i khi load d? li?u: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hi?n th? d? li?u lên DataGridView
        private void LoadData()
        {
            dgvsanpham.Rows.Clear();
            int stt = 1;
            foreach (var sp in danhSachSanPham)
            {
                dgvsanpham.Rows.Add(
                    stt++,
                    sp.ten_sanpham,
                    sp.mau_sac ?? "N/A",
                    sp.gia_ban.ToString("N0"),
                    sp.ma_sanpham,
                    sp.so_luong  // Hi?n th? s? l??ng th?c t?
                );
            }
        }

        // Nút T?i hình ?nh
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Ch?n hình ?nh s?n ph?m";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedImagePath = openFileDialog.FileName;
                    pictureBox2.Image = new Bitmap(selectedImagePath);
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    MessageBox.Show("T?i hình ?nh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i t?i hình ?nh: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút Thêm
        private void btthem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    // Ki?m tra mã s?n ph?m có trùng không
                    if (dbHelper.ProductExists(tbma.Text.Trim()))
                    {
                        MessageBox.Show("Mã s?n ph?m ?ã t?n t?i!", "C?nh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var sanPham = new SANPHAM
                    {
                        ten_sanpham = tbsanpham.Text.Trim(),
                        mau_sac = comboBox1.SelectedItem?.ToString() ?? "",
                        gia_ban = decimal.Parse(tbgiaban.Text),
                        ma_sanpham = tbma.Text.Trim(),
                        so_luong = string.IsNullOrEmpty(tbsoluong.Text) ? 0 : (int.TryParse(tbsoluong.Text, out int result) ? result : 0),
                        gia_nhap = 0,
                        ma_danhmuc = 1,
                        ma_thuonghieu = 1,
                        hinh_anh = selectedImagePath,
                        trang_thai = true
                    };

                    // L?u vào database
                    if (dbHelper.AddProduct(sanPham))
                    {
                        danhSachSanPham.Add(sanPham);
                        LoadData();
                        ClearInput();
                        MessageBox.Show("Thêm s?n ph?m thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // C?p nh?t d? li?u s?n ph?m m?i trong form DatHang
                        UpdateDatHangWithNewProduct(sanPham);
                    }
                    else
                    {
                        MessageBox.Show("Thêm s?n ph?m th?t b?i!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút S?a
        private void btsua_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng ch?n s?n ph?m c?n s?a!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateInput())
            {
                try
                {
                    var sanPham = danhSachSanPham[selectedRowIndex];
                    sanPham.ten_sanpham = tbsanpham.Text.Trim();
                    sanPham.mau_sac = comboBox1.SelectedItem?.ToString() ?? "";
                    sanPham.gia_ban = decimal.Parse(tbgiaban.Text);
                    sanPham.ma_sanpham = tbma.Text.Trim();
                    sanPham.so_luong = string.IsNullOrEmpty(tbsoluong.Text) ? 0 : (int.TryParse(tbsoluong.Text, out int result) ? result : 0);
                    
                    // C?p nh?t ?nh n?u có ch?n ?nh m?i
                    if (!string.IsNullOrEmpty(selectedImagePath))
                    {
                        sanPham.hinh_anh = selectedImagePath;
                    }

                    // L?u vào database
                    if (dbHelper.UpdateProduct(sanPham))
                    {
                        LoadData();
                        ClearInput();
                        selectedRowIndex = -1;
                        MessageBox.Show("C?p nh?t s?n ph?m thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // C?p nh?t d? li?u s?n ph?m trong form DatHang
                        UpdateDatHangWithUpdatedProduct(sanPham);
                    }
                    else
                    {
                        MessageBox.Show("C?p nh?t s?n ph?m th?t b?i!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút Xóa
        private void btxoa_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng ch?n s?n ph?m c?n xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("B?n có ch?c ch?n mu?n xóa s?n ph?m này?", "Xác nh?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string maSanPham = danhSachSanPham[selectedRowIndex].ma_sanpham;

                    // Xóa t? database
                    if (dbHelper.DeleteProduct(maSanPham))
                    {
                        danhSachSanPham.RemoveAt(selectedRowIndex);
                        LoadData();
                        ClearInput();
                        selectedRowIndex = -1;
                        MessageBox.Show("Xóa s?n ph?m thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // C?p nh?t d? li?u s?n ph?m trong form DatHang
                        RefreshDatHangProductData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa s?n ph?m th?t b?i!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Ph??ng th?c ?? c?p nh?t form DatHang khi có s?n ph?m m?i
        private void UpdateDatHangWithNewProduct(SANPHAM sanPham)
        {
            try
            {
                if (datHangForm != null && !datHangForm.IsDisposed)
                {
                    datHangForm.RefreshProductData();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("L?i c?p nh?t DatHang v?i s?n ph?m m?i: " + ex.Message);
            }
        }

        // Ph??ng th?c ?? c?p nh?t form DatHang khi s?n ph?m ???c s?a
        private void UpdateDatHangWithUpdatedProduct(SANPHAM sanPham)
        {
            try
            {
                if (datHangForm != null && !datHangForm.IsDisposed)
                {
                    datHangForm.RefreshProductData();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("L?i c?p nh?t DatHang v?i s?n ph?m ???c s?a: " + ex.Message);
            }
        }

        // Ph??ng th?c ?? làm m?i d? li?u s?n ph?m trong form DatHang
        private void RefreshDatHangProductData()
        {
            try
            {
                if (datHangForm != null && !datHangForm.IsDisposed)
                {
                    datHangForm.RefreshProductData();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("L?i làm m?i d? li?u DatHang: " + ex.Message);
            }
        }

        // S? ki?en click trên hàng DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < danhSachSanPham.Count)
            {
                selectedRowIndex = e.RowIndex;
                var sp = danhSachSanPham[selectedRowIndex];
                
                tbsanpham.Text = sp.ten_sanpham;
                comboBox1.SelectedItem = sp.mau_sac;
                tbgiaban.Text = sp.gia_ban.ToString();
                tbma.Text = sp.ma_sanpham;
                tbsoluong.Text = sp.so_luong.ToString();
                
                // Hi?n th? ?nh n?u có
                if (!string.IsNullOrEmpty(sp.hinh_anh) && System.IO.File.Exists(sp.hinh_anh))
                {
                    try
                    {
                        pictureBox2.Image = new Bitmap(sp.hinh_anh);
                        pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                        selectedImagePath = sp.hinh_anh;
                    }
                    catch
                    {
                        pictureBox2.Image = null;
                    }
                }
                else
                {
                    pictureBox2.Image = null;
                }
            }
        }

        // Ph??ng th?c ?? thêm s?n ph?m ???c ch?n vào gi? hàng (g?i t? button m?i)
        public void AddSelectedProductToDatHang(int quantity = 1)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng ch?n s?n ph?m c?n thêm vào gi? hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var sp = danhSachSanPham[selectedRowIndex];

                if (datHangForm == null || datHangForm.IsDisposed)
                {
                    MessageBox.Show("Form ??t Hàng ch?a ???c m?. Vui lòng m? form ??t Hàng tr??c!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm s?n ph?m vào form DatHang
                datHangForm.AddProductFromExternalSource(int.Parse(sp.ma_sanpham), sp.ten_sanpham, sp.gia_ban, sp.hinh_anh, quantity);
                MessageBox.Show($"?ã thêm {quantity} x {sp.ten_sanpham} vào gi? hàng!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ki?m tra d? li?u nh?p
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(tbsanpham.Text))
            {
                MessageBox.Show("Vui lòng nh?p tên s?n ph?m!", "C?nh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbsanpham.Focus();
                return false;
            }

            if (!decimal.TryParse(tbgiaban.Text, out _))
            {
                MessageBox.Show("Giá bán ph?i là s?!", "C?nh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbgiaban.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbma.Text))
            {
                MessageBox.Show("Vui lòng nh?p mã s?n ph?m!", "C?nh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbma.Focus();
                return false;
            }

            return true;
        }

        // Xóa d? li?u nh?p
        private void ClearInput()
        {
            tbsanpham.Text = "";
            comboBox1.SelectedIndex = -1;
            tbgiaban.Text = "";
            tbma.Text = "";
            tbsoluong.Text = "";
            pictureBox2.Image = null;
            selectedImagePath = "";
        }

        // Designer event handler c? (gi? l?i)
        private void button3_Click(object sender, EventArgs e)
        {
            btsua_Click(sender, e);
        }
    }

    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            GIOHANG_TEMP = new HashSet<GIOHANG_TEMP>();
            TONKHOes = new HashSet<TONKHO>();
        }

        public string ma_sanpham { get; set; }

        public string ten_sanpham { get; set; }

        public int ma_danhmuc { get; set; }

        public int ma_thuonghieu { get; set; }

        public decimal gia_ban { get; set; }

        public decimal gia_nhap { get; set; }

        public string mau_sac { get; set; }

        public string hinh_anh { get; set; }

        public int so_luong { get; set; }

        public bool? trang_thai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        public virtual DANHMUC DANHMUC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIOHANG_TEMP> GIOHANG_TEMP { get; set; }

        public virtual THUONGHIEU THUONGHIEU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TONKHO> TONKHOes { get; set; }
    }
}
