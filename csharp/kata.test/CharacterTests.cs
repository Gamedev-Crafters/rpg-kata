namespace kata.test;

public class CharacterTests
{
    [Fact]
    public void DoDamageToCharacter_StillAlive()
    {
        var character = new Character();

        character.DoDamage(100);

        character.alive.Should().BeTrue();
    }

    [Fact]
    public void DoDamageToCharacter_NotAlive()
    {
        var character = new Character();

        character.DoDamage(2000);

        character.alive.Should().BeFalse();
    }

    [Fact]
    public void HealCharacter_ToFull()
    {
        var character = new Character();

        character.DoDamage(500);
        character.Heal(1000);

        character.health.Should().Be(Character.maxHealth);
    }

    [Fact]
    public void CannotHealDeadCharacter()
    {
        var character = new Character();

        character.DoDamage(1000);
        character.Heal(1000);

        character.alive.Should().BeFalse();
    }
}
