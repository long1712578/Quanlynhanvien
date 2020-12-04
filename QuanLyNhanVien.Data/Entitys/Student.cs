using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuanLyNhanVien.Data.Entitys
{
    [Table("Students")]
    public class Student
    {
        
        public int id { get; set; }
        [Required]
        public string code { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public string dob { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public string picture { get; set; }
        
    }
}
