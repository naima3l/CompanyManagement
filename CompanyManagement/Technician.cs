using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement
{
    class Technician : Worker
    {
        public decimal HourlyWage { get; set; }
        public int WorkHours { get; set; }

        public Technician(string name, string lastname, string cf, SectorEnum sector, List<Skill> skills, decimal hourlyWage, int workHours)
: base(name, lastname, cf, sector, skills)
        {
            HourlyWage = hourlyWage;
            WorkHours = workHours;
        }

        public Technician()
        {

        }
        public override decimal Salary()
        {
            return WorkHours * HourlyWage;
        }    //=> WorkHours * HourlyWage;
       
    }
}
