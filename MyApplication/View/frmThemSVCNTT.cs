using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MyApplication.Controller;

namespace MyApplication.View
{
    public partial class frmThemSVCNTT : DevExpress.XtraEditors.XtraForm
    {
        public frmThemSVCNTT()
        {
            InitializeComponent();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            int gioitinh = 0;
            if (chkGioiTinh.Checked)
            {
                gioitinh = 1;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtMaSV.Text) || string.IsNullOrEmpty(txtC.Text) || string.IsNullOrEmpty(txtJava.Text))
            {
                MessageBox.Show("Vui lòng không để trống !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }
            else
            {
                SinhVienServices.ThemSinhVien(txtMaSV.Text, txtHoTen.Text, gioitinh, dtpNgaySinh.Value, "1");
                SinhVienServices.ThemDiemSVCNTT(float.Parse(txtC.Text), float.Parse(txtJava.Text), txtMaSV.Text);
            }
            MessageBox.Show("Đã cập nhật dữ liệu thành công");
            DialogResult = DialogResult.OK;
            
        }
    }
}