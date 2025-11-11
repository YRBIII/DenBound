using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
