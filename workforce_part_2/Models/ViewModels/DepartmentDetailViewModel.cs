using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workforce_part_2.Models.ViewModels
{
    public class DepartmentDetailViewModel
    {
        public Department Department { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
