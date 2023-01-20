using AutoMapper;
using EmployeeData.Models;

namespace EmployeeData.AutoMapperConfig
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
