using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace workforce_part_2.Models
{
    public class EmployeeComputer
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ComputerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Computer Computer { get; set; }
        public Employee Employee { get; set; }


    }
}
