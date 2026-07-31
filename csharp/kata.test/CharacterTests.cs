namespace kata.test;

public class CharacterTests
{
    [Fact]
    public void DoDamageToCharacter_StillAlive()
    {
        var defender = Character.ACharacter();
        var attacker = Character.ACharacter();

        attacker.DoDamage(defender, 100);

        defender.alive.Should().BeTrue();
    }

    [Fact]
    public void DoDamageToCharacter_NotAlive()
    {
        var defender = Character.ACharacter();
        var attacker = Character.ACharacter();

        attacker.DoDamage(defender, 2000);

        defender.alive.Should().BeFalse();
    }

    [Fact]
    public void HealCharacter_ToFull()
    {
        var defender = Character.ACharacter();
        var attacker = Character.ACharacter();

        attacker.DoDamage(defender, 500);
        defender.Heal(1000);

        defender.health.Should().Be(Character.maxHealth);
    }

    [Fact]
    public void CannotHealDeadCharacter()
    {
        var defender = Character.ACharacter();
        var attacker = Character.ACharacter();

        attacker.DoDamage(defender, 1000);
        defender.Heal(1000);

        defender.alive.Should().BeFalse();
    }

    [Fact]
    public void DoDamageToStrongerCharacter()
    {
        var attacker = Character.ACharacter();
        var defender = Character.ACharacter();
        defender.level = 6;

        attacker.DoDamage(defender, 100);

        defender.health.Should().Be(Character.maxHealth - 50);
    }

    [Fact]
    public void DoDamageToWeakerCharacter()
    {
        var attacker = Character.ACharacter();
        var defender = Character.ACharacter();
        attacker.level = 6;

        attacker.DoDamage(defender, 100);

        defender.health.Should().Be(Character.maxHealth - 150);
    }

    [Fact]
    public void CharacterIsInRange()
    {
        var attacker = Character.Melee(0);
        var characterInRange = Character.Melee(2);
        var anotherCharacterInRange = Character.Melee(-2);
        var characterOutOfRange = Character.Melee(3);

        attacker.IsInRange(characterInRange).Should().BeTrue();
        attacker.IsInRange(anotherCharacterInRange).Should().BeTrue();
        attacker.IsInRange(characterOutOfRange).Should().BeFalse();
    }

    [Fact]
    public void CharacterIsInFaction()
    {
        var character = Character.ACharacter();
        character.JoinFaction("FactionA");

        character.IsInFaction("FactionA").Should().BeTrue();
        character.IsInFaction("FactionB").Should().BeFalse();
    }

    [Fact]
    public void CharacterLeavesFaction()
    {
        var character = Character.ACharacter();
        character.JoinFaction("FactionA");
        character.LeaveFaction("FactionA");

        character.IsInFaction("FactionA").Should().BeFalse();
    }

    [Fact]
    public void HealAlly()
    {
        var character = Character.ACharacter();
        character.JoinFaction("FactionA");

        var ally = Character.ACharacter();
        ally.JoinFaction("FactionA");

        character.Heal(ally, 100);

        // El personaje no se va a curar porq esta a vida maxima de base
        character.health.Should().Be(0);
    }

    /*
    [Fact]
    public void AreCharacterAllies()
    {
        var attacker = Character.ACharacter();
        var ally = Character.ACharacter();

    }
    */
}
