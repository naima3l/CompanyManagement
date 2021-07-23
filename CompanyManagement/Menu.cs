using System;

namespace CompanyManagement
{
    internal class Menu
    {
        internal static void Start()
        {
            Console.WriteLine("Bnvenuto");
            bool check = false;
            int choice;
            do
            {
                Console.WriteLine("Scegli 1 per visualizzare tutti gli impiegati");
                Console.WriteLine("Scegli 2 per mostrare gli impiegati appartenenti ad un determinato settore");
                Console.WriteLine("Scegli 3 per inserire un nuovo impiegato");
                Console.WriteLine("Scegli 4 per eliminare un impiegato");
                Console.WriteLine("Scegli 5 per visualizzare gli impiegati con stipendio maggiore a quello che inserirai");
                Console.WriteLine("Scegli 6 per visualizzare gli impiegati con una certa skill");
                Console.WriteLine("Scegli 0 per uscire");

                while (!(int.TryParse(Console.ReadLine(), out choice)) || choice < 0 || choice > 6)
                {
                    Console.WriteLine("Inserisci un'opzione valida");
                }

                switch (choice)
                {
                    case 1:
                        Management.ShowWorkers();
                        break;
                    case 2:
                        Management.WorkersBySector();
                        break;
                    case 3:
                        Management.AddWorker();
                        break;
                    case 4:
                        Management.DeleteWorker();
                        break;
                    case 5:
                        Management.ShowWorkersBySalary();
                        break;
                    case 6:
                        Management.ShowWorkersBySkill();
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                    case 0:
                        check = true;
                        break;
                }

            } while (check == false);

        }    
    }
}