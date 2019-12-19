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
    public partial class frmThemSVVan : DevExpress.XtraEditors.XtraForm
    {
        public frmThemSVVan()
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
            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtMaSV.Text) || string.IsNullOrEmpty(txtVanCD.Text) || string.IsNullOrEmpty(txtVanHD.Text))
            {
                SinhVienServices.ThemSinhVien(txtMaSV.Text, txtHoTen.Text, gioitinh, dtpNgaySinh.Value, "3");
                SinhVienServices.ThemDiemSVVan(float.Parse(txtVanCD.Text), float.Parse(txtVanHD.Text), txtMaSV.Text);
            } 
            MessageBox.Show("Đã cập nhật dữ liệu thành công");
            DialogResult = DialogResult.OK;
        }
    }
}