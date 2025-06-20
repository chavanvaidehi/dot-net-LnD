using EmployeeCRUDApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUDApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task Add(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee emp)
        {
            _context.Employees.Update(emp);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
    }
}
