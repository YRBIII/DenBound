using System.Collections;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Renderer ren;          // cached Renderer
    IEnumerator coroutine;  // store coroutine

    void Start()
    {
        ren = GetComponent<Renderer>();        // cache Renderer
        coroutine = RandomColorCoroutine();    // assign IEnumerator
        StartCoroutine(coroutine);             // start coroutine
    }

    IEnumerator RandomColorCoroutine()
    {
        while (true) // infinite loop
        {
            ren.material.color = Random.ColorHSV(); // sets to a random color
            yield return new WaitForSeconds(1f);    // waits for one second
        }
    }

    void OnDisable()
    {
        StopCoroutine(coroutine); 
    }
}
