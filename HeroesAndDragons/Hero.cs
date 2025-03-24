namespace HeroesAndDragons;

public class Hero : IHero
{
    private int healthPoints;
    private int healing = 2;
    
    //Singleton
    private static Hero instance;
    private Hero()
    { }

    public static Hero Instance
    {
        get
        {
            if (instance == null)
                instance = new Hero();
            return instance;
        }
    }

    /*
    public Hero(int healthPoints)
    {
        this.HealthPoints = healthPoints;
        this.Healing = 2;
    }
    */

    public int Healing
    {
        get => this.healing;
        private set
        {
            this.healing = value;
        }
    }

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
    
    public int AttackPoints(int command)
    {
        int attackPoints = 0;
        //int criticalHits = 0;
        Random random = new Random();

        if (command == 1)
        {
            
            // 75% chance to hit
            int hitChance = random.Next(1, 101); // Random number between 1 and 100
            if (hitChance <= 75)
            {
                // If attack hits, deal damage between 10 and 15 (inclusive)
                attackPoints = random.Next(10, 16); // Random number between 10 and 15
            }
        }
        else
        {
            // 50% chance to hit
            int hitChance = random.Next(1, 101); // Random number between 1 and 100
            if (hitChance <= 50)
            {
                // If attack hits, deal damage between 10 and 15 (inclusive)
                attackPoints = random.Next(15, 31); // Random number between 10 and 15
            }
        }

        if (attackPoints > 0)
        {
            int criticalHitChance = random.Next(1, 101);
            //80% change for critical hit
            if (criticalHitChance <= 20)
            {
                attackPoints += attackPoints / 2;
            }
        }
        
        return attackPoints;
    }

    public void DamageReceived(int damage)
    {
        Console.WriteLine($"Hero lost {damage} hp!");
        healthPoints -= damage;
    }
    public bool SetHealthPoints(string healthPoints)
    {
        //mozda napraviti da metoda vraca bool i u njoj sve proveriti : da li je unet broj ili string i da li je broj u granicama. 
        if (int.TryParse(healthPoints, out int hp))
        {
            if (hp < 1 || hp > 100)
            {
                Console.WriteLine("Health points cannot be less or equal to 0 or more than 100.");
                return false;
            }
            this.healthPoints = hp;
            Console.WriteLine($"Health points for Hero set to {this.healthPoints}hp." );
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

    public void UseHealingPotion()
    {
        if (Healing == 0)
        {
            Console.WriteLine("No more healing potions left.");
            Console.WriteLine($"Hero's health: {HealthPoints}");
        }
        else
        {
            Random random = new Random();
            int healingPoints = random.Next(15, 36);
            Console.WriteLine($"Health restored: {healingPoints}");
            if (healingPoints + healthPoints > 100)
            {
                healthPoints = 100;
            }
            else
            {
                healthPoints += healingPoints;
            }
            Healing--;
            Console.WriteLine($"Healing potions left: {Healing}");
            Console.WriteLine($"Hero's health: {HealthPoints}");
        }
    }
}