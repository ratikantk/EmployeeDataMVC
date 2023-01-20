using AutoMapper;
using EmployeeData.DAL;
using EmployeeData.Interfaces;
using EmployeeData.Models;

using Microsoft.AspNetCore.Mvc;

namespace EmployeeData.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployess _repo;

        public EmployeeController(IMapper mapper, IEmployess repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employees =  _repo.GetEmployees();
            var employeeList = _mapper.Map<List<EmployeeViewModel>>(employees);

            // List<Employee> employeeList = _repo.GetEmployees();//_context.Employees.ToList();
            return View(employeeList);
        }
        public IActionResult GetEmployee(int id)
        {
            var employees =_repo.Get(id);
            var employeeList = _mapper.Map<EmployeeViewModel>(employees);
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create ( EmployeeViewModel employeeViewModel)
        {
            try
            {
                var employee= _mapper.Map<Employee>(employeeViewModel);
                _repo.Create(employee);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                TempData["errorMessage"] = err.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var employees = _repo.Get(Id);
            var employeeList = _mapper.Map<EmployeeViewModel>(employees);
            return View(employeeList);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel employeeViewModel)
        {

            int empId = employeeViewModel.Id;
            var employeeList= _repo.Get(empId);
            _mapper.Map(employeeViewModel, employeeList);
            try
            {
                _repo.Edit(employeeList);
                return RedirectToAction("Index");               
            }
            catch (Exception err)
            {
                TempData["errorMessage"] = err.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Employee employee = _repo.Get(Id);
            return View(employee);

        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            try
            {
                employee = _repo.Delete(employee);
                return RedirectToAction("Index");
                
            }
            catch (Exception err)
            {
                TempData["errorMessage"] = err.Message;
                return View();                
            }            
        }
    }
}
