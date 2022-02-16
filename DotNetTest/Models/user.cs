using System.ComponentModel.DataAnnotations;

namespace DotNetTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.exams = new HashSet<exam>();
            this.scores = new HashSet<score>();
        }
    
        public string id { get; set; }
        [Display(Name = "Tên người dùng")]
        public string name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string phone { get; set; }
        [Display(Name = "Ngày sinh")]
        public Nullable<System.DateTime> birthday { get; set; }
        [Display(Name = "Giới tính")]
        public string gender { get; set; }
        [Display(Name = "Mã số sinh viên")]
        public string student_number { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string avatar { get; set; }
        [Display(Name = "Quyền truy cập")]
        public string role_name { get; set; }
        [Display(Name = "Trạng thái mssv")]
        public byte active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<exam> exams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<score> scores { get; set; }
    }
}
