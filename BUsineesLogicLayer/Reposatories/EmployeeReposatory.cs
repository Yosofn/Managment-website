using BUsineesLogicLayer.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUsineesLogicLayer.Reposatories
{
    public class EmployeeReposatory :GenericReposatory<Employee>,IEmployeeReposatory
    {
        public EmployeeReposatory(ProjectContext context):base (context)

        {
            Context = context;
        }

        public ProjectContext Context { get; }

        public IEnumerable<Employee> GetEmployeeByDepartmentName(string departmentName)
        {
            throw new NotImplementedException();
        }

        public async Task <IEnumerable<Employee>> SearchEmployee(string Value)
        
         =>await Context.Employees.Where(E => E.Name.Contains(Value)).ToListAsync();
        
    }
}
