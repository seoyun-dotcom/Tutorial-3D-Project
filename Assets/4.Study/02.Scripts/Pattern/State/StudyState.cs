using Unity.VisualScripting;
using UnityEngine;

public class StudyState : MonoBehaviour
{
    public IState state;

    private IState idleState, moveState, attackState;

    private void Awake()
    {
        idleState = gameObject.AddComponent<IdleState>();
        moveState = gameObject.AddComponent<MoveState>();
        attackState = gameObject.AddComponent<AttackState>();

        state = idleState;
    }

    private void Start()
    {
        state.StateEnter();
    }
    private void OnDestroy()
    {
        state.StateExit();
    }
    private void Update()
    {
        state?.StateUpdate();

        #region 기능 테스트
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetState(new IdleState());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetState(new MoveState());
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetState(new AttackState());
        }
        #endregion
    }
    public void SetState(IState newState)
    {
        if (state != newState)
        {
            state.StateExit(); // 상태 변경 전

            state = newState; // 상태 변경

            state.StateEnter(); // 상태 변경 후
        }
    }
}
