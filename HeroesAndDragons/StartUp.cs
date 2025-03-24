namespace HeroesAndDragons;

class StartUp
{
    static void Main(string[] args)
    {
        IHero hero = Hero.Instance;
        IDragon dragon = Dragon.Instance;
        
        LoadInitialHealthPoints(hero, dragon);

        Battle(hero, dragon);
        
        //zapoceti za while (true)
        // Round (brojac)
        // Provera da li je heroj ziv i ako jeste, ispisati opciju da bira vrstu napada ili healing
        // Ako nije ziv, ispisati da je Zmaj pobedio i zavrsiti igru
        // Napad na zmaja
        // Provera da li je zmaj ziv
        // Ako nije, ispisati da je Heroj pobedio i zavrsiti igru
        // Ako je ziv, zmaj napada.
    }

    private static void Battle(IHero hero, IDragon dragon)
    {
        int round = 1;
        Console.WriteLine($"Round: {round}");
        while (hero.HealthPoints > 0 && dragon.HealthPoints > 0)
        {
                Console.WriteLine($"Hero's health: {hero.HealthPoints}");
                Console.WriteLine($"Dragon's health: {dragon.HealthPoints}");
                Console.WriteLine("Please select an action:");
                Console.WriteLine("Press 1 for sword attack");
                Console.WriteLine("Press 2 for lightning attack");
                Console.WriteLine("Press 3 for healing");
                string action = Console.ReadLine();
                Console.Clear();
                switch (action)
                {
                    case "1":
                    case "2":
                    {
                        dragon.DamageReceived(hero.AttackPoints(int.Parse(action)));
                    }
                        break;
                    case "3":
                    {
                        hero.UseHealingPotion();
                    }
                        break;
                    default:
                        Console.WriteLine("Invalid action. Please try again.");
                        break;
                }

                if (Equals(action, "1") || Equals(action, "2") || Equals(action, "3"))
                {
                    if (!dragon.IsDead())
                    {
                        Console.WriteLine("Dragon attacks!");
                        hero.DamageReceived(dragon.AttackPoints());
                        if (hero.IsDead())
                        {
                            Console.WriteLine("GAME OVER!!! YOU LOST!!!");
                            Console.WriteLine("Hero is dead.");
                            Console.WriteLine($"Dragon's health: {dragon.HealthPoints}");
                            break;
                        }
                    }
                    else if (dragon.IsDead())
                    {
                        Console.WriteLine("GAME OVER!!! YOU WON!!!");
                        Console.WriteLine("Dragon is dead.");
                        Console.WriteLine($"Hero's health: {hero.HealthPoints}");
                        Console.WriteLine("Press any key to continue...");
                        break;
                    }
                    round++;
                    Console.WriteLine($"Round: {round}");
                }
        }
    }

    public static void LoadInitialHealthPoints(IHero hero, IDragon dragon)
    {
        Console.Write("Please enter the hero's health: ");
        string input = Console.ReadLine();

        while (!hero.SetHealthPoints(input))
        {
            Console.Write("Please enter the hero's health: ");
            input = Console.ReadLine();
        }
        
        Console.Write("Please enter the dragon's health: ");
        input = Console.ReadLine();
        
        while (!dragon.SetHealthPoints(input))
        {
            Console.Write("Please enter the dragon's health: ");
            input = Console.ReadLine();
        }
        Console.Clear();
    }
}