using System;
using System.Collections.Generic;

namespace dotnetapp.Models
{
    public partial class Department
    {
        public Dept()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
