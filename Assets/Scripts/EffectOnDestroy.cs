using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for effects that should run when an object is destroyed
public abstract class EffectOnDestroy : MonoBehaviour
{
    // Can be overridden by child classes to define custom destroy behavior
    public virtual void PlayEffect() { }
}
