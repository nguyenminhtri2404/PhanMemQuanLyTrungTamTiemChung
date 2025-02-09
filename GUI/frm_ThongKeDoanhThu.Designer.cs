namespace GUI
{
    partial class frm_ThongKeDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ThongKeDoanhThu));
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartKhachHang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phuongThucThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_DSHoaDon = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cbo_Thang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbo_Nam = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btn_ThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.bunifuLabel6 = new Bunifu.UI.WinForms.BunifuLabel();
            this.cbo_PhuongThucThanhToan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDoanhThu
            // 
            this.chartDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            chartArea3.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend3);
            this.chartDoanhThu.Location = new System.Drawing.Point(9, 350);
            this.chartDoanhThu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartDoanhThu.Series.Add(series3);
            this.chartDoanhThu.Size = new System.Drawing.Size(825, 451);
            this.chartDoanhThu.TabIndex = 154;
            this.chartDoanhThu.Text = "chart1";
            // 
            // chartKhachHang
            // 
            this.chartKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.chartKhachHang.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartKhachHang.Legends.Add(legend4);
            this.chartKhachHang.Location = new System.Drawing.Point(662, 350);
            this.chartKhachHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartKhachHang.Name = "chartKhachHang";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartKhachHang.Series.Add(series4);
            this.chartKhachHang.Size = new System.Drawing.Size(827, 451);
            this.chartKhachHang.TabIndex = 155;
            this.chartKhachHang.Text = "chart2";
            // 
            // tongTien
            // 
            this.tongTien.DataPropertyName = "tongTien";
            this.tongTien.HeaderText = "Tổng tiền";
            this.tongTien.MinimumWidth = 8;
            this.tongTien.Name = "tongTien";
            this.tongTien.ReadOnly = true;
            // 
            // phuongThucThanhToan
            // 
            this.phuongThucThanhToan.DataPropertyName = "phuongThucThanhToan";
            this.phuongThucThanhToan.HeaderText = "Phương thức thanh toán";
            this.phuongThucThanhToan.MinimumWidth = 8;
            this.phuongThucThanhToan.Name = "phuongThucThanhToan";
            this.phuongThucThanhToan.ReadOnly = true;
            // 
            // hoTen
            // 
            this.hoTen.DataPropertyName = "hoTen";
            this.hoTen.HeaderText = "Tên khách hàng";
            this.hoTen.MinimumWidth = 8;
            this.hoTen.Name = "hoTen";
            this.hoTen.ReadOnly = true;
            // 
            // ngayLap
            // 
            this.ngayLap.DataPropertyName = "ngayLap";
            this.ngayLap.HeaderText = "Ngày lập";
            this.ngayLap.MinimumWidth = 6;
            this.ngayLap.Name = "ngayLap";
            this.ngayLap.ReadOnly = true;
            // 
            // maHoaDon
            // 
            this.maHoaDon.DataPropertyName = "maHoaDon";
            this.maHoaDon.HeaderText = "Mã hóa đơn";
            this.maHoaDon.MinimumWidth = 6;
            this.maHoaDon.Name = "maHoaDon";
            this.maHoaDon.ReadOnly = true;
            // 
            // dgv_DSHoaDon
            // 
            this.dgv_DSHoaDon.AllowUserToAddRows = false;
            this.dgv_DSHoaDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgv_DSHoaDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_DSHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(158)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(158)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DSHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_DSHoaDon.ColumnHeadersHeight = 18;
            this.dgv_DSHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_DSHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maHoaDon,
            this.ngayLap,
            this.hoTen,
            this.phuongThucThanhToan,
            this.tongTien});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DSHoaDon.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_DSHoaDon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_DSHoaDon.Location = new System.Drawing.Point(9, 119);
            this.dgv_DSHoaDon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_DSHoaDon.Name = "dgv_DSHoaDon";
            this.dgv_DSHoaDon.ReadOnly = true;
            this.dgv_DSHoaDon.RowHeadersVisible = false;
            this.dgv_DSHoaDon.RowHeadersWidth = 51;
            this.dgv_DSHoaDon.RowTemplate.Height = 24;
            this.dgv_DSHoaDon.Size = new System.Drawing.Size(1479, 209);
            this.dgv_DSHoaDon.TabIndex = 150;
            this.dgv_DSHoaDon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_DSHoaDon.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_DSHoaDon.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_DSHoaDon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_DSHoaDon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_DSHoaDon.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_DSHoaDon.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_DSHoaDon.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_DSHoaDon.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_DSHoaDon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dgv_DSHoaDon.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_DSHoaDon.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_DSHoaDon.ThemeStyle.HeaderStyle.Height = 18;
            this.dgv_DSHoaDon.ThemeStyle.ReadOnly = true;
            this.dgv_DSHoaDon.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_DSHoaDon.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_DSHoaDon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dgv_DSHoaDon.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_DSHoaDon.ThemeStyle.RowsStyle.Height = 24;
            this.dgv_DSHoaDon.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_DSHoaDon.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // cbo_Thang
            // 
            this.cbo_Thang.BackColor = System.Drawing.Color.Transparent;
            this.cbo_Thang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Thang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Thang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_Thang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_Thang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_Thang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbo_Thang.ItemHeight = 30;
            this.cbo_Thang.Location = new System.Drawing.Point(332, 48);
            this.cbo_Thang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_Thang.Name = "cbo_Thang";
            this.cbo_Thang.Size = new System.Drawing.Size(219, 36);
            this.cbo_Thang.TabIndex = 151;
            this.cbo_Thang.SelectedIndexChanged += new System.EventHandler(this.cbo_Thang_SelectedIndexChanged);
            // 
            // cbo_Nam
            // 
            this.cbo_Nam.BackColor = System.Drawing.Color.Transparent;
            this.cbo_Nam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Nam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Nam.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_Nam.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_Nam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_Nam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbo_Nam.ItemHeight = 30;
            this.cbo_Nam.Location = new System.Drawing.Point(640, 48);
            this.cbo_Nam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_Nam.Name = "cbo_Nam";
            this.cbo_Nam.Size = new System.Drawing.Size(219, 36);
            this.cbo_Nam.TabIndex = 152;
            this.cbo_Nam.SelectedIndexChanged += new System.EventHandler(this.cbo_Nam_SelectedIndexChanged);
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.BorderRadius = 10;
            this.btn_ThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ThongKe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(87)))), ((int)(((byte)(158)))));
            this.btn_ThongKe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_ThongKe.ForeColor = System.Drawing.Color.White;
            this.btn_ThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThongKe.Image")));
            this.btn_ThongKe.Location = new System.Drawing.Point(924, 39);
            this.btn_ThongKe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Size = new System.Drawing.Size(156, 54);
            this.btn_ThongKe.TabIndex = 153;
            this.btn_ThongKe.Text = "Thống kê";
            this.btn_ThongKe.Click += new System.EventHandler(this.btn_ThongKe_Click);
            // 
            // bunifuLabel6
            // 
            this.bunifuLabel6.AllowParentOverrides = false;
            this.bunifuLabel6.AutoEllipsis = false;
            this.bunifuLabel6.CursorType = null;
            this.bunifuLabel6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel6.Location = new System.Drawing.Point(9, 6);
            this.bunifuLabel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuLabel6.Name = "bunifuLabel6";
            this.bunifuLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel6.Size = new System.Drawing.Size(286, 32);
            this.bunifuLabel6.TabIndex = 146;
            this.bunifuLabel6.Text = "Phương thức thanh toán:";
            this.bunifuLabel6.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel6.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // cbo_PhuongThucThanhToan
            // 
            this.cbo_PhuongThucThanhToan.BackColor = System.Drawing.Color.Transparent;
            this.cbo_PhuongThucThanhToan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_PhuongThucThanhToan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_PhuongThucThanhToan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_PhuongThucThanhToan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_PhuongThucThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_PhuongThucThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbo_PhuongThucThanhToan.ItemHeight = 30;
            this.cbo_PhuongThucThanhToan.Location = new System.Drawing.Point(9, 45);
            this.cbo_PhuongThucThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_PhuongThucThanhToan.Name = "cbo_PhuongThucThanhToan";
            this.cbo_PhuongThucThanhToan.Size = new System.Drawing.Size(219, 36);
            this.cbo_PhuongThucThanhToan.TabIndex = 147;
            this.cbo_PhuongThucThanhToan.SelectedIndexChanged += new System.EventHandler(this.cbo_PhuongThucThanhToan_SelectedIndexChanged);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.Location = new System.Drawing.Point(332, 6);
            this.bunifuLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(78, 32);
            this.bunifuLabel1.TabIndex = 148;
            this.bunifuLabel1.Text = "Tháng:";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AllowParentOverrides = false;
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel2.Location = new System.Drawing.Point(640, 6);
            this.bunifuLabel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(61, 32);
            this.bunifuLabel2.TabIndex = 149;
            this.bunifuLabel2.Text = "Năm:";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(87)))), ((int)(((byte)(158)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1133, 39);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(156, 54);
            this.guna2Button1.TabIndex = 156;
            this.guna2Button1.Text = "Report";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // frm_ThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 816);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.chartKhachHang);
            this.Controls.Add(this.chartDoanhThu);
            this.Controls.Add(this.dgv_DSHoaDon);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.cbo_PhuongThucThanhToan);
            this.Controls.Add(this.bunifuLabel6);
            this.Controls.Add(this.btn_ThongKe);
            this.Controls.Add(this.cbo_Nam);
            this.Controls.Add(this.cbo_Thang);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_ThongKeDoanhThu";
            this.Text = "frm_ThongKeDoanhThu";
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn phuongThucThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHoaDon;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_DSHoaDon;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_Thang;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_Nam;
        private Guna.UI2.WinForms.Guna2Button btn_ThongKe;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel6;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_PhuongThucThanhToan;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}