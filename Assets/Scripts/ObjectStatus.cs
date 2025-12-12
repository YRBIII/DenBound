using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles health, damage, and destruction-related effects for game objects
public class ObjectStatus : MonoBehaviour, IDamageable
{
    public static Action<AudioClip, float, bool> onDamage;

    [Header("Audio Effects")]
    [SerializeField] private AudioClip soundOnDamage;
    [SerializeField][Range(0, 1)] private float volume;
    [SerializeField] private bool loop = false;

    [Header("Script Effects")]
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private EffectOnDestroy scriptToCallOnAllHealthLost;
    [SerializeField] protected float health;
    [SerializeField] private bool willSurviveEffect = false;

    // Initializes the object's health at the start
    private void Awake()
    {
        health = maxHealth;
    }

    // Applies damage, plays effects, and handles what happens when health reaches zero
    public void Damage(float damage, IDamageable.DamageType type)
    {
        health -= damage;
        onDamage?.Invoke(soundOnDamage, volume, loop);

        // Triggers effects when all health is lost
        if (health == 0)
        {
            scriptToCallOnAllHealthLost.PlayEffect();

            // Resets health if the object is meant to survive the effect
            if (willSurviveEffect)
                health = maxHealth;
        }
    }
}
