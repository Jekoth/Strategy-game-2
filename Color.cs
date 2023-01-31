using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_game_2
{
    public class Color
    {
        public static ConsoleColor errorColor = ConsoleColor.Red;
        public static ConsoleColor noteColor = ConsoleColor.Yellow;

        public static void ColorWrite(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        public static void ColorWriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void DisplayArmy(string title, Army army)
        {
            ColorWriteLine(title, noteColor);
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < army.Units.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + army.Units[i].name + " HP: " + army.Units[i].health);
            }
            Console.WriteLine();
        }

        public static void PrintAttack(Unit attacker, Unit defender)
        {
            Console.WriteLine(attacker.name + " attacks " + defender.name + " for " + attacker.damage + " damage.");
            Console.WriteLine(defender.name + " has " + defender.health + " HP left.");
            Console.WriteLine();
        }

    }
}
