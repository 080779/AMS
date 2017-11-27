using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SYS.AdminWeb.Models.TestModel
{
    public class TestModel
    {
        [Required(ErrorMessage ="用户名不能为空")]
        [StringLength(20,MinimumLength =2,ErrorMessage ="名字长度在2到20位之间")]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "地址不能为空")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "地址长度在2到20位之间")]
        public string Address { get; set; } 
    }
}