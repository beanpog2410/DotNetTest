using System.ComponentModel.DataAnnotations;

namespace DotNetTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class answer
    {
        public int id { get; set; }
        [Display(Name = "Nội dung")]
        public string content { get; set; }
        [Display(Name = "Đáp án")]
        public byte is_true { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> created_date { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public Nullable<System.DateTime> updated_date { get; set; }
        public Nullable<int> question_id { get; set; }
    
        public virtual question question { get; set; }
    }
}
