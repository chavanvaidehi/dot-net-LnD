using EmployeeCRUDApp.Models;
using EmployeeCRUDApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

       
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        
        public async Task<IActionResult> Index()
        {
            var employees = await _service.GetAll();
            return View(employees);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var emp = await _service.GetById(id);
            return View(emp);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
