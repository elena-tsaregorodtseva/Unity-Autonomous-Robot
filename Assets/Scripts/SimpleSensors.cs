using UnityEngine;

public class SimpleSensors : MonoBehaviour
{
    public float sensorLength = 20f;

    void Update()
    {
        Debug.DrawRay(
            transform.position,
            transform.right * sensorLength,
            Color.red);
    }
}