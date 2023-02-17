using UnityEngine;

public class Perftest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Trace.Log(Application.targetFrameRate);
    }
}
