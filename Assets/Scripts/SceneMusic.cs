using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    [SerializeField] private AudioClip music;

    private void Start()
    {
        // stop any music from the previous scene
        if (AudioManager.instance != null)
            AudioManager.instance.StopAllMusicIfAny();

        // then play this scene’s background music
        var source = GetComponent<AudioSource>();
        if (source != null && music != null)
        {
            source.loop = true;
            source.clip = music;
            source.Play();
        }
    }
}
