using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Applies continuous (tick-based) damage to the player while active
public class TickDamage : MonoBehaviour
{
    [SerializeField] private float damagePerSecond = 5f;
    [SerializeField] private PlayerStatus player;

    // Finds and caches the PlayerStatus reference if one is not assigned
    private void Start()
    {
        if (player == null)
            player = FindAnyObjectByType<PlayerStatus>();
    }

    // Applies damage every frame based on time passed
    private void Update()
    {
        if (player != null)
        {
            player.Damage(damagePerSecond * Time.deltaTime, IDamageable.DamageType.Cold);
        }
    }
}
