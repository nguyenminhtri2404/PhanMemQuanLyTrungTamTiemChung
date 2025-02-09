namespace GUI
{
    partial class frm_CTKeHoach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CTKeHoach));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.dgv_kehoachtiemchung = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaKeHoach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaVaccine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKeHoach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoMui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianGiuaMui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kehoachtiemchung)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.ForeColor = System.Drawing.Color.DarkBlue;
            this.bunifuLabel1.Location = new System.Drawing.Point(346, 11);
            this.bunifuLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(291, 28);
            this.bunifuLabel1.TabIndex = 0;
            this.bunifuLabel1.Text = "XEM CHI TIẾT KẾ HOẠCH";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // dgv_kehoachtiemchung
            // 
            this.dgv_kehoachtiemchung.AllowUserToAddRows = false;
            this.dgv_kehoachtiemchung.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_kehoachtiemchung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(158)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(158)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_kehoachtiemchung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_kehoachtiemchung.ColumnHeadersHeight = 20;
            this.dgv_kehoachtiemchung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_kehoachtiemchung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKeHoach,
            this.MaVaccine,
            this.TenKeHoach,
            this.SoMui,
            this.ThoiGianGiuaMui});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_kehoachtiemchung.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_kehoachtiemchung.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_kehoachtiemchung.Location = new System.Drawing.Point(7, 49);
            this.dgv_kehoachtiemchung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_kehoachtiemchung.Name = "dgv_kehoachtiemchung";
            this.dgv_kehoachtiemchung.ReadOnly = true;
            this.dgv_kehoachtiemchung.RowHeadersVisible = false;
            this.dgv_kehoachtiemchung.RowHeadersWidth = 62;
            this.dgv_kehoachtiemchung.RowTemplate.Height = 28;
            this.dgv_kehoachtiemchung.Size = new System.Drawing.Size(965, 313);
            this.dgv_kehoachtiemchung.TabIndex = 1;
            this.dgv_kehoachtiemchung.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_kehoachtiemchung.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_kehoachtiemchung.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_kehoachtiemchung.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_kehoachtiemchung.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_kehoachtiemchung.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_kehoachtiemchung.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_kehoachtiemchung.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_kehoachtiemchung.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_kehoachtiemchung.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_kehoachtiemchung.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_kehoachtiemchung.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_kehoachtiemchung.ThemeStyle.HeaderStyle.Height = 20;
            this.dgv_kehoachtiemchung.ThemeStyle.ReadOnly = true;
            this.dgv_kehoachtiemchung.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_kehoachtiemchung.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_kehoachtiemchung.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_kehoachtiemchung.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_kehoachtiemchung.ThemeStyle.RowsStyle.Height = 28;
            this.dgv_kehoachtiemchung.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_kehoachtiemchung.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_kehoachtiemchung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_kehoachtiemchung_CellClick);
            // 
            // MaKeHoach
            // 
            this.MaKeHoach.DataPropertyName = "MaKeHoach";
            this.MaKeHoach.HeaderText = "Mã kế hoạch";
            this.MaKeHoach.MinimumWidth = 6;
            this.MaKeHoach.Name = "MaKeHoach";
            this.MaKeHoach.ReadOnly = true;
            // 
            // MaVaccine
            // 
            this.MaVaccine.DataPropertyName = "MaVaccine";
            this.MaVaccine.HeaderText = "Mã vaccine";
            this.MaVaccine.MinimumWidth = 6;
            this.MaVaccine.Name = "MaVaccine";
            this.MaVaccine.ReadOnly = true;
            // 
            // TenKeHoach
            // 
            this.TenKeHoach.DataPropertyName = "TenKeHoach";
            this.TenKeHoach.HeaderText = "Tên kế hoạch";
            this.TenKeHoach.MinimumWidth = 6;
            this.TenKeHoach.Name = "TenKeHoach";
            this.TenKeHoach.ReadOnly = true;
            // 
            // SoMui
            // 
            this.SoMui.DataPropertyName = "SoMui";
            this.SoMui.HeaderText = "Số mũi";
            this.SoMui.MinimumWidth = 6;
            this.SoMui.Name = "SoMui";
            this.SoMui.ReadOnly = true;
            // 
            // ThoiGianGiuaMui
            // 
            this.ThoiGianGiuaMui.DataPropertyName = "ThoiGianGiuaMui";
            this.ThoiGianGiuaMui.HeaderText = "Thời gian giữa các mũi";
            this.ThoiGianGiuaMui.MinimumWidth = 6;
            this.ThoiGianGiuaMui.Name = "ThoiGianGiuaMui";
            this.ThoiGianGiuaMui.ReadOnly = true;
            // 
            // frm_CTKeHoach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 360);
            this.Controls.Add(this.dgv_kehoachtiemchung);
            this.Controls.Add(this.bunifuLabel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_CTKeHoach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_CTKeHoach";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kehoachtiemchung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_kehoachtiemchung;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKeHoach;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVaccine;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKeHoach;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoMui;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianGiuaMui;
    }
}