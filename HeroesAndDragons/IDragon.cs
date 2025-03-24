namespace HeroesAndDragons;

public interface IDragon
{
    int HealthPoints { get; }
    int AttackPoints ();
    bool IsDead();
    void DamageReceived (int damage);
    bool SetHealthPoints (string healthPoints);
}