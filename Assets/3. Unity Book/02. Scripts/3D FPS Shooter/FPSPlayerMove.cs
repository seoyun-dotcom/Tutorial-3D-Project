using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSPlayerMove : MonoBehaviour
{
    private CharacterController cc;
    private Animator anim;

    public float moveSpeed = 7f;

    private float gravity = -20f;
    private float yVelocity = 0f;

    public float jumpPower = 10f;
    public bool isJumping = false;

    public int hp = 20;

    private int MaxHp = 20;
    public Slider hpSlider;

    public GameObject hitEffect;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if(FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);//크기와 방향이 있는 벡터
        dir.Normalize();//방향만 있는 벡터 (방향을갖고 크기가 1)

        anim.SetFloat("Move Motion", dir.magnitude);

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

    public void DamagedAction(int damage)
    {
        hp -= damage;

        hpSlider.value = (float)hp / (float)MaxHp;

        if(hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        hitEffect.SetActive(false);
    }
}
