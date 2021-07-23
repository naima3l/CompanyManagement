using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement
{
    class Manager : Worker
    {
        public int OvertimeHours { get; set; }
        public decimal BaseSalary { get; set; }

        public Manager(string name, string lastname, string cf, SectorEnum sector, List<Skill> skills, int overtimeHours, decimal baseSalary)
: base(name, lastname, cf, sector, skills)
        {
            OvertimeHours = overtimeHours ;
            BaseSalary = baseSalary;
        }

        public Manager()
        {

        }
        public override decimal Salary() => BaseSalary + (OvertimeHours * 10);
        
    }
}
