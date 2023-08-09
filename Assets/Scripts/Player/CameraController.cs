using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float speed = 8f;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -12.5f);
    }
}
