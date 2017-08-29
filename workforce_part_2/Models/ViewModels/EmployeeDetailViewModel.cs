using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workforce_part_2.Models.ViewModels
{
    public class EmployeeDetailViewModel
    {
        public Employee Employee { get; set; }
        public List<Computer> Computer { get; set; } = new List<Computer>();
        public List<TrainingProgram> TrainingProgram { get; set; } = new List<TrainingProgram>();
    }
}
