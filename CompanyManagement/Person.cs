using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement
{
    class Person
    {
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CF { get; set; }

        public Person(string name, string lastname, string cf)
        {
            Name = name;
            LastName = lastname;
            CF = cf;
        }

        public Person()
        {

        }
    }
}
