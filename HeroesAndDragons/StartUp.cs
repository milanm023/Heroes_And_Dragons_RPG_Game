namespace HeroesAndDragons;

class StartUp
{
    static void Main(string[] args)
    {
        Hero hero = Hero.Instance;
        Dragon dragon = Dragon.Instance;
        
        Console.WriteLine($"Hello, World! {dragon.ToString()}");
    }
}