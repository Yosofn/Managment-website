using BUsineesLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUsineesLogicLayer.Reposatories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDepartmentReposatory DepartmentReposatory { get; set; }
        public IEmployeeReposatory EmployeeReposatory { get; set; }

        public UnitOfWork(IEmployeeReposatory employeeReposatory , IDepartmentReposatory departmentReposatory)
        {

            DepartmentReposatory = departmentReposatory;
            EmployeeReposatory = employeeReposatory;    

        }    }
}
