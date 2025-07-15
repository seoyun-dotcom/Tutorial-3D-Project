using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;

    public GameObject bulletFactory;
    public GameObject firePosition;

    void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * speed * Time.deltaTime;
    }
}
