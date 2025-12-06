using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickDamage : MonoBehaviour
{
    [SerializeField] private float damagePerSecond = 5f;
    [SerializeField] private PlayerStatus player;

    private void Start()
    {
        // Auto-find player if not assigned
        if (player == null)
            player = FindAnyObjectByType<PlayerStatus>();
    }

    private void Update()
    {
        if (player != null)
        {
            player.Damage(damagePerSecond * Time.deltaTime, IDamageable.DamageType.Cold);
        }
    }
}

