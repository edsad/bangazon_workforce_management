using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace workforce_part_2.Models
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ComputerMake { get; set; }
        public string ComputerManufacturer { get; set; }
        public ICollection<EmployeeComputer> EmployeeComputers { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
