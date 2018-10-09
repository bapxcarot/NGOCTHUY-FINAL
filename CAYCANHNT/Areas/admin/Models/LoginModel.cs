using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CAYCANHNT.Areas.admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập tên đăng nhập")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string PassWord { set; get; }

        public bool RemenberMe { set; get; }
    }
}