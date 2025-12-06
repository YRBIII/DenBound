public interface IDamageable
{
    enum DamageType
    {
        Fire,
        Spike,
        Explosion,
        Falling,
        Poison,
        Cold
    };
    void Damage(float damage, DamageType type);
}
