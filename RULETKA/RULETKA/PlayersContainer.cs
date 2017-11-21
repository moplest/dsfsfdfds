using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RULETKA
{
    class PlayersContainer
    {
        private Player[] playersContainer;
        public PlayersContainer()
        {
            Player p1 = new Player("proben user", "1234", 10000);
            Player p2 = new Player("kalevinho", "951221", 10000);
            Player p3 = new Player("bacho", "123123", 10000);
            playersContainer = new Player[] { p1, p2, p3 };
        }

        public Player getPlayerByName(string name)
        {
            Player p = null;
            int index = 0;
            bool found = false;
            while (index < playersContainer.Length && !found)
            {
                p = playersContainer[index];
                if (p.username == name)
                {
                    found = true;
                }
                else {
                    index++;
                }
            }
            if (found)
            {
                return playersContainer[index];
            }
            else
            {
                return null;
            }
        }
    }
}