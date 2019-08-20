using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_System.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string StudentGuid { get; set; }
        public bool Active { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime modifiedOn { get; set; }
        public DateTime deletedOn { get; set; }
        public bool isDeleted { get; set; }
        public int BranchId { get; set; }
    }
}