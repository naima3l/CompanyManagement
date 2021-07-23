using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement
{
    class Intern : Worker
    {
        public int Duration { get; set; }
        public Intern(string name, string lastname, string cf, SectorEnum sector, List<Skill> skills, int duration)
: base(name, lastname, cf, sector, skills)
        {
            Duration = duration;
        }

        public Intern()
        {

        }

        public override decimal Salary() => 600;
        
    }
}
