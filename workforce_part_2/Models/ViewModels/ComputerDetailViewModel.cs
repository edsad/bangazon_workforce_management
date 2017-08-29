using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workforce_part_2.Models.ViewModels
{
    public class ComputerDetailViewModel
    {
        public Computer Computer { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
