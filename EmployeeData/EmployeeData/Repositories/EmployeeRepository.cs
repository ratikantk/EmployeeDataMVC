using EmployeeData.DAL;
using EmployeeData.Interfaces;
using EmployeeData.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace EmployeeData.Repositories
{
    public class EmployeeRepository : IEmployess
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public Employee Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;




            //    _context.Employees.Add(employeeViewModel);
            //    _context.SaveChanges();
            //    return employeeViewModel;
        }

       

        public List<Employee> GetEmployees()
        {
           List<Employee> employeeList = _context.Employees.ToList();
            return employeeList;



            //    var employees = _context.Employees.ToList();
            //    List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            //    if (employees != null)
            //    {

            //        foreach (var employee in employees)
            //        {
            //            var EmployeeViewModel = new EmployeeViewModel()
            //            {
            //                Id = employee.Id,
            //                FirstName = employee.FirstName,
            //                LastName = employee.LastName,
            //                DateOfBirth = employee.DateOfBirth,
            //                Email = employee.Email,
            //                Salary = employee.Salary
            //            };
            //            employeeList.Add(EmployeeViewModel);
            //        }
            //        return employeeList;
            //    }

            //    return employeeList;
        }
        public Employee Get(int id)
        {
           Employee employee= _context.Employees.Where(x => x.Id == id).FirstOrDefault();
            return employee;
        }
        public Employee Edit(Employee employee)
        {
           _context.Employees.Attach(employee);
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            return employee;

        }

        public Employee Delete(Employee employee)
        {
            _context.Employees.Attach(employee);
            _context.Entry(employee).State = EntityState.Deleted;
            _context.SaveChanges();
            return employee;
        }
    }
}
