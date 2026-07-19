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

    public void DoDamage(Character character, int damage)
    {
        if (character == this)
        {
            throw new InvalidOperationException("No se puede hacer daño a si mismo.");
        }

        damage = CalculateDamage(character, damage);

        character.health = Math.Max(0, character.health - damage);
        character.alive = character.health > 0;
    }

    public void Heal(int heal)
    {
        if (alive)
            health = Math.Min(health + heal, maxHealth);
    }

    private int CalculateDamage(Character character, int damage)
    {
        if (isWeakerThan(character))
        {
            return (int)(damage * 0.5);
        }
        if (isStrongerThan(character))
        {
            return (int)(damage * 1.5);
        }

        return damage;
    }

    private bool isStrongerThan(Character character)
    {
        return character.level + 5 <= this.level;
    }

    private bool isWeakerThan(Character character)
    {
        return character.level >= this.level + 5;
    }
}
