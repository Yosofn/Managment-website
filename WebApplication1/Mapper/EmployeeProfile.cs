using AutoMapper;
using DAL.Entities;
using PL.Models;

namespace PL.Mapper
{
    public class EmployeeProfile:Profile
    {

        public EmployeeProfile()
        {
            CreateMap<EmployeeModel, Employee>().ReverseMap();
        }
    }
}
