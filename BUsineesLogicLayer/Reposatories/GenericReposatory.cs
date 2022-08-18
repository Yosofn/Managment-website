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
    public class GenericReposatory<T> : IGenericReposatory<T> where T : class
    {
        private ProjectContext context;
        public GenericReposatory(ProjectContext context)
        {
            this.context = context;
        }


        public async Task<int> Add(T t)
        {
            context.Set<T>().Add(t);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(T t)
        {
            context.Set<T>().Remove(t);
            return await context.SaveChangesAsync();
        }

        public async Task<T> Get(int? id)
        
        =>  await context.Set<T>().FindAsync(id);



        public async Task<IEnumerable<T>> GetAll()
        {

            if (typeof(T) == typeof(Employee))
                return (IEnumerable<T>) await context.Set<Employee>().Include(E => E.Department).ToListAsync();
            return await context.Set<T>().ToListAsync();
        }
        public async Task<int>  Update(T t)
        {
            context.Set<T>().Update(t);
            return await context.SaveChangesAsync();
        }
    }
}
