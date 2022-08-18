using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUsineesLogicLayer.Interfaces
{
    public interface IEmployeeReposatory:IGenericReposatory<Employee>
    {
        IEnumerable<Employee> GetEmployeeByDepartmentName(string departmentName);


        Task<IEnumerable<Employee>> SearchEmployee(String Value);
    }
}
