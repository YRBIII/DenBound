using UnityEngine;
using UnityEngine.SceneManagement;

public class BeaconTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        SceneManager.LoadScene(nextSceneName);
    }
}
