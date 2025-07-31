using UnityEngine;

public class Movement : MonoBehaviour
{
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);//크기와 방향이 있는 벡터
        dir.Normalize();//방향만 있는 벡터 (방향을갖고 크기가 1)

        transform.position += dir * Time.deltaTime * 5f;
    }
}
