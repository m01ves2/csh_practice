using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_computerClub
{
    internal class Computer
    {
        private static int id = 0; 
        public int Id { get; private set; }
        public int CostPerMinute { get; private set; }
        public int MinutesOccupiedLeft { get; private set; }
        public bool isOccupied { get; private set; }

        private Client client;

        public Computer(Random random)
        {
            Id = id++;
            CostPerMinute = random.Next(7, 15);
            MinutesOccupiedLeft = 0;
            isOccupied = false;
        }

        public void ServeClient(Client client)
        {
            this.client = client;
            isOccupied = true;
            MinutesOccupiedLeft = client.MinutesDesired;
        }

        public void TickOneMinute()
        {
            if (isOccupied) {
                MinutesOccupiedLeft--;
            }

            if (MinutesOccupiedLeft <= 0) {
                MinutesOccupiedLeft = 0;
                client = null;
                isOccupied = false;
            }
        }

        public string GetClientName()
        {
            if (client != null)
                return client.Name;
            else
                return "N/A";
        }
    }
}
