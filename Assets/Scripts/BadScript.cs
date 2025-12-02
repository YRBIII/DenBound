using UnityEngine;
using Unity.Profiling;

public class BadScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("BadScript is ALIVE");
    }

    static ProfilerMarker marker = new ProfilerMarker("Yung_BADSCRIPT");

    void Update()
    {
        marker.Begin();

        // Force CPU cost so Unity displays it clearly
        for (int i = 0; i < 200000; i++)
        {
            Mathf.Sqrt(i);
        }

        marker.End();
    }
}
