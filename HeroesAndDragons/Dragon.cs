namespace HeroesAndDragons;

public class Dragon : IDragon
{
    private int healthPoints;
    
    public Dragon(int healthPoints)
    {
        this.HealthPoints = healthPoints;
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
    
    public int AttackPoints()
    {
		Random random = new Random();
		int attack = random.Next(7,18);

        return attack;
    }

    public void Damage(int damage)
    {
        HealthPoints -= damage;
    }
}