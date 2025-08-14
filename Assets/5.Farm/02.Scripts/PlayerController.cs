using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Farm
{
    public class PlayerController : MonoBehaviour
    {
        private Animator anim;

        //private PlayerInput playerInput;

        private CharacterController cc;
        private Vector3 moveInput;

        private bool isRun;
        private float currentSpeed;
        private float walkSpeed = 2f;
        private float runSpeed = 5f;
        private float turnSpeed = 10f;

        private Vector3 velocity;
        private const float GRAVITY = -9.8f;
        private void Awake()
        {
            int characterIndex = LoadSceneManager.Instance.characterIndex;

            transform.GetChild(characterIndex).gameObject.SetActive(true);
            anim = transform.GetChild(characterIndex).GetComponent<Animator>();

            cc = GetComponent<CharacterController>();
        }
        private void Start()
        {
            
        }
        private void Update()
        {
            velocity.y += GRAVITY * Time.deltaTime;
            var dir = moveInput * currentSpeed + Vector3.up * velocity.y;

            cc.Move(dir * Time.deltaTime);
            Turn();
            SetAnimation();
        }
        void OnMove(InputValue value)
        {
            var move = value.Get<Vector2>();
            moveInput = new Vector3(move.x, 0, move.y);
        }
        void Turn()
        {
            if(moveInput != Vector3.zero)
            {
                //특정방향을바라보는기능
                Quaternion targetRot = Quaternion.LookRotation(moveInput);
                                                      //현재회전          //목표회전             //비율(속도)
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
            }
        }
        void OnRun(InputValue value)
        {
            isRun = value.isPressed;
        }
        void SetAnimation()
        {
            float targetValue = 0f;
            if(moveInput != Vector3.zero)//이동 키를 누를 경우
            {
                targetValue = isRun ? 1f : 0.5f;
                currentSpeed = isRun ? runSpeed : walkSpeed;
            }

            float animValue = anim.GetFloat("Move");
            animValue = Mathf.Lerp(animValue, targetValue, 10f * Time.deltaTime);
            anim.SetFloat("Move", animValue);
        }
    }

}
