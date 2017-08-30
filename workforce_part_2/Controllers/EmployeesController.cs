using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using workforce_part_2.Models;
using workforce_part_2.Models.ViewModels;

namespace workforce_part_2.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly workforce_part_2Context _context;

        public EmployeesController(workforce_part_2Context context)
        {
            _context = context;    
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var workforce_part_2Context = _context.Employee.Include(e => e.Department);
            return View(await workforce_part_2Context.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.EmployeeTrainingPrograms)
                .Include(e => e.EmployeeComputers)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DepartmentId,StartDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Id", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Id", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeEditViewModel viewModel)
        {
            if (id != viewModel.employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (int ProgramId in viewModel.EmployeeTrainingProgram)
                    {
                        EmployeeTrainingProgram EmployeeTrainingProgram = new EmployeeTrainingProgram()
                        {
                            EmployeeId = viewModel.employee.Id,
                            TrainingId = _context.TrainingProgram.SingleOrDefault(t => t.Id == ProgramId).Id
                        };
                    
                    _context.Add(EmployeeTrainingProgram);

                }
                    _context.Update(viewModel.employee);

                    foreach (int ComputerId in viewModel.Computer)
                    {
                        EmployeeComputer Computer = new EmployeeComputer()
                        {
                            EmployeeId = viewModel.employee.Id,
                            ComputerId = _context.Computer.SingleOrDefault(c => c.Id == ComputerId).Id
                        };
                        _context.Add(Computer);
                        await _context.SaveChangesAsync();
                    }
                    _context.Update(viewModel.employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(viewModel.employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Departmentname", viewModel.employee.DepartmentId);
            return View(viewModel);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.Id == id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
