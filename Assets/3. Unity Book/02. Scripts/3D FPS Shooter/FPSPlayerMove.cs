using UnityEngine;

public class FPSPlayerMove : MonoBehaviour
{
    private CharacterController cc;

    public float moveSpeed = 7f;

    private float gravity = -20f;
    private float yVelocity = 0f;

    public float jumpPower = 10f;
    public bool isJumping = false;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);//크기와 방향이 있는 벡터
        dir.Normalize();//방향만 있는 벡터

        //카메라의 transform기준으로 변환
        dir = Camera.main.transform.TransformDirection(dir);

        //중력적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        //캐릭터 컨트롤러에 내장된 이동 기능
        cc.Move(dir * moveSpeed * Time.deltaTime);

        if(cc.collisionFlags == CollisionFlags.Below)
        {
            if(isJumping)
                isJumping = false;
            yVelocity = 0f;
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            yVelocity = jumpPower;//점프하는 순간에 yVelocity를 초기화
        }
    }
}
