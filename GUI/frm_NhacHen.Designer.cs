namespace GUI
{
    partial class frm_NhacHen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NhacHen));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.dt_NgayHen = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.cb_ChonTatCa = new System.Windows.Forms.CheckBox();
            this.txt_TimKiem = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btn_NhacHen = new Guna.UI2.WinForms.Guna2Button();
            this.gb_NhacHen = new System.Windows.Forms.GroupBox();
            this.dgv_LichTiemChung = new Guna.UI2.WinForms.Guna2DataGridView();
            this.maKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maLichTiemChung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoTenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayHen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenVaccine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thaoTac = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gb_NhacHen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LichTiemChung)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(87)))), ((int)(((byte)(158)))));
            this.bunifuLabel1.Location = new System.Drawing.Point(437, 12);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(283, 28);
            this.bunifuLabel1.TabIndex = 147;
            this.bunifuLabel1.Text = "NHẮC HẸN TIÊM CHỦNG";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AllowParentOverrides = false;
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.CursorType = null;
            this.bunifuLabel3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel3.Location = new System.Drawing.Point(15, 77);
            this.bunifuLabel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(109, 22);
            this.bunifuLabel3.TabIndex = 150;
            this.bunifuLabel3.Text = "Khách hàng";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // dt_NgayHen
            // 
            this.dt_NgayHen.BackColor = System.Drawing.Color.Transparent;
            this.dt_NgayHen.BorderColor = System.Drawing.Color.Silver;
            this.dt_NgayHen.BorderRadius = 1;
            this.dt_NgayHen.Color = System.Drawing.Color.Silver;
            this.dt_NgayHen.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dt_NgayHen.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dt_NgayHen.DisabledColor = System.Drawing.Color.Gray;
            this.dt_NgayHen.DisplayWeekNumbers = false;
            this.dt_NgayHen.DPHeight = 0;
            this.dt_NgayHen.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dt_NgayHen.FillDatePicker = false;
            this.dt_NgayHen.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dt_NgayHen.ForeColor = System.Drawing.Color.Black;
            this.dt_NgayHen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_NgayHen.Icon = ((System.Drawing.Image)(resources.GetObject("dt_NgayHen.Icon")));
            this.dt_NgayHen.IconColor = System.Drawing.Color.Gray;
            this.dt_NgayHen.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dt_NgayHen.LeftTextMargin = 5;
            this.dt_NgayHen.Location = new System.Drawing.Point(525, 65);
            this.dt_NgayHen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dt_NgayHen.MinimumSize = new System.Drawing.Size(4, 32);
            this.dt_NgayHen.Name = "dt_NgayHen";
            this.dt_NgayHen.Size = new System.Drawing.Size(272, 34);
            this.dt_NgayHen.TabIndex = 149;
            this.dt_NgayHen.ValueChanged += new System.EventHandler(this.dt_NgayHen_ValueChanged);
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AllowParentOverrides = false;
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel2.Location = new System.Drawing.Point(417, 77);
            this.bunifuLabel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(86, 22);
            this.bunifuLabel2.TabIndex = 148;
            this.bunifuLabel2.Text = "Ngày hẹn";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // cb_ChonTatCa
            // 
            this.cb_ChonTatCa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_ChonTatCa.AutoSize = true;
            this.cb_ChonTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ChonTatCa.Location = new System.Drawing.Point(1031, 120);
            this.cb_ChonTatCa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_ChonTatCa.Name = "cb_ChonTatCa";
            this.cb_ChonTatCa.Size = new System.Drawing.Size(89, 29);
            this.cb_ChonTatCa.TabIndex = 154;
            this.cb_ChonTatCa.Text = "Tất cả";
            this.cb_ChonTatCa.UseVisualStyleBackColor = true;
            this.cb_ChonTatCa.CheckedChanged += new System.EventHandler(this.cb_ChonTatCa_CheckedChanged);
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.AcceptsReturn = false;
            this.txt_TimKiem.AcceptsTab = false;
            this.txt_TimKiem.AnimationSpeed = 200;
            this.txt_TimKiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_TimKiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_TimKiem.AutoSizeHeight = true;
            this.txt_TimKiem.BackColor = System.Drawing.Color.Transparent;
            this.txt_TimKiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_TimKiem.BackgroundImage")));
            this.txt_TimKiem.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txt_TimKiem.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txt_TimKiem.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txt_TimKiem.BorderColorIdle = System.Drawing.Color.Silver;
            this.txt_TimKiem.BorderRadius = 1;
            this.txt_TimKiem.BorderThickness = 1;
            this.txt_TimKiem.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txt_TimKiem.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_TimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TimKiem.DefaultFont = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_TimKiem.DefaultText = "";
            this.txt_TimKiem.FillColor = System.Drawing.Color.White;
            this.txt_TimKiem.HideSelection = true;
            this.txt_TimKiem.IconLeft = null;
            this.txt_TimKiem.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TimKiem.IconPadding = 10;
            this.txt_TimKiem.IconRight = ((System.Drawing.Image)(resources.GetObject("txt_TimKiem.IconRight")));
            this.txt_TimKiem.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TimKiem.Lines = new string[0];
            this.txt_TimKiem.Location = new System.Drawing.Point(144, 65);
            this.txt_TimKiem.MaxLength = 32767;
            this.txt_TimKiem.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_TimKiem.Modified = false;
            this.txt_TimKiem.Multiline = false;
            this.txt_TimKiem.Name = "txt_TimKiem";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_TimKiem.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txt_TimKiem.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_TimKiem.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_TimKiem.OnIdleState = stateProperties4;
            this.txt_TimKiem.Padding = new System.Windows.Forms.Padding(3);
            this.txt_TimKiem.PasswordChar = '\0';
            this.txt_TimKiem.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txt_TimKiem.PlaceholderText = "";
            this.txt_TimKiem.ReadOnly = false;
            this.txt_TimKiem.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_TimKiem.SelectedText = "";
            this.txt_TimKiem.SelectionLength = 0;
            this.txt_TimKiem.SelectionStart = 0;
            this.txt_TimKiem.ShortcutsEnabled = true;
            this.txt_TimKiem.Size = new System.Drawing.Size(247, 36);
            this.txt_TimKiem.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txt_TimKiem.TabIndex = 153;
            this.txt_TimKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_TimKiem.TextMarginBottom = 0;
            this.txt_TimKiem.TextMarginLeft = 3;
            this.txt_TimKiem.TextMarginTop = 1;
            this.txt_TimKiem.TextPlaceholder = "";
            this.txt_TimKiem.UseSystemPasswordChar = false;
            this.txt_TimKiem.WordWrap = true;
            this.txt_TimKiem.TextChange += new System.EventHandler(this.txt_TimKiem_TextChange);
            // 
            // btn_NhacHen
            // 
            this.btn_NhacHen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NhacHen.BorderRadius = 10;
            this.btn_NhacHen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_NhacHen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_NhacHen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_NhacHen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_NhacHen.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(87)))), ((int)(((byte)(158)))));
            this.btn_NhacHen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_NhacHen.ForeColor = System.Drawing.Color.White;
            this.btn_NhacHen.Image = ((System.Drawing.Image)(resources.GetObject("btn_NhacHen.Image")));
            this.btn_NhacHen.Location = new System.Drawing.Point(994, 507);
            this.btn_NhacHen.Name = "btn_NhacHen";
            this.btn_NhacHen.Size = new System.Drawing.Size(132, 40);
            this.btn_NhacHen.TabIndex = 152;
            this.btn_NhacHen.Text = "Nhắc hẹn";
            this.btn_NhacHen.Click += new System.EventHandler(this.btn_NhacHen_Click);
            // 
            // gb_NhacHen
            // 
            this.gb_NhacHen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_NhacHen.Controls.Add(this.dgv_LichTiemChung);
            this.gb_NhacHen.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_NhacHen.Location = new System.Drawing.Point(15, 153);
            this.gb_NhacHen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_NhacHen.Name = "gb_NhacHen";
            this.gb_NhacHen.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_NhacHen.Size = new System.Drawing.Size(1111, 338);
            this.gb_NhacHen.TabIndex = 151;
            this.gb_NhacHen.TabStop = false;
            this.gb_NhacHen.Text = "Danh sách nhắc hẹn";
            // 
            // dgv_LichTiemChung
            // 
            this.dgv_LichTiemChung.AllowUserToAddRows = false;
            this.dgv_LichTiemChung.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_LichTiemChung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(158)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(158)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_LichTiemChung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_LichTiemChung.ColumnHeadersHeight = 22;
            this.dgv_LichTiemChung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_LichTiemChung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maKhachHang,
            this.maLichTiemChung,
            this.hoTenKhachHang,
            this.ngayHen,
            this.tenVaccine,
            this.mui,
            this.Column3,
            this.thaoTac});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_LichTiemChung.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_LichTiemChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_LichTiemChung.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_LichTiemChung.Location = new System.Drawing.Point(3, 21);
            this.dgv_LichTiemChung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_LichTiemChung.Name = "dgv_LichTiemChung";
            this.dgv_LichTiemChung.ReadOnly = true;
            this.dgv_LichTiemChung.RowHeadersVisible = false;
            this.dgv_LichTiemChung.RowHeadersWidth = 62;
            this.dgv_LichTiemChung.RowTemplate.Height = 28;
            this.dgv_LichTiemChung.Size = new System.Drawing.Size(1105, 315);
            this.dgv_LichTiemChung.TabIndex = 118;
            this.dgv_LichTiemChung.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_LichTiemChung.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_LichTiemChung.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_LichTiemChung.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_LichTiemChung.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_LichTiemChung.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_LichTiemChung.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_LichTiemChung.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_LichTiemChung.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_LichTiemChung.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_LichTiemChung.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_LichTiemChung.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_LichTiemChung.ThemeStyle.HeaderStyle.Height = 22;
            this.dgv_LichTiemChung.ThemeStyle.ReadOnly = true;
            this.dgv_LichTiemChung.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_LichTiemChung.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_LichTiemChung.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_LichTiemChung.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_LichTiemChung.ThemeStyle.RowsStyle.Height = 28;
            this.dgv_LichTiemChung.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_LichTiemChung.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_LichTiemChung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_LichTiemChung_CellClick);
            // 
            // maKhachHang
            // 
            this.maKhachHang.DataPropertyName = "maKhachHang";
            this.maKhachHang.HeaderText = "Mã khách hàng";
            this.maKhachHang.MinimumWidth = 8;
            this.maKhachHang.Name = "maKhachHang";
            this.maKhachHang.ReadOnly = true;
            // 
            // maLichTiemChung
            // 
            this.maLichTiemChung.DataPropertyName = "maLichTiemChung";
            this.maLichTiemChung.HeaderText = "Mã lịch tiêm chủng";
            this.maLichTiemChung.MinimumWidth = 8;
            this.maLichTiemChung.Name = "maLichTiemChung";
            this.maLichTiemChung.ReadOnly = true;
            // 
            // hoTenKhachHang
            // 
            this.hoTenKhachHang.DataPropertyName = "hoTenKhachHang";
            this.hoTenKhachHang.HeaderText = "Tên khách hàng";
            this.hoTenKhachHang.MinimumWidth = 8;
            this.hoTenKhachHang.Name = "hoTenKhachHang";
            this.hoTenKhachHang.ReadOnly = true;
            // 
            // ngayHen
            // 
            this.ngayHen.DataPropertyName = "ngayHen";
            this.ngayHen.HeaderText = "Ngày hẹn";
            this.ngayHen.MinimumWidth = 8;
            this.ngayHen.Name = "ngayHen";
            this.ngayHen.ReadOnly = true;
            // 
            // tenVaccine
            // 
            this.tenVaccine.DataPropertyName = "tenVaccine";
            this.tenVaccine.HeaderText = "Tên vaccine";
            this.tenVaccine.MinimumWidth = 8;
            this.tenVaccine.Name = "tenVaccine";
            this.tenVaccine.ReadOnly = true;
            // 
            // mui
            // 
            this.mui.DataPropertyName = "mui";
            this.mui.HeaderText = "Mũi";
            this.mui.MinimumWidth = 8;
            this.mui.Name = "mui";
            this.mui.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ghiChu";
            this.Column3.HeaderText = "Ghi chú";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // thaoTac
            // 
            this.thaoTac.FalseValue = "false";
            this.thaoTac.HeaderText = "Thao tác";
            this.thaoTac.MinimumWidth = 8;
            this.thaoTac.Name = "thaoTac";
            this.thaoTac.ReadOnly = true;
            this.thaoTac.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.thaoTac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.thaoTac.TrueValue = "true";
            // 
            // frm_NhacHen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 570);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.bunifuLabel3);
            this.Controls.Add(this.dt_NgayHen);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.cb_ChonTatCa);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.btn_NhacHen);
            this.Controls.Add(this.gb_NhacHen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_NhacHen";
            this.Text = "frm_NhacHen";
            this.gb_NhacHen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LichTiemChung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.UI.WinForms.BunifuDatePicker dt_NgayHen;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private System.Windows.Forms.CheckBox cb_ChonTatCa;
        private Bunifu.UI.WinForms.BunifuTextBox txt_TimKiem;
        private Guna.UI2.WinForms.Guna2Button btn_NhacHen;
        private System.Windows.Forms.GroupBox gb_NhacHen;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_LichTiemChung;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLichTiemChung;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoTenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayHen;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenVaccine;
        private System.Windows.Forms.DataGridViewTextBoxColumn mui;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn thaoTac;
    }
}