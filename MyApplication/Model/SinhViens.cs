using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    public class SinhViens
    {
        [Key]
        public string IDSinhVien { get; set; }
        public string HoTen { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string IDKhoa { get; set; }
        [ForeignKey("IDKhoa")]
        public Khoa khoa { get; set; }
        public override string ToString()
        {
            return IDSinhVien;
        }
    }
}
