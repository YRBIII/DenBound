using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Respawns the object at a specified location when it is destroyed
public class RespawnWhenDestroyed : EffectOnDestroy
{
    [SerializeField] private Transform respawnPosition;

    // Moves the object to the respawn position when the destroy effect is triggered
    public override void PlayEffect()
    {
        transform.position = respawnPosition.position;
    }
}
