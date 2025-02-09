using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_KhuyenMai : Form
    {
        KhuyenMaiBUL khuyenMaiBUL;
        List<KhuyenMaiDTO> danhSachKhuyenMai;
        public frm_KhuyenMai()
        {
            InitializeComponent();
            khuyenMaiBUL = new KhuyenMaiBUL();
            loadData();
        }
        public void loadData()
        {
            //dgv_LichChieu.AutoGenerateColumns = false;
            danhSachKhuyenMai = khuyenMaiBUL.getKhuyenMai();
            dgv_KhuyenMai.DataSource = danhSachKhuyenMai;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            frm_ThemKhuyenMai frm = new frm_ThemKhuyenMai();
            frm.Show();
            frm.FormClosed += (s, ev) =>
            {
                loadData();
            };
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (dgv_KhuyenMai.SelectedRows.Count > 0)
            {
                KhuyenMaiDTO selectedKhuyenMai = dgv_KhuyenMai.SelectedRows[0].DataBoundItem as KhuyenMaiDTO;

                frm_SuaKhuyenMai form = new frm_SuaKhuyenMai(selectedKhuyenMai);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Tải lại dữ liệu hiển thị nếu sửa thành công
                    loadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi để sửa!");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dgv_KhuyenMai.SelectedRows.Count > 0)
            {
                // Lấy mã khách hàng từ dòng được chọn trong DataGridView
                string maKhuyenMai = dgv_KhuyenMai.SelectedRows[0].Cells["maKM"].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khuyến mãi này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    bool result = khuyenMaiBUL.XoaKhuyenMai(maKhuyenMai);

                    if (result)
                    {
                        MessageBox.Show("Xóa khuyến mãi thành công.");
                        // Cập nhật lại danh sách khuyến mãi trên DataGridView
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khuyến mãi thất bại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khuyến mãi để xóa.");
            }
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txt_TimKiem.Text.Trim().ToLower();

            if (danhSachKhuyenMai != null)
            {
                List<KhuyenMaiDTO> ketQua = (from km in danhSachKhuyenMai
                                             where km.MaKhuyenMai.ToLower().Contains(tukhoa) ||
                                                   km.TenKhuyenMai.ToLower().Contains(tukhoa) ||
                                                   km.PhanTramKhuyenMai.ToString().Contains(tukhoa)
                                             select km).ToList();

                // Bind the filtered data to the DataGridView
                dgv_KhuyenMai.DataSource = ketQua;
            }
            else
            {
                dgv_KhuyenMai.DataSource = null;
                MessageBox.Show("Danh sách khách hàng đang trống hoặc không thể tìm thấy.");
            }
        }
    }
}
