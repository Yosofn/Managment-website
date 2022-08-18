using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Email
    {
        public int Id { get; set; }
          public string Title { get; set; }

        public String  Body { get; set; }

        public String To { get; set; } 

    }
}
