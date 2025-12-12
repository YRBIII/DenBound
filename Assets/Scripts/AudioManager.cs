using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages all game audio and ensures sounds persist across scenes
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource aS;

    // Creates a single persistent AudioManager instance
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            aS = GetComponent<AudioSource>();
            if (aS == null)
                aS = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Listens for damage events to play sound effects
    private void OnEnable()
    {
        ObjectStatus.onDamage += PlaySound;
    }

    // Plays a sound effect with optional volume and looping
    public void PlaySound(AudioClip clip, float volume = 1f, bool loop = false)
    {
        if (clip == null || aS == null) return;

        aS.volume = volume;
        aS.loop = loop;
        aS.PlayOneShot(clip);
    }

    // Stops any currently playing background music
    public void StopAllMusicIfAny()
    {
        if (aS != null)
            aS.Stop();
    }

    // Stops listening for damage events when disabled
    private void OnDisable()
    {
        ObjectStatus.onDamage -= PlaySound;
    }
}
