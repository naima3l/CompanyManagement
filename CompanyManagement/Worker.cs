using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement
{
    abstract class Worker : Person
    {
        public SectorEnum Sector { get; set; }
        public List<Skill> Skills { get; set; }  = new List<Skill>();

        public Worker(string name, string lastname, string cf, SectorEnum sector, List<Skill> skills)
: base(name, lastname, cf)
        {
            Sector = sector;
            Skills = skills;
        }

        public Worker()
        {

        }

        public void RemoveWorker(List<Worker>w)
        {
            foreach(Worker w1 in w)
            {
                w.Remove(w1);
            }
        }
        public abstract decimal Salary();
        
    }

    public enum SectorEnum
    {
        Vendite,
        Amministrazione,
        Sviluppo
    }
}
