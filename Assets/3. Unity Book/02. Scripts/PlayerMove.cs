using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * 5 * Time.deltaTime);

        transform.position += Vector3.right * 5 * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
            Debug.Log("마우스 왼쪽버튼 클릭");

        if (Input.GetButtonDown("0"))
            Debug.Log("마우스 왼쪽버튼 클릭");

        if (Input.GetKeyDown("Space"))
            Debug.Log("스페이스바 클릭");
    }

}
