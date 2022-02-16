using System.ComponentModel.DataAnnotations;

namespace DotNetTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class score
    {
        public string users_id { get; set; }
        public Nullable<int> exam_id { get; set; }
        [Display(Name = "Điểm")]
        public int scores { get; set; }
        public Nullable<System.DateTime> submited_date { get; set; }
    
        public virtual exam exam { get; set; }
        public virtual user user { get; set; }
    }
}
