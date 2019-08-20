using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_System.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime modifiedOn { get; set; }
        public DateTime deletedOn { get; set; }
        public bool isDeleted { get; set; }
    }
}