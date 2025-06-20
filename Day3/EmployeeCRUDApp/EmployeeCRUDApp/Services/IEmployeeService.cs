using EmployeeCRUDApp.Models;

namespace EmployeeCRUDApp.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task Add(Employee emp);
        Task Update(Employee emp);
        Task Delete(int id);
    }
}
