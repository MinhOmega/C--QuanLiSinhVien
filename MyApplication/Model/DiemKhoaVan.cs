using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    public class DiemKhoaVan
    {
        [Key]
        public string IDDiem { get; set; }
        public float DiemVHCD { get; set; }
        public float DiemVHHD { get; set; }
        public string IDSinhVien { get; set; }
        [ForeignKey("IDSinhVien")]
        public SinhViens ID { get; set; }
    }
}
