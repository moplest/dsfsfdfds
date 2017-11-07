using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RULETKA
{
    public class Player
    {
        public Player(string username, string password, double cardMoney)
        {
            this.username = username;
            this.password = password;
            this.cardMoney = cardMoney;
        }
        public string username { get; set; }
        public string password { get; set; }
        public double cardMoney { get; set; }
        public double cash4play { get; set; }
    }
}