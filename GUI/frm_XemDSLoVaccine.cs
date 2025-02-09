using BUL;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_XemDSLoVaccine : Form
    {
        LoVaccineBUL loVaccineBUL;
        DataTable dtLoVaccine;

        public frm_XemDSLoVaccine()
        {
            InitializeComponent();
            loVaccineBUL = new LoVaccineBUL();
            loadData();
            txt_TimKiem.TextChanged += new EventHandler(txt_TimKiem_TextChanged);
            //Formart cột gia nhập
            dgv_DSLoVaccine.Columns["giaNhap"].DefaultCellStyle.Format = "N0";
            //Formart cột gias bán
            dgv_DSLoVaccine.Columns["giaBan"].DefaultCellStyle.Format = "N0";
        }

        public void loadData()
        {
            dgv_DSLoVaccine.AutoGenerateColumns = false;
            dtLoVaccine = loVaccineBUL.layTatCaLoVaccine();
            dgv_DSLoVaccine.DataSource = dtLoVaccine;
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string filterExpression = string.Format("maLo LIKE '%{0}%' OR tenVaccine LIKE '%{0}%' OR donViTinh Like '%{0}%'", txt_TimKiem.Text);
            (dgv_DSLoVaccine.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
        }
    }
}
