using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles background music playback for a specific scene
public class SceneMusic : MonoBehaviour
{
    [SerializeField] private AudioClip music;

    // Stops any existing music and starts this scene’s background track
    private void Start()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.StopAllMusicIfAny();

        var source = GetComponent<AudioSource>();
        if (source != null && music != null)
        {
            source.loop = true;
            source.clip = music;
            source.Play();
        }
    }
}
