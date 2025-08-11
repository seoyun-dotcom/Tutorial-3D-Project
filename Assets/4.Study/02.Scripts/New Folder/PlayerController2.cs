using UnityEngine;
using UnityEngine.InputSystem;


namespace NewInputSystem
{
    public class PlayerController2 : MonoBehaviour
    {
        private CharacterController cc;

        private PlayerInput playerInput;
        private InputAction moveAction;
        private InputAction jumpAction;

        private Vector2 moveInput;
        public float speed = 5f;

        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();

            moveAction = playerInput.actions.FindAction("Move");
            jumpAction = playerInput.actions.FindAction("Jump");

            cc = GetComponent<CharacterController>();
        }
        private void OnEnable()
        {
            moveAction.Enable();
            moveAction.performed += MoveStart;
            moveAction.canceled += MoveCancel;

            jumpAction.Enable();
            jumpAction.performed += Jump;
        }
        private void OnDisable()
        {
            moveAction.Disable();
            moveAction.performed -= MoveStart;
            moveAction.canceled -= MoveCancel;

            jumpAction.Disable();
            jumpAction.performed -= Jump;
        }

        private void Update()
        {
            var dir = new Vector3(moveInput.x, 0, moveInput.y).normalized;
            Debug.Log(dir);

            cc.Move(dir * speed * Time.deltaTime);
        }

        public void MoveStart(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        public void MoveCancel(InputAction.CallbackContext context)
        {
            moveInput = Vector2.zero;
        }

        public void Jump(InputAction.CallbackContext context)
        {
                Debug.Log("Jump");
        }
    }
}