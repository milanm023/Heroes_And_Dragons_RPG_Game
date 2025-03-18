namespace HeroesAndDragons;

public interface IHero
{
    int Healing { get; }
    int HealthPoints { get; }
    int AttackPoints (int command);
    bool IsDead();
    void DamageReceived (int damage);
    bool SetHealthPoints(string healthPoints);
}