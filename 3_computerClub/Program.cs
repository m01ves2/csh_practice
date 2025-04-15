using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_computerClub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            ComputerClub club = new ComputerClub(5, rand);
            string[] names = { 
                "Misha",
                "Petr", 
                "Zina", 
                "Alex", 
                "Bill", 
                "Tom", 
                "Henry",
                "Nora",
                "Andrew",
                "Zoi",
                "Apas", 
                "Olya", 
                "Tanya",
                "Todd", 
                "Halk", 
                "Mikhaild",
            };

           
            foreach (String name in names) {
                club.addClient(new Client(name, rand));
            }

            while (true) {
                club.GetStats();
                club.ServeClient();
                club.TickOneMinute();

                if (rand.Next(1, 4) % 2 == 0 && (club.GetClientsCount() < 15)) {
                    club.addClient(new Client(names[rand.Next(0, names.Length)] + rand.Next(0, 1000), rand));
                }

                Console.ReadKey();
            }
        }
    }
}
