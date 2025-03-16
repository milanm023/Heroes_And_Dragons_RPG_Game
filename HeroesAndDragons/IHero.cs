namespace HeroesAndDragons;

public interface IHero
{
    int Healing { get; }
    int HealthPoints { get; }
    int AttackPoints (int command);
    void Damage (int damage);
}