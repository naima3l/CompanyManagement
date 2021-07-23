using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement
{
    class Management
    {
        internal static List<Skill> Skills = new List<Skill>
        {
            new Skill{Code = 01, Description = "Leadership" },
            new Skill{Code = 02, Description = "Teamwork" },
            new Skill{Code = 03, Description = "Flexibility" },
            new Skill{Code = 04, Description = "Problem-Solving" },
            new Skill{Code = 05, Description = "Interpersonal" }
        };
        
        internal static Skill s1 = new Skill{Code = 01, Description = "Leadership" };
        internal static Skill s2 = new Skill{Code = 02, Description = "Teamwork" };
        internal static Skill s3 = new Skill{Code = 03, Description = "Flexibility" };
        internal static Skill s4 = new Skill{Code = 04, Description = "Problem-Solving" };
        internal static Skill s5 = new Skill{Code = 05, Description = "Interpersonal" };

        
       

        static List<Worker> workers = new List<Worker>
        {
            new Technician{Name = "Mario", LastName = "Rossi", CF = "MRS001X",
                Sector = SectorEnum.Amministrazione, Skills = {s1, s2 }, HourlyWage = 10,WorkHours = 8 },
            new Intern{Name = "Ciccio", LastName = "Pasticcio", CF = "CIPST001X",
                Sector = SectorEnum.Sviluppo, Skills = {s3, s5 }, Duration = 3 },
            new Manager{Name = "Francesca", LastName = "Riso", CF = "FRS001X",
                Sector = SectorEnum.Sviluppo, Skills = {s4, s1 }, OvertimeHours = 25, BaseSalary = 2000 },

        };

        internal static void ShowWorkersBySalary()
        {
            decimal userSalary;
            int check = 0;
            Console.WriteLine("Inserisci lo stipendio in base al quale vuoi vedere l'elenco di impiegati che hanno salario maggiore di questo");
            while (!(decimal.TryParse(Console.ReadLine(), out userSalary)))
            {
                Console.WriteLine("Inserisci un salario valido");
            }

            
            foreach (Worker w in workers)
            {
                if(w.Salary() > userSalary)
                {
                    Console.Write($"{w.Name} {w.LastName} \t");
                    foreach (Skill s in w.Skills)
                    {
                        Console.Write($"Skill : {s.Description} \t");
                    }
                    Console.Write($" {w.Salary()} \n");
                    check++;
                }
            }
            if(check == 0)
            {
                Console.WriteLine($"Non c'è nessun impiegato che ha salario maggiore rispetto a quello che hai inserito ({userSalary}");
            }
        }

        internal static void ShowWorkersBySkill()
        {
            int check = 0;
            Console.WriteLine("Scegli la skill di cui vuoi visualizzare tutti gli impiegati");
            Skill userChosenSkill = ChooseSkill();

            foreach(Worker w in workers)
            {
                foreach(Skill s in w.Skills)
                {
                    if(userChosenSkill.Description == s.Description)
                    {
                        Console.WriteLine($"{w.Name} {w.LastName}, {s.Description} , {w.Salary()}");
                        check++;
                    }
                }
            }
            if (check == 0)
            {
                Console.WriteLine($"Non c'è nessun impiegato che ha la skill che hai scelto ({userChosenSkill.Description}");
            }
        }

        internal static void DeleteWorker()
        {
            int j = 0;
            Console.WriteLine("Ecco l'elenco di tutti gli impiegati");
            foreach (Worker w in workers)
            {
                Console.Write($"{w.Name} {w.LastName} \t"); //, {w.Skills} , {w.Salary()}");
                foreach (Skill s in w.Skills)
                {
                    Console.Write($"Skill : {s.Description} \t");
                }
                Console.Write($" {w.Salary()} \n");
            }
            
            Console.WriteLine("Inserisci il CF dell'impiegato che vuoi eliminare");
            string cf = Console.ReadLine();
            foreach (Worker w in workers)
            {
                if(cf == w.CF)
                {
                    w.CF = "0"; // qui avrei dovuto implementare un nuovo metodo fuori da management per eliminare il worker, perchè facendolo qui mi scombussola l'indice 
                    //workers.Remove(w);
                    j++;
                }
            }
            if(j == 0)
            {
                Console.WriteLine("Mi dispiace ma non c'è nessun impiegato con il cf che hai inserito");
            }

        }


        internal static void AddWorker()
        {
            int choice, s;
            Skill newSkill = ChooseSkill();
            bool exists = false;
            
            Console.WriteLine("Che tipo di impiegato vuoi aggiungere?");
            Console.WriteLine("Scegli 1 per aggiungere un Tecnico");
            Console.WriteLine("Scegli 2 per aggiungere uno Stagista");
            Console.WriteLine("Scegli 3 per aggiungere un Manager");

            while (!(int.TryParse(Console.ReadLine(), out choice)) || choice < 0 || choice > 2)
            {
                Console.WriteLine("Inserisci un'opzione valida");
            }

            Console.WriteLine("Inserisci nome");
            string name = Console.ReadLine();

            Console.WriteLine("Inserisci cognome");
            string lastname = Console.ReadLine();

            Console.WriteLine("Inserisci CF");
            string cf = Console.ReadLine();
            foreach (Worker w in workers)
            {
                    if (cf == w.CF)
                    {
                        Console.WriteLine("Esiste già un utente con quel CF");
                        return;
                    }
            }

          

            do
            {
                Console.WriteLine($"Scegli il settore: \n{(int)SectorEnum.Amministrazione} per {SectorEnum.Amministrazione} " +
                  $"\n{(int)SectorEnum.Sviluppo} per {SectorEnum.Sviluppo} \n{(int)SectorEnum.Vendite} per {SectorEnum.Vendite}");

            } while (!int.TryParse(Console.ReadLine(), out s) || s < 0 || s > 2);

           
                

            switch (choice)
            {
                case 1: //tecnico
                    decimal hourlyrage;
                    int workHours;
                    Console.WriteLine("Inserisci paga oraria");
                    
                    while (!(decimal.TryParse(Console.ReadLine(), out hourlyrage)))
                    {
                        Console.WriteLine("Inserisci una paga valida");
                    }

                    Console.WriteLine("Inserisci il numero di ore lavorative");
                    while (!(int.TryParse(Console.ReadLine(), out workHours)) || workHours < 0)
                    {
                        Console.WriteLine("Inserisci numero di ore lavorative adeguato");
                    }
                    Technician t = new Technician {Name = name, LastName = lastname, CF = cf, HourlyWage = hourlyrage , Sector = (SectorEnum)s, Skills = {newSkill}, WorkHours = workHours};
                    workers.Add((Worker)t);
                    break;
                case 2: //stagista
                    int duration;
                    Console.WriteLine("Inserisci il numero mesi di durata dello stage");
                    while (!(int.TryParse(Console.ReadLine(), out duration)) || duration < 0 || duration > 12)
                    {
                        Console.WriteLine("Inserisci numero valido!");
                    }
                    Intern i = new Intern { Name = name, LastName = lastname, CF = cf, Duration = duration, Sector = (SectorEnum)s, Skills = { newSkill } };
                    workers.Add((Worker)i);
                    break;
                case 3: //manager
                    decimal baseSalary;
                    int overtimeHours;
                    Console.WriteLine("Inserisci salario di base");

                    while (!(decimal.TryParse(Console.ReadLine(), out baseSalary)))
                    {
                        Console.WriteLine("Inserisci un salario valido!");
                    }

                    Console.WriteLine("Inserisci il numero di ore di straordinario");
                    while (!(int.TryParse(Console.ReadLine(), out overtimeHours)) || overtimeHours < 0)
                    {
                        Console.WriteLine("Inserisci numero valido!");
                    }
                    Manager m = new Manager { Name = name, LastName = lastname, CF = cf, BaseSalary = baseSalary , OvertimeHours = overtimeHours, Sector = (SectorEnum)s, Skills = { newSkill } };
                    workers.Add((Worker)m);
                    break;
            }
        }

        internal static void WorkersBySector()
        {
            int choice, i = 0;
            Console.WriteLine("Di che settore vuoi visualizzare gli impiegati?");
            do
            {
                Console.WriteLine($"Scegli il settore: \n{(int)SectorEnum.Amministrazione} per {SectorEnum.Amministrazione} " +
                  $"\n{(int)SectorEnum.Sviluppo} per {SectorEnum.Sviluppo} \n{(int)SectorEnum.Vendite} per {SectorEnum.Vendite}");

            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 2);

            foreach (Worker w in workers)
            {
                
                if(w.Sector == (SectorEnum)choice)
                {
                    Console.Write($"{w.Name} {w.LastName} \t");
                    foreach (Skill s in w.Skills)
                    {
                        Console.Write($"Skill : {s.Description} \t");
                    }
                    Console.Write($" {w.Salary()} \n");
                    
                    i++;
                }
         
            }
            if(i == 0)
            {
                Console.WriteLine($"Mi dispiace ma non c'è nessun impiegato che lavora nel settore {(SectorEnum)choice}");
            }
        }
            
      
        internal static void ShowWorkers()
        {
            Console.WriteLine("Ecco l'elenco di tutti gli impiegati");
            foreach(Worker w in workers)
            {
                Console.Write($"{w.Name} {w.LastName} \t"); //, {w.Skills} , {w.Salary()}");
                foreach (Skill s in w.Skills)
                {
                    Console.Write($"Skill : {s.Description} \t");
                }
                Console.Write($" {w.Salary()} \n");
            }
        }

        internal static Skill ChooseSkill()
        {
            int sk;
            Skill newSkill = new Skill();
            do
            {
                Console.WriteLine($"Scegli la skill inserendo il codice");
                foreach (Skill skill in Skills)
                {
                    Console.WriteLine($" Code : {skill.Code}  Descrizione : {skill.Description}");
                }

            } while (!int.TryParse(Console.ReadLine(), out sk) || sk < 0 || sk > 5);

            foreach (Skill skill in Skills)
            {
                if (sk == skill.Code)
                {
                    newSkill = skill;
                }
            }
            return newSkill;

        }
    }
}
