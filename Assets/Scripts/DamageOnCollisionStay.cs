using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Deals continuous damage to objects while they stay in contact
public class DamageOnCollisionStay : MonoBehaviour
{
    [SerializeField] private float damageToDeal = 1f;
    [SerializeField] IDamageable.DamageType type = IDamageable.DamageType.Spike;

    // Applies damage every frame an object remains in collision
    private void OnCollisionStay(Collision other)
    {
        other.gameObject.GetComponent<IDamageable>()
            .Damage(damageToDeal * Time.deltaTime, type);
    }
}
