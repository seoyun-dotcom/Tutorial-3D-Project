using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    private enum EnemyState { Idle, Move, Attack, Return, Damaged, Die}
    private EnemyState m_State;

    private Transform player;//타겟
    private CharacterController cc;

    public Animator anim;
    private NavMeshAgent smith;

    public float findDistance = 8f;//탐지거리
    public float attackDistance = 3f;//공격가능거리
    public float moveSpeed = 5f;//이동속도

    private float currentTime = 0f;
    private float attackDelay = 2f;

    public int attackPower = 3;
    public int hp = 15;
    public int MaxHp = 15;
    public Slider hpSlider;


    private Vector3 originPos;
    private Quaternion originrot;
    public float moveDistance = 20f;


    private void Start()
    {
        m_State = EnemyState.Idle;

        player = GameObject.Find("Player").transform;

        cc = GetComponent<CharacterController>();
        originPos = transform.position;
        transform.rotation = originrot;
        anim = transform.GetComponentInChildren<Animator>();
        smith = GetComponent<NavMeshAgent>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                //Demaged();
                break;
            case EnemyState.Die:
                //Die();
                break;
        }

        hpSlider.value = (float)hp/(float)MaxHp;
    }

    void Idle()
    {
        if(Vector3.Distance(transform.position, player.position) < findDistance)
        {
            anim.SetTrigger("IdleToMove");
            m_State = EnemyState.Move;
            Debug.Log("상태전환: Idle -> Move");
        }
    }

    void Move()
    {
        if(Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State=EnemyState.Return;
            Debug.Log("상태전환: Move -> Return");

        }
        else if(Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            //Vector3 dir = (player.position - transform.position).normalized;
            //cc.Move(dir * moveSpeed * Time.deltaTime);
            //transform.forward = dir;//이동방향을 정면으로 적용

            smith.isStopped = true;
            smith.ResetPath();

            smith.stoppingDistance = attackDistance;
            smith.SetDestination(player.position);
        }
        else
        {
            currentTime = attackDelay;
            m_State = EnemyState.Attack;
            anim.SetTrigger("MoveToAttackDelay");
            Debug.Log("상태전환: Move -> Attack");
        }

    }

    void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime;
            if(currentTime > attackDelay)
            {
                currentTime = 0f;
                anim.SetTrigger("StartAttack");
                Debug.Log("공격");
            }
        }
        else//공격범위 밖에있을 경우 -> Move로 전환
        {
            currentTime = 0f;
            m_State = EnemyState.Move;
            anim.SetTrigger("AttackToMove");
            Debug.Log("상태전환: Attack -> Move");
        }

    }

    public void AttackAction()
    {
        player.GetComponent<FPSPlayerMove>().DamagedAction(attackPower);
    }

    void Return()
    {
        if (Vector3.Distance(transform.position, originPos) > 0.1f)//원래 위치가 아닌 경우 -> 원래 위치로 이동
        {
            //Vector3 dir = (originPos - transform.position).normalized;
            //cc.Move(dir * moveSpeed * Time.deltaTime);
            //transform.forward = dir;//이동방향을 정면으로 적용

            smith.SetDestination(originPos);
            smith.stoppingDistance = 0f;
        }
        else//원래 위치로 도착한 경우
        {
            smith.isStopped = true;
            smith.ResetPath();

            transform.position = originPos;
            transform.rotation = originrot;
            hp = 15;
            anim.SetTrigger("MoveToIdle");
            m_State = EnemyState.Idle;
            Debug.Log("상태전환: Return -> Idle");
        }
    }

    public void HitEnemy(int hitPower)
    {
        if(m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return)
            return;


        hp -= hitPower;

        smith.isStopped = true;
        smith.ResetPath();

        if (hp > 0)//공격받았는데 살았다면
        {
            anim.SetTrigger("Damaged");
            m_State = EnemyState.Damaged;
            Debug.Log("상태전환: Any State -> Damaged");
            Damaged();
        }
        else//공격받아서 죽었다면
        {
            anim.SetTrigger("Die");
            m_State = EnemyState.Die;
            Debug.Log("상태전환: Any State -> Die");
            Die();
        }
    }

    void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(1f);//피격 애니메이션만큼 대기

        m_State = EnemyState.Move;
        Debug.Log("상태전환: Damaged -> Move");
    }

    void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false;

        yield return new WaitForSeconds(2f);
        Debug.Log("소멸");
        Destroy(gameObject);
    }
}
