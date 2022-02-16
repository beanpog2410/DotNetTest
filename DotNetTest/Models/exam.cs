using System.ComponentModel.DataAnnotations;

namespace DotNetTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class exam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public exam()
        {
            this.questions = new HashSet<question>();
            this.scores = new HashSet<score>();
        }
    
        public int id { get; set; }
        [Display(Name = "Bài thi")]
        public string name { get; set; }
        [Display(Name = "Thời gian làm bài")]
        public Nullable<int> execution_time { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        public Nullable<System.DateTime> start_time { get; set; }
        [Display(Name = "Thời gian nộp bài")]
        public Nullable<System.DateTime> expire_time { get; set; }
        [Display(Name = "Mật khẩu nhận bài thi")]
        public string password { get; set; }
        [Display(Name = "Trạng thái bài thi")]
        public byte active { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> created_date { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public Nullable<System.DateTime> updated_date { get; set; }
        public Nullable<int> subject_id { get; set; }
        public string users_id { get; set; }
    
        public virtual subject subject { get; set; }
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<question> questions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<score> scores { get; set; }
    }
}
