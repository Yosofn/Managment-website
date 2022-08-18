using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUsineesLogicLayer.Interfaces
{
    public interface IGenericReposatory<T>
    {
        public Task < IEnumerable<T>> GetAll();

       Task <T> Get (int ? id);

      Task <int> Update(T T);

        Task<int> Delete(T T);

       Task <int> Add(T T);


    }
}
