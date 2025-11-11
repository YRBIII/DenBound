using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton so we can call this from anywhere
    private AudioSource aS;              // The AudioSource we actually play sounds from

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep it alive across scenes

            // Make sure we have an AudioSource to play clips
            aS = GetComponent<AudioSource>();
            if (aS == null)
                aS = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject); // Only one AudioManager allowed
        }
    }

    private void OnEnable()
    {
        ObjectStatus.onDamage += PlaySound; // Hook into damage events to play sounds
    }

    public void PlaySound(AudioClip clip, float volume = 1f, bool loop = false)
    {
        if (clip == null || aS == null) return; // Stops from crashing if missing something

        aS.volume = volume;
        aS.loop = loop;
        aS.PlayOneShot(clip); // Play the sound once
    }

    private void OnDisable()
    {
        ObjectStatus.onDamage -= PlaySound; // Cleans up
    }
}
