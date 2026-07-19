namespace kata;

public class Character
{
    public int level;
    public int health;
    public bool alive;

    public Character()
    {
        level = 1;
        health = 1000;
        alive = true;
    }

    public void DoDamage(int damage)
    {
        health = Math.Max(0, health - damage);
        alive = health > 0;
    }

    public void Heal(int heal)
    {
        if (alive)
            health = Math.Min(health + heal, 1000);
    }
}
