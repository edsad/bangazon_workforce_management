using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using workforce_part_2.Models;

namespace workforce_part_2.Migrations
{
    [DbContext(typeof(workforce_part_2Context))]
    [Migration("20170829175143_esinitial")]
    partial class esinitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("workforce_part_2.Models.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComputerMake")
                        .IsRequired();

                    b.Property<string>("ComputerManufacturer");

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("Id");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("workforce_part_2.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName");

                    b.Property<string>("EmployeeName");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("workforce_part_2.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("workforce_part_2.Models.EmployeeComputer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComputerId");

                    b.Property<int?>("ComputerId1");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId1");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeComputer");
                });

            modelBuilder.Entity("workforce_part_2.Models.EmployeeTrainingProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<int>("TrainingId");

                    b.Property<int?>("TrainingProgramId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("EmployeeTrainingProgram");
                });

            modelBuilder.Entity("workforce_part_2.Models.TrainingProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("MaxNumber");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("TrainingProgramName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("TrainingProgram");
                });

            modelBuilder.Entity("workforce_part_2.Models.Employee", b =>
                {
                    b.HasOne("workforce_part_2.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("workforce_part_2.Models.EmployeeComputer", b =>
                {
                    b.HasOne("workforce_part_2.Models.Computer", "Computer")
                        .WithMany("EmployeeComputers")
                        .HasForeignKey("ComputerId1");

                    b.HasOne("workforce_part_2.Models.Employee", "Employee")
                        .WithMany("EmployeeComputers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("workforce_part_2.Models.EmployeeTrainingProgram", b =>
                {
                    b.HasOne("workforce_part_2.Models.Employee", "Employee")
                        .WithMany("EmployeeTrainingPrograms")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("workforce_part_2.Models.TrainingProgram", "TrainingProgram")
                        .WithMany("EmployeeTrainingProgram")
                        .HasForeignKey("TrainingProgramId");
                });
        }
    }
}
