// Interface for any object that can take damage in the game
public interface IDamageable
{
    // Different types of damage used for gameplay and effects
    enum DamageType
    {
        Fire,
        Spike,
        Explosion,
        Falling,
        Poison,
        Cold
    };

    // Applies damage to the object based on amount and damage type
    void Damage(float damage, DamageType type);
}
