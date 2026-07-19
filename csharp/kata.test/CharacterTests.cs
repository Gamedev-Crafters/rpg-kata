namespace kata.test;

public class CharacterTests
{
    [Fact]
    public void DoDamageToCharacter_StillAlive()
    {
        var defender = new Character();
        var attacker = new Character();

        attacker.DoDamage(defender, 100);

        defender.alive.Should().BeTrue();
    }

    [Fact]
    public void DoDamageToCharacter_NotAlive()
    {
        var defender = new Character();
        var attacker = new Character();

        attacker.DoDamage(defender, 2000);

        defender.alive.Should().BeFalse();
    }

    [Fact]
    public void HealCharacter_ToFull()
    {
        var defender = new Character();
        var attacker = new Character();

        attacker.DoDamage(defender, 500);
        defender.Heal(1000);

        defender.health.Should().Be(Character.maxHealth);
    }

    [Fact]
    public void CannotHealDeadCharacter()
    {
        var defender = new Character();
        var attacker = new Character();

        attacker.DoDamage(defender, 1000);
        defender.Heal(1000);

        defender.alive.Should().BeFalse();
    }

    [Fact]
    public void DoDamageToStrongerCharacter()
    {
        var attacker = new Character();
        var defender = new Character();
        defender.level = 6;

        attacker.DoDamage(defender, 100);

        defender.health.Should().Be(Character.maxHealth - 50);
    }

    [Fact]
    public void DoDamageToWeakerCharacter()
    {
        var attacker = new Character();
        var defender = new Character();
        attacker.level = 6;

        attacker.DoDamage(defender, 100);

        defender.health.Should().Be(Character.maxHealth - 150);
    }
}
