namespace HeroesAndDragons;

public class Dragon : IDragon
{
    private int healthPoints;
    
    //Singleton pattern
    private static Dragon instance;
    private Dragon()
    { }
    public static Dragon Instance
    {
        get
        {
            if (instance == null)
                instance = new Dragon();
            return instance;
        }
    }

    /*
    public Dragon(int healthPoints)
    {
        this.HealthPoints = healthPoints;
    }
    */
    public int HealthPoints
    {
        get => healthPoints;

        private set
        {
            
            if (value < 1 || value > 100)
            {
                throw new ArgumentException("Health points cannot be less or equal to 0 or more than 100.");
            }
            
            healthPoints = value;
        }
    }
    
    public int AttackPoints()
    {
		Random random = new Random();
		int attack = random.Next(7,18);

        return attack;
    }

    public void DamageReceived(int damage)
    {
        if (damage == 0)
        {
            Console.WriteLine("Missed!!!");
        }
        else
        {
            Console.WriteLine($"Dragon lost {damage} hp!");
            healthPoints -= damage;
        }
        
    }

    public bool SetHealthPoints(string healthPoints)
    {
        if (int.TryParse(healthPoints, out int hp))
        {
            if (hp < 1 || hp > 100)
            {
                Console.WriteLine("Health points cannot be less or equal to 0 or more than 100.");
                return false;
            }
            this.healthPoints = hp;
            Console.WriteLine($"Health points for Dragon set to {this.healthPoints}hp." );
            return true;
        }
        else
        {
            Console.WriteLine("Health points needs to be a NUMBER between 1 and 100.");
            return false;
        }
    }

    public bool IsDead()
    {
        return healthPoints <= 0;
    }
}