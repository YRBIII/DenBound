using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource aS;

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

    private void OnEnable()
    {
        ObjectStatus.onDamage += PlaySound;
    }

    public void PlaySound(AudioClip clip, float volume = 1f, bool loop = false)
    {
        if (clip == null || aS == null) return;

        aS.volume = volume;
        aS.loop = loop;
        aS.PlayOneShot(clip);
    }

    public void StopAllMusicIfAny()
    {
        if (aS != null)
            aS.Stop();         // <<< NEW — stops previous background music
    }

    private void OnDisable()
    {
        ObjectStatus.onDamage -= PlaySound;
    }
}
