using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace _3_computerClub
{
    internal class ComputerClub
    {
        private List<Computer> computers = new List<Computer>();
        private Queue<Client> clients = new Queue<Client>();
        private int money = 0;
        Random random;

        public ComputerClub(int compNumber, Random random)
        {
            for(int i = 0; i < compNumber; i++) {
                Computer computer = new Computer(random);
                computers.Add(computer);
            }

            money = 0;
            this.random = random;
        }

        public void addClient(Client client)
        {
            clients.Enqueue(client);
        }

        public int GetClientsCount()
        {
            return clients.Count;
        }

        internal void GetStats()
        {
            Console.Clear();
            foreach (Computer computer in computers) {
                Console.Write("Computer #" + computer.Id + " - ");
                if (computer.isOccupied) {
                    Console.Write( computer.GetClientName() + " is working. Time left: " + computer.MinutesOccupiedLeft);
                }
                else {
                    Console.Write(" is not working...");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Total money earned: " + money);
        }

        internal void ServeClient()
        {
            Client client;
            bool hasFreeComputers = false;

            for(int i = 0; i < computers.Count;i++) {
                if (!computers[i].isOccupied) {
                    hasFreeComputers = true;
                    break;
                }
            }
            if (!hasFreeComputers) {
                Console.WriteLine("No free computers in club." + clients.Count+ " clients are waiting...");
                return;
            }


            if (clients.Count > 0)
                client = clients.Dequeue();
            else {
                Console.WriteLine("No clients in queue...");
                return;
            }

            bool isServed = false;
            for(int i = 0; i < computers.Count; i++){
                if (!computers[i].isOccupied) {
                    if (client.CheckMoney(computers[i].CostPerMinute)) {
                        Console.WriteLine("Administator suggested to client " + client.Name + " computer #" + computers[i].Id);
                        money += client.BuyComputerTime(computers[i].CostPerMinute);
                        computers[i].ServeClient(client);
                        isServed = true;
                        break;
                    }
                }
            }

            if (!isServed) {
                Console.WriteLine("Couldn't find appropriate computer for " + client.Name + ". So client went away");
            }
        }

        internal void TickOneMinute()
        {
            foreach (Computer computer in computers) {
                computer.TickOneMinute();
            }
        }
    }
}
