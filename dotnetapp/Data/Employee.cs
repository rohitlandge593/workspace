using System;
using System.Collections.Generic;

namespace dotnetapp.Data
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeLastName { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Dept? Department { get; set; }
    }
}
