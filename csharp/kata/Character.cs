namespace kata;

public class Character
{
    public const int maxHealth = 1000;
    public int level;
    public int health;
    public bool alive;

    public Character()
    {
        level = 1;
        health = maxHealth;
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
            health = Math.Min(health + heal, maxHealth);
    }
}
