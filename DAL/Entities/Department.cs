using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }

        public DateTime DateOfCreation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }=new HashSet<Employee>();
        

    }
}
