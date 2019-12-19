using MyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Controller
{
    public class SinhVienServices
    {
        public static List<SinhViens> GetListSinhVien()
        {
            return new MyApplicationContext().SinhViensDbSet.OrderBy(e => e.IDSinhVien).ToList();
        }
        public static DiemKhoaCNTT getDiemTin(string IDSinhVien)
        {
            return new MyApplicationContext().KhoaTinDbSet.SingleOrDefault(e => e.IDSinhVien.Equals(IDSinhVien));
        }
        public static DiemKhoaVatLy getDiemLy(string IDSinhVien)
        {
            return new MyApplicationContext().KhoaLyDbSet.SingleOrDefault(e => e.IDSinhVien.Equals(IDSinhVien));
        }
        public static DiemKhoaVan getDiemVan(string IDSinhVien)
        {
            return new MyApplicationContext().KhoaVanDbSet.SingleOrDefault(e => e.IDSinhVien.Equals(IDSinhVien));
        }
        public static void ThemSinhVien(string IDSinhVien, string HoTen, int GioiTinh, DateTime NgaySinh, string IDKhoa)
        {
            var db = new MyApplicationContext();
            var cre = db.SinhViensDbSet.Create();
            cre.IDSinhVien = IDSinhVien;
            cre.HoTen = HoTen;
            cre.GioiTinh = GioiTinh;
            cre.NgaySinh = NgaySinh;
            cre.IDKhoa = IDKhoa;
            db.SinhViensDbSet.Add(cre);
            db.SaveChanges();
        }
        public static void ThemDiemSVCNTT(float DiemC, float DiemJava, string IDSinhvien)
        {
            var db = new MyApplicationContext();
            var cre = db.KhoaTinDbSet.Create();
            cre.IDDiem = Guid.NewGuid().ToString();
            cre.DiemC = DiemC;
            cre.DiemJava = DiemJava;
            cre.IDSinhVien = IDSinhvien;
            db.KhoaTinDbSet.Add(cre);
            db.SaveChanges();
        }
        public static void ThemDiemSVLy(float DiemCoHoc, float DiemQuangHoc, string IDSinhvien)
        {
            var db = new MyApplicationContext();
            var cre = db.KhoaLyDbSet.Create();
            cre.IDDiem = Guid.NewGuid().ToString();
            cre.DiemCoHoc = DiemCoHoc;
            cre.DiemQuangHoc = DiemQuangHoc;
            cre.IDSinhVien = IDSinhvien;
            db.KhoaLyDbSet.Add(cre);
            db.SaveChanges();
        }
        public static void ThemDiemSVVan(float DiemVHCD, float DiemVHHD, string IDSinhvien)
        {
            var db = new MyApplicationContext();
            var cre = db.KhoaVanDbSet.Create();
            cre.IDDiem = Guid.NewGuid().ToString();
            cre.DiemVHCD = DiemVHCD;
            cre.DiemVHHD = DiemVHHD;
            cre.IDSinhVien = IDSinhvien;
            db.KhoaVanDbSet.Add(cre);
            db.SaveChanges();
        }
        public static void CapNhatThongTinSV(string IDSinhVien, string HoTen, int GioiTinh, DateTime NgaySinh)
        {
            var db = new MyApplicationContext();
            var result = db.SinhViensDbSet.SingleOrDefault(a => a.IDSinhVien.Equals(IDSinhVien));
            if (result != null)
            {
                result.HoTen = HoTen;
                result.GioiTinh = GioiTinh;
                result.NgaySinh = NgaySinh;
                db.SaveChanges();
            }
        }
        public static void CapNhatDiemSVCNTT(float DiemC, float DiemJava, string IDSinhvien)
        {
            var db = new MyApplicationContext();
            var result = db.KhoaTinDbSet.SingleOrDefault(a => a.IDSinhVien.Equals(IDSinhvien));
            if (result != null)
            {
                result.DiemC = DiemC;
                result.DiemJava = DiemJava;
                db.SaveChanges();
            }
        }
        public static void CapNhatDiemSVLy(float DiemCo, float DiemQuang, string IDSinhvien)
        {
            var db = new MyApplicationContext();
            var result = db.KhoaLyDbSet.SingleOrDefault(a => a.IDSinhVien.Equals(IDSinhvien));
            if (result != null)
            {
                result.DiemCoHoc = DiemCo;
                result.DiemQuangHoc = DiemQuang;
                db.SaveChanges();
            }
        }
        public static void CapNhatDiemSVVan(float DiemVHCD, float DiemVHHD, string IDSinhvien)
        {
            var db = new MyApplicationContext();
            var result = db.KhoaVanDbSet.SingleOrDefault(a => a.IDSinhVien.Equals(IDSinhvien));
            if (result != null)
            {
                result.DiemVHCD = DiemVHCD;
                result.DiemVHHD = DiemVHHD;
                db.SaveChanges();
            }
        }
        public static void XoaSinhVien(string idSinhVien)
        {
            var db = new MyApplicationContext();
            var itemToRemove = db.SinhViensDbSet.SingleOrDefault(x => x.IDSinhVien.Equals(idSinhVien));
            if (itemToRemove != null)
            {
                db.SinhViensDbSet.Remove(itemToRemove);
                db.SaveChanges();
            }
        }
        public static void XoaDiemSVCNTT(string idSinhVien)
        {
            var db = new MyApplicationContext();
            var itemToRemove = db.KhoaTinDbSet.SingleOrDefault(x => x.IDSinhVien.Equals(idSinhVien));
            if (itemToRemove != null)
            {
                db.KhoaTinDbSet.Remove(itemToRemove);
                db.SaveChanges();
            }
        }
        public static void XoaDiemSVLy(string idSinhVien)
        {
            var db = new MyApplicationContext();
            var itemToRemove = db.KhoaLyDbSet.SingleOrDefault(x => x.IDSinhVien.Equals(idSinhVien));
            if (itemToRemove != null)
            {
                db.KhoaLyDbSet.Remove(itemToRemove);
                db.SaveChanges();
            }
        }
        public static void XoaDiemSVVan(string idSinhVien)
        {
            var db = new MyApplicationContext();
            var itemToRemove = db.KhoaVanDbSet.SingleOrDefault(x => x.IDSinhVien.Equals(idSinhVien));
            if (itemToRemove != null)
            {
                db.KhoaVanDbSet.Remove(itemToRemove);
                db.SaveChanges();
            }
        }
    }
}
