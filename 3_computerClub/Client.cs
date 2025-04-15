using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_computerClub
{
    internal class Client
    {
        public string Name {  get; private set; }
        public int MinutesDesired { get; private set; }
        private int money;

        public Client(string name, Random random) 
        { 
            Name = name;
            money = random.Next(100, 301);
            MinutesDesired = random.Next(10, 30);
        }
        
        public bool CheckMoney(int costPerMinute)
        {
            return money >= costPerMinute * MinutesDesired;
        }

        public int BuyComputerTime(int costPerMinute)
        {
            if (CheckMoney(costPerMinute)) {
                int cost = costPerMinute * MinutesDesired;
                return cost;
            }
            return 0;
        }
    }
}
