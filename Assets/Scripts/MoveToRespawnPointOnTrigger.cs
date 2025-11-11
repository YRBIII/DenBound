using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MoveToRespawnPointOnTrigger : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private string tagToRespawn; 
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tagToRespawn)) return;
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.transform.position = respawnPoint.position;
    }
}
