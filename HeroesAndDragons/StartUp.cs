namespace HeroesAndDragons;

class StartUp
{
    static void Main(string[] args)
    {
        Hero hero = Hero.Instance;
        Dragon dragon = Dragon.Instance;
        Console.Write("Please enter the hero's health: ");
        string input = Console.ReadLine();

        while (!hero.SetHealthPoints(input))
        {
            Console.Write("Please enter the hero's health: ");
            input = Console.ReadLine();
        }
        
        Console.WriteLine($"Hello, World! {dragon.ToString()}");
    }
}