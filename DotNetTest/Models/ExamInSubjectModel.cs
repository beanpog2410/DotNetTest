using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetTest.Models
{
    public class ExamInSubjectModel
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public int DO_TIME { get; set; }
        public Nullable<System.DateTime> START_TIME { get; set; }
        public Nullable<System.DateTime> END_TIME { get; set; }
        public string PASS { get; set; }
        public byte ACT { get; set; }
    }
}