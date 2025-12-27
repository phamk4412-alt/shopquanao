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
    public partial class DatHang : Form
    {
        private decimal totalPrice = 0;
        private List<SANPHAMDATHANG> cartItems = new List<SANPHAMDATHANG>();
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private List<SANPHAM> allProducts = new List<SANPHAM>();
        private int currentInvoiceId = -1; // Lưu ID hoá đơn hiện tại
        private decimal totalInvoiceAmount = 0; // Lưu tổng tiền hoá đơn

        public DatHang()
        {
            InitializeComponent();
            LoadProductsFromDatabase();
        }

        // Lấy dữ liệu từ database và hiển thị
        private void LoadProductsFromDatabase()
        {
            try
            {
                // Lấy tất cả sản phẩm từ database
                allProducts = dbHelper.GetAllProducts();

                if (allProducts == null || allProducts.Count == 0)
                {
                    MessageBox.Show("Không có sản phẩm nào trong database", "Thông báo");
                    return;
                }

                // Hiển thị sản phẩm vào các control
                DisplayProductsToUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hiển thị sản phẩm vào các control trên form - bắt đầu từ groupBox13 (ô đầu tiên)
        private void DisplayProductsToUI()
        {
            try
            {
                // Các groupBox sản phẩm theo thứ tự
                string[] groupBoxNames = { "groupBox13", "groupBox2", "groupBox1", "groupBox3", "groupBox4", 
                                         "groupBox5", "groupBox9", "groupBox11", "groupBox10", "groupBox8",
                                         "groupBox7", "groupBox6", "groupBox24", "groupBox23", "groupBox22",
                                         "groupBox21", "groupBox20", "groupBox19", "groupBox18", "groupBox17" };

                int productIndex = 0;
                foreach (var product in allProducts)
                {
                    if (productIndex >= groupBoxNames.Length) break;

                    string groupBoxName = groupBoxNames[productIndex];
                    Control[] groupBoxControls = this.Controls.Find(groupBoxName, true);

                    if (groupBoxControls.Length > 0 && groupBoxControls[0] is GroupBox groupBox)
                    {
                        // Tìm các control trong groupBox
                        Control[] pictureBoxControls = groupBox.Controls.OfType<PictureBox>().Cast<Control>().ToArray();
                        Control[] textBoxControls = groupBox.Controls.OfType<TextBox>().Cast<Control>().ToArray();
                        Control[] numericControls = groupBox.Controls.OfType<NumericUpDown>().Cast<Control>().ToArray();
                        Control[] buttonControls = groupBox.Controls.OfType<Button>().Cast<Control>().ToArray();

                        // Cập nhật groupBox text
                        groupBox.Text = product.ten_sanpham;

                        // Cập nhật textBox tên sản phẩm (textBox tại vị trí 1)
                        if (textBoxControls.Length > 1)
                        {
                            TextBox tenSPBox = (TextBox)textBoxControls[1];
                            tenSPBox.Text = product.ten_sanpham;
                        }

                        // Cập nhật textBox giá (textBox tại vị trí 0)
                        if (textBoxControls.Length > 0)
                        {
                            TextBox giaBox = (TextBox)textBoxControls[0];
                            giaBox.Text = product.gia_ban.ToString("N0") + "đ";
                        }

                        // Cập nhật hình ảnh từ file path
                        if (pictureBoxControls.Length > 0)
                        {
                            PictureBox pic = (PictureBox)pictureBoxControls[0];
                            if (!string.IsNullOrEmpty(product.hinh_anh) && System.IO.File.Exists(product.hinh_anh))
                            {
                                try
                                {
                                    pic.Image = Image.FromFile(product.hinh_anh);
                                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                                }
                                catch
                                {
                                    pic.BackColor = Color.Gray;
                                }
                            }
                            else
                            {
                                pic.BackColor = Color.LightGray;
                            }
                        }

                        // Gắn sự kiện click cho button "Thêm Vào Giỏ Hàng"
                        if (buttonControls.Length > 0)
                        {
                            Button btn = (Button)buttonControls[0];
                            btn.Click -= Button_Click; // Xóa event cũ nếu có
                            btn.Click += (sender, e) => 
                            {
                                int quantity = numericControls.Length > 0 ? (int)((NumericUpDown)numericControls[0]).Value : 1;
                                if (quantity <= 0) quantity = 1;
                                AddProductToCart(product.ma_sanpham.ToString(), product.ten_sanpham, product.gia_ban, product.hinh_anh, quantity);
                            };
                        }

                        // Cập nhật numeric updown
                        if (numericControls.Length > 0)
                        {
                            NumericUpDown numericBox = (NumericUpDown)numericControls[0];
                            numericBox.Value = 1;
                            numericBox.Minimum = 1;
                            numericBox.Maximum = 100;
                        }
                    }

                    productIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị sản phẩm: " + ex.Message, "Lỗi");
            }
        }

        // Xử lý sự kiện click button
        private void Button_Click(object sender, EventArgs e)
        {
        }

        // Thêm sản phẩm vào giỏ hàng
        private void AddProductToCart(string productId, string productName, decimal price, string hinhAnh, int quantity)
        {
            try
            {
                // Tìm sản phẩm đã có trong giỏ hàng không
                var existingItem = cartItems.FirstOrDefault(x => x.ma_sanpham == int.Parse(productId));

                if (existingItem != null)
                {
                    // Nếu đã có thì tăng số lượng
                    existingItem.so_luong += quantity;
                    existingItem.thanh_tien = existingItem.so_luong * existingItem.gia;
                }
                else
                {
                    // Nếu chưa có thì thêm mới
                    cartItems.Add(new SANPHAMDATHANG
                    {
                        ma_hoadon = currentInvoiceId,
                        ma_sanpham = int.Parse(productId),
                        ten_sanpham = productName,
                        hinh_anh = hinhAnh,
                        so_luong = quantity,
                        gia = price,
                        thanh_tien = quantity * price
                    });
                }

                // Lưu vào database HOADON
                SaveInvoiceToDatabase(productId, productName, price, hinhAnh, quantity);

                MessageBox.Show($"Đã thêm {quantity} x {productName} vào giỏ hàng", "Thành công");
                UpdateCartDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi");
            }
        }

        // Lưu hoá đơn vào database
        private void SaveInvoiceToDatabase(string productId, string productName, decimal price, string hinhAnh, int quantity)
        {
            try
            {
                // Tính tổng tiền cho sản phẩm này
                decimal totalAmount = quantity * price;

                // Nếu chưa tạo hoá đơn, tạo mới
                if (currentInvoiceId == -1)
                {
                    currentInvoiceId = dbHelper.CreateInvoice(
                        null, // ma_khachhang (có thể null)
                        "", // dia_chi_giao_hang
                        "", // sdt_giao_hang
                        totalAmount
                    );

                    if (currentInvoiceId == -1)
                    {
                        MessageBox.Show("Lỗi tạo hoá đơn", "Lỗi");
                        return;
                    }
                }
                else
                {
                    // Cập nhật tổng tiền của hoá đơn hiện tại
                    totalInvoiceAmount += totalAmount;
                }

                // Chuyển đổi mã sản phẩm sang int
                int maSanPhamInt = 0;
                if (!int.TryParse(productId, out maSanPhamInt))
                {
                    MessageBox.Show("Lỗi: Mã sản phẩm không hợp lệ", "Lỗi");
                    return;
                }

                // Lưu vào bảng SANPHAMDATHANG
                bool result = dbHelper.AddSanPhamDatHang(
                    currentInvoiceId,
                    maSanPhamInt,
                    productName,
                    hinhAnh,
                    quantity,
                    price,
                    totalAmount
                );

                if (!result)
                {
                    MessageBox.Show("Lỗi lưu dữ liệu đặt hàng", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        // Cập nhật hiển thị giỏ hàng
        private void UpdateCartDisplay()
        {
            try
            {
                if (cartItems.Count == 0)
                {
                    return;
                }

                string cartInfo = "Giỏ hàng của bạn:\n\n";
                foreach (var item in cartItems)
                {
                    cartInfo += $"{item.ten_sanpham} x{item.so_luong} = {item.thanh_tien:N0}đ\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật giỏ hàng: " + ex.Message, "Lỗi");
            }
        }

        // Các event handler từ Designer
        private void button25_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                totalPrice = cartItems.Sum(x => x.thanh_tien);
                
                // Convert SANPHAMDATHANG to SanPhamMua
                List<SanPhamMua> sanPhamMuaList = cartItems.Select(item => new SanPhamMua
                {
                    ma_hoadon = currentInvoiceId,
                    ma_sanpham = item.ma_sanpham.ToString(),
                    ten_sanpham = item.ten_sanpham,
                    so_luong = item.so_luong,
                    don_gia = item.gia,
                    thanh_tien = item.thanh_tien,
                    ngay_mua = DateTime.Now
                }).ToList();
                
                // Mở form GioHang và truyền dữ liệu
                GioHang gioHangForm = new GioHang(sanPhamMuaList, currentInvoiceId, totalPrice);
                gioHangForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        // Getter để lấy danh sách SANPHAMDATHANG
        public List<SANPHAMDATHANG> GetSanPhamDatHangList()
        {
            return cartItems;
        }

        // Phương thức công khai để thêm sản phẩm vào giỏ hàng từ form khác
        public void AddProductFromExternalSource(int productId, string productName, decimal price, string hinhAnh, int quantity = 1)
        {
            try
            {
                AddProductToCart(productId.ToString(), productName, price, hinhAnh, quantity);
                this.Activate();
                this.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        // Phương thức công khai để cập nhật dữ liệu sản phẩm từ database
        public void RefreshProductData()
        {
            try
            {
                LoadProductsFromDatabase();
                MessageBox.Show("Đã cập nhật dữ liệu sản phẩm mới!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi");
            }
        }
        // Các stub event handler từ Designer
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void groupBox13_Enter(object sender, EventArgs e) { }
        private void button13_Click(object sender, EventArgs e) { }
        private void numericUpDown13_ValueChanged(object sender, EventArgs e) { }
        private void textBox25_TextChanged(object sender, EventArgs e) { }
        private void textBox26_TextChanged(object sender, EventArgs e) { }
        private void pictureBox13_Click(object sender, EventArgs e) { }
        private void groupBox5_Enter(object sender, EventArgs e) { }
        private void pictureBox4_Click(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void pictureBox3_Click(object sender, EventArgs e) { }
        private void groupBox4_Enter(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e) { }
        private void textBox7_TextChanged(object sender, EventArgs e) { }
        private void textBox8_TextChanged(object sender, EventArgs e) { }
        private void pictureBox4_Click_1(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e) { }
        private void textBox9_TextChanged(object sender, EventArgs e) { }
        private void textBox10_TextChanged(object sender, EventArgs e) { }
        private void pictureBox5_Click(object sender, EventArgs e) { }
        private void groupBox9_Enter(object sender, EventArgs e) { }
        private void button9_Click(object sender, EventArgs e) { }
        private void numericUpDown9_ValueChanged(object sender, EventArgs e) { }
        private void textBox17_TextChanged(object sender, EventArgs e) { }
        private void textBox18_TextChanged(object sender, EventArgs e) { }
        private void pictureBox9_Click(object sender, EventArgs e) { }
        private void groupBox11_Enter(object sender, EventArgs e) { }
        private void button11_Click(object sender, EventArgs e) { }
        private void numericUpDown11_ValueChanged(object sender, EventArgs e) { }
        private void textBox21_TextChanged(object sender, EventArgs e) { }
        private void textBox22_TextChanged(object sender, EventArgs e) { }
        private void pictureBox11_Click(object sender, EventArgs e) { }
        private void groupBox10_Enter(object sender, EventArgs e) { }
        private void button10_Click(object sender, EventArgs e) { }
        private void numericUpDown10_ValueChanged(object sender, EventArgs e) { }
        private void textBox19_TextChanged(object sender, EventArgs e) { }
        private void textBox20_TextChanged(object sender, EventArgs e) { }
        private void pictureBox10_Click(object sender, EventArgs e) { }
        private void groupBox8_Enter(object sender, EventArgs e) { }
        private void button8_Click(object sender, EventArgs e) { }
        private void numericUpDown8_ValueChanged(object sender, EventArgs e) { }
        private void textBox15_TextChanged(object sender, EventArgs e) { }
        private void textBox16_TextChanged(object sender, EventArgs e) { }
        private void pictureBox8_Click(object sender, EventArgs e) { }
        private void groupBox7_Enter(object sender, EventArgs e) { }
        private void button7_Click(object sender, EventArgs e) { }
        private void numericUpDown7_ValueChanged(object sender, EventArgs e) { }
        private void textBox13_TextChanged(object sender, EventArgs e) { }
        private void textBox14_TextChanged(object sender, EventArgs e) { }
        private void pictureBox7_Click(object sender, EventArgs e) { }
        private void groupBox6_Enter(object sender, EventArgs e) { }
        private void button6_Click(object sender, EventArgs e) { }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e) { }
        private void textBox11_TextChanged(object sender, EventArgs e) { }
        private void textBox12_TextChanged(object sender, EventArgs e) { }
        private void pictureBox6_Click(object sender, EventArgs e) { }
        private void groupBox24_Enter(object sender, EventArgs e) { }
        private void button24_Click(object sender, EventArgs e) { }
        private void numericUpDown24_ValueChanged(object sender, EventArgs e) { }
        private void textBox47_TextChanged(object sender, EventArgs e) { }
        private void textBox48_TextChanged(object sender, EventArgs e) { }
        private void pictureBox24_Click(object sender, EventArgs e) { }
        private void groupBox23_Enter(object sender, EventArgs e) { }
        private void button23_Click(object sender, EventArgs e) { }
        private void numericUpDown23_ValueChanged(object sender, EventArgs e) { }
        private void textBox45_TextChanged(object sender, EventArgs e) { }
        private void textBox46_TextChanged(object sender, EventArgs e) { }
        private void pictureBox23_Click(object sender, EventArgs e) { }
        private void groupBox22_Enter(object sender, EventArgs e) { }
        private void button22_Click(object sender, EventArgs e) { }
        private void numericUpDown22_ValueChanged(object sender, EventArgs e) { }
        private void textBox43_TextChanged(object sender, EventArgs e) { }
        private void textBox44_TextChanged(object sender, EventArgs e) { }
        private void pictureBox22_Click(object sender, EventArgs e) { }
        private void groupBox21_Enter(object sender, EventArgs e) { }
        private void button21_Click(object sender, EventArgs e) { }
        private void numericUpDown21_ValueChanged(object sender, EventArgs e) { }
        private void textBox41_TextChanged(object sender, EventArgs e) { }
        private void textBox42_TextChanged(object sender, EventArgs e) { }
        private void pictureBox21_Click(object sender, EventArgs e) { }
        private void groupBox20_Enter(object sender, EventArgs e) { }
        private void button20_Click(object sender, EventArgs e) { }
        private void numericUpDown20_ValueChanged(object sender, EventArgs e) { }
        private void textBox39_TextChanged(object sender, EventArgs e) { }
        private void textBox40_TextChanged(object sender, EventArgs e) { }
        private void pictureBox20_Click(object sender, EventArgs e) { }
        private void groupBox19_Enter(object sender, EventArgs e) { }
        private void button19_Click(object sender, EventArgs e) { }
        private void numericUpDown19_ValueChanged(object sender, EventArgs e) { }
        private void textBox37_TextChanged(object sender, EventArgs e) { }
        private void textBox38_TextChanged(object sender, EventArgs e) { }
        private void pictureBox19_Click(object sender, EventArgs e) { }
        private void groupBox18_Enter(object sender, EventArgs e) { }
        private void button18_Click(object sender, EventArgs e) { }
        private void numericUpDown18_ValueChanged(object sender, EventArgs e) { }
        private void textBox35_TextChanged(object sender, EventArgs e) { }
        private void textBox36_TextChanged(object sender, EventArgs e) { }
        private void pictureBox18_Click(object sender, EventArgs e) { }
        private void groupBox17_Enter(object sender, EventArgs e) { }
        private void button17_Click(object sender, EventArgs e) { }
        private void numericUpDown17_ValueChanged(object sender, EventArgs e) { }
        private void textBox33_TextChanged(object sender, EventArgs e) { }
        private void textBox34_TextChanged(object sender, EventArgs e) { }
        private void pictureBox17_Click(object sender, EventArgs e) { }
        private void pictureBox12_Click(object sender, EventArgs e) { }
    }
}
