using System;
using System.Collections.Generic;

namespace ChryslerWorkplace.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; } // Primary Key
        public string FirstName { get; set; } = null!; // Required, non-nullable
        public string LastName { get; set; } = null!; // Required, non-nullable
        public decimal? Cid { get; set; } // Optional, nullable decimal
        public string? Email { get; set; } // Optional, nullable string
        public string? PhoneNumber { get; set; } // Optional, nullable string
        public int? DepartmentId { get; set; } // Optional, nullable Foreign Key

        public virtual Department? Department { get; set; } // Navigation Property
    }
}
