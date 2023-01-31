using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_game_2
{
    public class Army
    {
        public string Name { get; set; }
        public Team Team { get; set; }
        public List<Unit> Units { get; set; }

        public Army(string name, Team team)
        {
            Name = name;
            Team = team;
            Units = new List<Unit>();
        }

        public void AddUnit(Unit unit)
        {
            Units.Add(unit);
        }

        public bool AreAllDead()
        {
            foreach (Unit unit in Units)
            {
                if (unit.health > 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}