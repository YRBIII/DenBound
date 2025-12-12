using UnityEngine;
using UnityEngine.SceneManagement;

// Triggers a scene change when the player enters the beacon area
public class BeaconTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "";

    // Loads the next scene when the player enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        SceneManager.LoadScene(nextSceneName);
    }
}
