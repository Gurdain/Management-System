using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management_System.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public int FacultyId { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime modifiedOn { get; set; }
        public DateTime deletedOn { get; set; }
        public bool isDeleted{ get; set; }
    }
}