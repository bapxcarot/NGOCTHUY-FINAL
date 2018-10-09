using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CAYCANHNT.Models
{
    public class RegisterModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn phải nhập tên đăng nhập")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string PassWord { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("PassWord", ErrorMessage = "Mật khẩu không trùng khớp!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Bạn phải nhập họ và tên")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "bạn phải nhập địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ Email")]
        public string Email { get; set; }

        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Liên kết")]
        public string Link { get; set; }
    }
}