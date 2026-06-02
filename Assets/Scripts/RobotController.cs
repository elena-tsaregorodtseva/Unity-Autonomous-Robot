using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        transform.Translate(
            Vector3.right * move * moveSpeed * Time.deltaTime,
            Space.Self);

        transform.Rotate(
            Vector3.up * turn * turnSpeed * Time.deltaTime);
    }
}