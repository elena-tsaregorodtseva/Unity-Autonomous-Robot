using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float turnSpeed = 60f;
    public float stopDistance = 2f;
    public float sensorLength = 2f;

    void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        float distance = direction.magnitude;

        if (distance < stopDistance)
            return;

        RaycastHit hit;
        Vector3 forward = transform.right;
        bool wallInFront = Physics.Raycast(transform.position, forward, out hit, sensorLength);

        if (wallInFront)
        {
            float angleToTarget = Vector3.SignedAngle(transform.right, direction, Vector3.up);
            
            if (Mathf.Abs(angleToTarget) > 30f)
            {
                transform.Rotate(Vector3.up, angleToTarget * turnSpeed * Time.deltaTime / 100f);
            }
            else
            {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
        }
        else
        {
            float angle = Vector3.SignedAngle(transform.right, direction, Vector3.up);
            transform.Rotate(Vector3.up, angle * turnSpeed * Time.deltaTime / 100f);
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * sensorLength);
    }
}
