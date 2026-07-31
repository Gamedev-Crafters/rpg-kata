using System.Collections.Generic;
using System.Linq;

namespace kata;

public class Character
{
    public const int maxHealth = 1000;
    public int maxRange;
    public int level;
    public int health;
    public bool alive;
    public int position;
    private List<string> factions  = new();

    public Character(int maxRange, int position)
    {
        level = 1;
        health = maxHealth;
        alive = true;
        this.maxRange = maxRange;
        this.position = position;
    }

    public static Character ACharacter()
    {
        return new Character(1, 1);
    }

    public static Character Melee(int position) => new Character(2, position);
    public static Character Ranged(int position) => new Character(20, position);

    public bool IsInRange(Character character)
    {
        return Math.Abs(character.position - this.position) <= maxRange;
    }

    public bool IsAlly(Character character)
    {
        return factions.Any(faction => character.factions.Contains(faction));
    }

    public void DoDamage(Character character, int damage)
    {
        if (character == this)
        {
            throw new InvalidOperationException("No se puede hacer daño a si mismo.");
        }

        if (IsAlly(character))
        {
            throw new InvalidOperationException("Can't do damage to ally.");
        }

        if (!IsInRange(character))
        {
            throw new InvalidOperationException("El enemigo queda fuera de rango.");
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

    public void JoinFaction(string faction)
    {
        if (IsInFaction(faction))
        {
            throw new InvalidOperationException("Character already is in that faction.");
        }

        factions.Add(faction);
    }

    public void LeaveFaction(string faction)
    {
        if (!IsInFaction(faction))
        {
            throw new InvalidOperationException("Character does not belong that faction.");
        }

        factions.Remove(faction);
    }

    public bool IsInFaction(string faction)
    {
        return factions.Contains(faction);
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
