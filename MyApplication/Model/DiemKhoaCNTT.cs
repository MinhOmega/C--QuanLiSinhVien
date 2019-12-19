using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    public class DiemKhoaCNTT
    {


        [Key]
        public string IDDiem { get; set; }
        public float DiemC { get; set; }
        public float DiemJava { get; set; }
        public string IDSinhVien { get; set; }
        [ForeignKey("IDSinhVien")]
        public SinhViens ID { get; set; }

    }
}
