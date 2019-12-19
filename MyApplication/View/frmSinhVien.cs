using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using MyApplication.Model;
using MyApplication.Controller;

namespace MyApplication.View
{
    public partial class frmSinhVien : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        List<SinhViens> listSinhVien;
        string idSinhVien;
        string khoa;
        public frmSinhVien()
        {
            InitializeComponent();
            chkListBoxSinhVien.DisplayMember = "HoTen";
            chkListBoxSinhVien.ValueMember = "IDSinhVien";
            HienThiSinhVien();

        }
        private void HienThiSinhVien()
        {
            chkListBoxSinhVien.Items.Clear();
            listSinhVien = SinhVienServices.GetListSinhVien();
            if (listSinhVien == null)
            {
                throw new Exception("Không tồn tại sinh viên");
            }
            else
            {
                foreach (SinhViens sinhvien in listSinhVien)
                {
                    chkListBoxSinhVien.Items.Add(sinhvien);
                }
            }
        }

        private void chkListBoxSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            idSinhVien = chkListBoxSinhVien.SelectedItem.ToString();
            foreach (SinhViens sinhvien in listSinhVien)
            {
                if (sinhvien.IDSinhVien.Equals(chkListBoxSinhVien.SelectedItem.ToString()))
                {
                    txtHoTen.Text = sinhvien.HoTen;
                    ckbGioiTinh.Checked = (sinhvien.GioiTinh == 1);
                    dtpNgaySinh.Value = sinhvien.NgaySinh;
                    khoa = sinhvien.IDKhoa;
                    if (sinhvien.IDKhoa.Equals("1"))
                    {
                        DiemKhoaCNTT tin = SinhVienServices.getDiemTin(idSinhVien);
                        tcHocTap.SelectedTab = tpCNTT;
                        tpCNTT.Enabled = true;
                        tpVan.Enabled = false;
                        tpVan.Visible = false;
                        tpVatLy.Enabled = false;
                        tpVatLy.Visible = false;
                        txtC.Text = tin.DiemC.ToString();
                        txtJava.Text = tin.DiemJava.ToString();
                        lblDTB.Text = ((tin.DiemC + tin.DiemJava) / 2).ToString();
                    }
                    else if (sinhvien.IDKhoa.Equals("2"))
                    {
                        DiemKhoaVatLy ly = SinhVienServices.getDiemLy(idSinhVien);
                        tcHocTap.SelectedTab = tpVatLy;
                        tpVatLy.Enabled = true;
                        tpCNTT.Enabled = false;
                        tpCNTT.Visible = false;
                        tpVan.Enabled = false;
                        tpVan.Visible = false;
                        txtCoHoc.Text = ly.DiemCoHoc.ToString();
                        txtQuangHoc.Text = ly.DiemQuangHoc.ToString();
                        lblDTB.Text = ((ly.DiemCoHoc + ly.DiemQuangHoc) / 2).ToString();

                    }
                    else
                    {
                        DiemKhoaVan van = SinhVienServices.getDiemVan(idSinhVien);
                        tcHocTap.SelectedTab = tpVan;
                        tpVan.Enabled = true;
                        tpCNTT.Enabled = false;
                        tpCNTT.Visible = false;
                        tpVatLy.Enabled = false;
                        tpVatLy.Visible = false;
                        txtVanHocCD.Text = van.DiemVHCD.ToString();
                        txtVanHocHD.Text = van.DiemVHHD.ToString();
                        lblDTB.Text = ((van.DiemVHCD + van.DiemVHHD) / 2).ToString();
                    }
                }
            }
        }

        private void addSVCNTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmThemSVCNTT();
            if (f.ShowDialog() == DialogResult.OK)
            {
                HienThiSinhVien();
            }
        }
        private void btnCapNhat_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rs = MessageBox.Show("Bạn có chắc là muốn cập nhật sinh viên này không?",
               "Thông báo"
               , MessageBoxButtons.OKCancel,
               MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {
                int gt = 0;
                if (ckbGioiTinh.Checked)
                {
                    gt = 1;
                }
                SinhVienServices.CapNhatThongTinSV(idSinhVien, txtHoTen.Text, gt, dtpNgaySinh.Value);
                if (khoa.Equals("1"))
                {
                    SinhVienServices.CapNhatDiemSVCNTT(float.Parse(txtC.Text), float.Parse(txtJava.Text), idSinhVien);
                    lblDTB.Text = ((float.Parse(txtC.Text) + float.Parse(txtJava.Text)) / 2).ToString();
                }
                else if (khoa.Equals("2"))
                {
                    SinhVienServices.CapNhatDiemSVLy(float.Parse(txtCoHoc.Text), float.Parse(txtQuangHoc.Text), idSinhVien);
                    lblDTB.Text = ((float.Parse(txtCoHoc.Text) + float.Parse(txtQuangHoc.Text)) / 2).ToString();

                }
                else
                {
                    SinhVienServices.CapNhatDiemSVVan(float.Parse(txtVanHocCD.Text), float.Parse(txtVanHocHD.Text), idSinhVien);
                    lblDTB.Text = ((float.Parse(txtVanHocCD.Text) + float.Parse(txtVanHocHD.Text)) / 2).ToString();
                }

                HienThiSinhVien();
                MessageBox.Show("Bạn đã cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Bạn đã không cập nhật");
            }
        }

        private void addSVVL_ItemClick(object sender, EventArgs e)
        {
            var f = new frmThemSVLy();
            if (f.ShowDialog() == DialogResult.OK)
            {
                HienThiSinhVien();

            }
        }

        private void addSVVan_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new frmThemSVVan();
            if (f.ShowDialog() == DialogResult.OK)
            {
                HienThiSinhVien();

            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<String> ListIdSVXoa = new List<string>();
            var rs = MessageBox.Show("Bạn có chắc là muốn xóa sinh viên này không?",
                "Thông báo"
                , MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {


                for (int i = chkListBoxSinhVien.Items.Count - 1; i >= 0; i--)
                {
                    if (chkListBoxSinhVien.GetItemChecked(i))
                    {
                        ListIdSVXoa.Add(chkListBoxSinhVien.Items[i].ToString());


                    }
                }

                foreach (SinhViens sinhvien in listSinhVien)
                {
                    foreach (String t in ListIdSVXoa)
                    {
                        if (sinhvien.IDSinhVien.Equals(t))
                        {
                            if (sinhvien.IDKhoa.Equals("1"))
                            {
                                SinhVienServices.XoaDiemSVCNTT(sinhvien.IDSinhVien);
                            }
                            else if (sinhvien.IDKhoa.Equals("2"))
                            {
                                SinhVienServices.XoaDiemSVLy(sinhvien.IDSinhVien);
                            }
                            else
                            {
                                SinhVienServices.XoaDiemSVVan(sinhvien.IDSinhVien);
                            }
                            SinhVienServices.XoaSinhVien(sinhvien.IDSinhVien);
                        }
                    }

                }
                HienThiSinhVien();
                MessageBox.Show("Bạn đã xóa thành công");
            }
            else
            {
                MessageBox.Show("Bạn đã không xóa");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text) == false)
            {
                chkListBoxSinhVien.Items.Clear();
                foreach (SinhViens sinhvien in listSinhVien)
                {
                    if (sinhvien.HoTen.ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        chkListBoxSinhVien.Items.Add(sinhvien);
                    }

                }   
            }
            else if (txtSearch.Text.Equals(""))
            {
                chkListBoxSinhVien.Items.Clear();
                foreach (SinhViens sinhvien in listSinhVien)
                {
                    chkListBoxSinhVien.Items.Add(sinhvien);
                }
            }
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }
    }
}