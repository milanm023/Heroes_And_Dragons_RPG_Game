namespace HeroesAndDragons;

public interface IDragon
{
    int HealthPoints { get; }
    int AttackPoints ();
    bool IsDead();
    void DamageReceived (int damage);
    void SetHealthPoints (int healthPoints);
}