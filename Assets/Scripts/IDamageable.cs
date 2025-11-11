public interface IDamageable
{
    enum DamageType
    {
        Fire,
        Spike,
        Explosion,
        Falling,
        Poison
    };
    void Damage(float damage, DamageType type);
}
