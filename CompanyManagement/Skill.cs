using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement
{
    class Skill
    {
        public int Code { get; set; }
        public string Description { get; set; }

        public Skill(int code, string descr)
        {
            Code = code;
            Description = descr;
        }

        public Skill()
        {

        }

        /*public void ShowSkills(List<Skill> l)  voleco usare questo metodo per poter stampare le skills quando richiesto
        {
            foreach(Skill s in l)
            {
                Console.WriteLine($"{s.Description}");
            }
        }*/

    }  
}
