using System;
using System.Collections.Generic;

namespace ChryslerWorkplace.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; } // Primary Key
        public string DepartmentName { get; set; } = null!; // Required, non-nullable
        public string? DepartmentNumber { get; set; } // Optional, nullable string

        public virtual ICollection<Employee> Employees { get; set; } // Navigation Property
    }
}
