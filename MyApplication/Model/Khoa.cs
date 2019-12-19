using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    public class Khoa
    {
        [Key]
        public string IDKhoa { get; set; }
        public string TenKhoa { get; set; }
    }
}
