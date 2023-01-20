using EmployeeData.Interfaces;
using EmployeeData.Models;
using EmployeeData.Models;

namespace EmployeeData.Interfaces
{
    public interface IEmployess
    {
        List<Employee>GetEmployees();
        Employee Get(int id);
        Employee Create(Employee employee);
        Employee Edit(Employee employee);
        Employee Delete(Employee employee);
        
    }
}
