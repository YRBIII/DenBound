using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] grassClips;
    [SerializeField] private float stepInterval = 0.5f;
    private float stepTimer = 0f;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
    }

    private void PlayFootstep()
    {
        if (grassClips.Length > 0)
        {
            int index = Random.Range(0, grassClips.Length);
            AudioManager.instance.PlaySound(grassClips[index], 0.5f);
        }
    }
}

