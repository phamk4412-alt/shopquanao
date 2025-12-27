namespace WindowsFormsApp2
{
    partial class SanPham : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btanh = new System.Windows.Forms.Button();
            this.tbsoluong = new System.Windows.Forms.TextBox();
            this.tbma = new System.Windows.Forms.TextBox();
            this.tbgiaban = new System.Windows.Forms.TextBox();
            this.tbsanpham = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btxoa = new System.Windows.Forms.Button();
            this.btsua = new System.Windows.Forms.Button();
            this.btthem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgvsanpham = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // btanh
            // 
            this.btanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.btanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(235)))));
            this.btanh.Location = new System.Drawing.Point(16, 277);
            this.btanh.Margin = new System.Windows.Forms.Padding(4);
            this.btanh.Name = "btanh";
            this.btanh.Size = new System.Drawing.Size(100, 28);
            this.btanh.TabIndex = 11;
            this.btanh.Text = "Tải hình ảnh";
            this.btanh.UseVisualStyleBackColor = false;
            this.btanh.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbsoluong
            // 
            this.tbsoluong.Location = new System.Drawing.Point(603, 226);
            this.tbsoluong.Margin = new System.Windows.Forms.Padding(4);
            this.tbsoluong.Name = "tbsoluong";
            this.tbsoluong.Size = new System.Drawing.Size(284, 22);
            this.tbsoluong.TabIndex = 10;
            // 
            // tbma
            // 
            this.tbma.Location = new System.Drawing.Point(603, 174);
            this.tbma.Margin = new System.Windows.Forms.Padding(4);
            this.tbma.Name = "tbma";
            this.tbma.Size = new System.Drawing.Size(284, 22);
            this.tbma.TabIndex = 9;
            // 
            // tbgiaban
            // 
            this.tbgiaban.Location = new System.Drawing.Point(603, 124);
            this.tbgiaban.Margin = new System.Windows.Forms.Padding(4);
            this.tbgiaban.Name = "tbgiaban";
            this.tbgiaban.Size = new System.Drawing.Size(284, 22);
            this.tbgiaban.TabIndex = 8;
            // 
            // tbsanpham
            // 
            this.tbsanpham.Location = new System.Drawing.Point(603, 23);
            this.tbsanpham.Margin = new System.Windows.Forms.Padding(4);
            this.tbsanpham.Name = "tbsanpham";
            this.tbsanpham.Size = new System.Drawing.Size(284, 22);
            this.tbsanpham.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.btxoa);
            this.groupBox1.Controls.Add(this.btsua);
            this.groupBox1.Controls.Add(this.btthem);
            this.groupBox1.Controls.Add(this.btanh);
            this.groupBox1.Controls.Add(this.tbsoluong);
            this.groupBox1.Controls.Add(this.tbma);
            this.groupBox1.Controls.Add(this.tbgiaban);
            this.groupBox1.Controls.Add(this.tbsanpham);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(235)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 191);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(914, 363);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm Sản Phẩm";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "S",
            "L",
            "X",
            "XL",
            "XXL"});
            this.comboBox1.Location = new System.Drawing.Point(603, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 31;
            // 
            // btxoa
            // 
            this.btxoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.btxoa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.btxoa.FlatAppearance.BorderSize = 3;
            this.btxoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btxoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(235)))));
            this.btxoa.Location = new System.Drawing.Point(760, 294);
            this.btxoa.Margin = new System.Windows.Forms.Padding(4);
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(127, 37);
            this.btxoa.TabIndex = 30;
            this.btxoa.Text = "Xóa";
            this.btxoa.UseVisualStyleBackColor = false;
            this.btxoa.Click += new System.EventHandler(this.btxoa_Click);
            // 
            // btsua
            // 
            this.btsua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.btsua.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.btsua.FlatAppearance.BorderSize = 3;
            this.btsua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btsua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(235)))));
            this.btsua.Location = new System.Drawing.Point(505, 294);
            this.btsua.Margin = new System.Windows.Forms.Padding(4);
            this.btsua.Name = "btsua";
            this.btsua.Size = new System.Drawing.Size(127, 37);
            this.btsua.TabIndex = 29;
            this.btsua.Text = "Sửa ";
            this.btsua.UseVisualStyleBackColor = false;
            this.btsua.Click += new System.EventHandler(this.btsua_Click);
            // 
            // btthem
            // 
            this.btthem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
            this.btthem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.btthem.FlatAppearance.BorderSize = 3;
            this.btthem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btthem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(235)))));
            this.btthem.Location = new System.Drawing.Point(358, 294);
            this.btthem.Margin = new System.Windows.Forms.Padding(4);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(127, 37);
            this.btthem.TabIndex = 28;
            this.btthem.Text = "Thêm";
            this.btthem.UseVisualStyleBackColor = false;
            this.btthem.Click += new System.EventHandler(this.btthem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(235)))));
            this.label2.Location = new System.Drawing.Point(380, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 225);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên sản phẩm:\r\n\r\nKích cỡ:\r\n\r\nGiá bán:\r\n\r\nMã sản phẩm:\r\n\r\nSố lượng sản phẩm:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.pictureBox2.Location = new System.Drawing.Point(16, 23);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(219, 236);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // dgvsanpham
            // 
            this.dgvsanpham.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.dgvsanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsanpham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7});
            this.dgvsanpham.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvsanpham.Location = new System.Drawing.Point(0, 0);
            this.dgvsanpham.Margin = new System.Windows.Forms.Padding(4);
            this.dgvsanpham.Name = "dgvsanpham";
            this.dgvsanpham.RowHeadersWidth = 51;
            this.dgvsanpham.Size = new System.Drawing.Size(914, 197);
            this.dgvsanpham.TabIndex = 7;
            this.dgvsanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 34.8432F;
            this.Column1.HeaderText = "STT";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 233.2708F;
            this.Column2.HeaderText = "Tên sản phẩm";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 335;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 50.22502F;
            this.Column3.HeaderText = "Kích cỡ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 72;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 86.3316F;
            this.Column4.HeaderText = "Giá bán";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 124;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 106.7336F;
            this.Column5.HeaderText = "Mã sản phẩm";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 153;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 88.59577F;
            this.Column7.HeaderText = "Số lượng";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 127;
            // 
            // SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 554);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvsanpham);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SanPham";
            this.Text = "SẢN PHẨM";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsanpham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btanh;
        private System.Windows.Forms.TextBox tbsoluong;
        private System.Windows.Forms.TextBox tbma;
        private System.Windows.Forms.TextBox tbgiaban;
        private System.Windows.Forms.TextBox tbsanpham;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgvsanpham;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btxoa;
        private System.Windows.Forms.Button btsua;
        private System.Windows.Forms.Button btthem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}

