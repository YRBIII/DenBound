using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnWhenDestroyed : EffectOnDestroy
{
    [SerializeField] private Transform respawnPosition; 
    public override void PlayEffect() 
    {
        transform.position = respawnPosition.position;
    }
}
