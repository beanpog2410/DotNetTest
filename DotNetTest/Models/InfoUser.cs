using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DotNetTest.Models
{
    public class InfoUser
    {
        public string Id { get; set; }
        [Display(Name ="Tài khoản người dùng")]
        public string Email { get; set; }
    }
}