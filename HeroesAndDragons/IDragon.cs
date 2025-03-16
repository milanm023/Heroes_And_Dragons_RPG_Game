namespace HeroesAndDragons;

public interface IDragon
{
    int HealthPoints { get; }
    int AttackPoints ();
    void Damage (int damage);
}