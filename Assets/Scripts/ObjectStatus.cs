using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        health = maxHealth;
    }

    public void Damage(float damage, IDamageable.DamageType type)
    {
        health -= damage;              
        onDamage?.Invoke(soundOnDamage, volume, loop); // Trigger any damage sounds

        if (health <= 0)                // Check for death or health loss
        {
            scriptToCallOnAllHealthLost.PlayEffect(); // Calls the effect 

            if (willSurviveEffect)     // respawns
                health = maxHealth;
        }
    }
}
