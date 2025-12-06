using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionStay : MonoBehaviour
{
    [SerializeField] private float damageToDeal = 1f;
    [SerializeField] IDamageable.DamageType type = IDamageable.DamageType.Spike;
    private void OnCollisionStay(Collision other)
    {
        other.gameObject.GetComponent<IDamageable>().Damage(damageToDeal * Time.deltaTime, type);
    }
}
