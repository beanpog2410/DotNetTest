﻿using System.ComponentModel.DataAnnotations;

namespace DotNetTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public question()
        {
            this.answers = new HashSet<answer>();
        }
    
        public int id { get; set; }
        [Display(Name = "Câu hỏi")]
        public string content { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> created_date { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public Nullable<System.DateTime> updated_date { get; set; }
        public Nullable<int> exam_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<answer> answers { get; set; }
        public virtual exam exam { get; set; }
    }
}
