using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Bạn cần nhập họ tên.")]
        [Column(TypeName = "nvarchar(100)")]
        public string UserFullName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không chính xác.")]
        public string UserEmail { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Bạn cần nhập số điện thoại.")]
        public int UserPhone { get; set; }
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? UserBirthday { get; set; } 
        [Display(Name = "Mật khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Display(Name = "Thời gian tạo")]
        public DateTime? UserCreatedAt { get; set; }


    }
}