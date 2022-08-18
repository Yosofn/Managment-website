using BUsineesLogicLayer.Interfaces;
using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUsineesLogicLayer.Reposatories
{
    public class DepartmentReposatory :GenericReposatory<Department>, IDepartmentReposatory
    {
        public DepartmentReposatory(ProjectContext context):base(context)
        {
                
        }
    }
}
