using UnityEngine;

public class AutoPilot : MonoBehaviour
{
    public float speed = 2f;
    public float turnSpeed = 120f;
    public float sensorLength = 2f;
    public float sensorOffset = 0.5f;

    void Update()
    {
        RaycastHit hit;
        
        Vector3 sensorPos = transform.position + transform.forward * sensorOffset;
        Vector3 forward = transform.right;

        bool blocked = Physics.Raycast(sensorPos, forward, out hit, sensorLength);

        if (blocked)
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(forward * speed * Time.deltaTime, Space.World);
        }
    }

    void OnDrawGizmos()
    {
        Vector3 sensorPos = transform.position + transform.forward * sensorOffset;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(sensorPos, transform.right * sensorLength);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(sensorPos, 0.1f);
    }
}