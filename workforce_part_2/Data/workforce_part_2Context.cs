using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using workforce_part_2.Models;

namespace workforce_part_2.Models
{
    public class workforce_part_2Context : DbContext
    {
        public workforce_part_2Context (DbContextOptions<workforce_part_2Context> options)
            : base(options)
        {
        }

        public DbSet<workforce_part_2.Models.Computer> Computer { get; set; }

        public DbSet<workforce_part_2.Models.Department> Department { get; set; }

        public DbSet<workforce_part_2.Models.Employee> Employee { get; set; }

        public DbSet<workforce_part_2.Models.EmployeeComputer> EmployeeComputer { get; set; }

        public DbSet<workforce_part_2.Models.TrainingProgram> TrainingProgram { get; set; }
    }
}
