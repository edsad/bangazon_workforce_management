using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace workforce_part_2.Models
{
    public class EmployeeTrainingProgram
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int TrainingId { get; set; }
        public TrainingProgram TrainingProgram { get; set; }

    }
}
