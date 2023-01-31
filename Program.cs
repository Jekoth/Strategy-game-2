namespace Strategy_game_2;

class Program
{
        public static void Main()
    {
        Army humanArmy = new Army("Human army", Team.Player);
        humanArmy.AddUnit(new Unit("Human warrior", 10, 40));
        humanArmy.AddUnit(new Unit("Human archer", 4, 20));
        humanArmy.AddUnit(new Unit("Human mage", 15, 10));

        Army skeletonArmy = new Army("Skeleton army", Team.Enemy);
        skeletonArmy.AddUnit(new Unit("Skeleton warrior", 5, 20));
        skeletonArmy.AddUnit(new Unit("Skeleton archer", 3, 10));
        skeletonArmy.AddUnit(new Unit("Skeleton sorcerer", 10, 5));

        Random random = new Random();

        Console.WriteLine("Battle begins!");
        Color.DisplayArmy(humanArmy.Name, humanArmy);
        Color.DisplayArmy(skeletonArmy.Name, skeletonArmy);

        while (true)
        {
            // Player turn
            if (humanArmy.AreAllDead())
            {
                break;
            }
            var attacker = SelectUnit("Select attacker:", humanArmy);
            var defender = SelectUnit("Select target:", skeletonArmy);
            Attack(attacker, defender);

            // Enemy turn
            if (skeletonArmy.AreAllDead())
            {
                break;
            }
            attacker = RandomizeUnit(skeletonArmy, random);
            defender = RandomizeUnit(humanArmy, random);
            Attack(attacker, defender);
        }
        Console.WriteLine("The battle is over. Press any key to continue...");
        Console.ReadLine();
    }

    public static Unit SelectUnit(string prompt, Army army)
    {
        while (true)
        {
            Color.DisplayArmy(prompt, army);
            var choice = Console.ReadLine();
            if (int.TryParse(choice, out int num) && num > 0 && num <= army.Units.Count)
            {
                var selected = army.Units[num - 1];
                if (selected.health > 0)
                {
                    return selected;
                }
                Console.WriteLine("Cannot choose a dead unit.");
            }
            else
            {
                Console.WriteLine("Invalid unit number. Try again.");
            }
        }
    }

    public static Unit RandomizeUnit(Army army, Random random)
    {
        if (army.AreAllDead())
        {
            Console.WriteLine("Error, cannot select from dead army.");
            return army.Units[0];
        }
        while (true)
        {
            var selected = army.Units[random.Next(army.Units.Count)];
            if (selected.health > 0)
            {
                return selected;
            }
        }
    }
    public static void Attack(Unit attacker, Unit defender)
    {
        if (attacker.health > 0)
        {
            defender.health -= attacker.damage;
            Color.PrintAttack(attacker, defender);
            if (defender.health <= 0)
            {
                Color.ColorWriteLine(defender.name + " died!", Color.noteColor);
            }
        }
    }
}