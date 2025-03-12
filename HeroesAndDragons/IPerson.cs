namespace HeroesAndDragons;

public interface IPerson
{
    int healthPoints { get; }
    int attackPoints { get; }
    void Attack (int attack);
}