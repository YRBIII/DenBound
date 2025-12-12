using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Moves objects with a specific tag back to a respawn point when triggered
public class MoveToRespawnPointOnTrigger : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private string tagToRespawn;

    // Detects when a tagged object enters the trigger and respawns it
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tagToRespawn)) return;

        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.transform.position = respawnPoint.position;
    }
}
