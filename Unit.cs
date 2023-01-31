using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_game_2
{
    public class Unit
    {
        public string name;
        public int damage;
        public int health;
        public Team team; 

        public Unit(string name, int damage, int health)
        {
            this.name = name;
            this.damage = damage;
            this.health = health;
            this.team = Team.Neutral;
        }
    }
}
