using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform target;
  
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    private void LateUpdate()
    {
        //플레이어의 x축만 따라가는 기능
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
