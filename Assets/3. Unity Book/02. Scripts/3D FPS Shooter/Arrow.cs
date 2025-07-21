using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float moveSpeed = 100f;
    public bool isMove = true;
    void Update()
    {
        if (isMove)
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
