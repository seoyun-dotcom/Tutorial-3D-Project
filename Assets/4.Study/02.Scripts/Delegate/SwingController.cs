using System;
using System.Collections;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    private Animator anim;

    public Action onStartSwing;
    public Action onEndSwing;

    private bool isSwing;

    void Start()
    {
        anim = GetComponent<Animator>();

        onStartSwing += SwingStart;
        onEndSwing += SwingEnd;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSwing)
            {
                StartCoroutine(SwingRoutine(onStartSwing,onEndSwing));
            }
        }
    }

    IEnumerator SwingRoutine(Action action1, Action action2)
    {
        isSwing = true;
        anim.SetTrigger("Swing");
        //스윙 애니메이션 실행
        //SwingStart();
        action1?.Invoke();

        //float animLength = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(0.5f);

        //애니메이션종료
        //SwingEnd();
        action2?.Invoke();
        isSwing = false;
    }
    void SwingStart()
    {
        Debug.Log("스윙시작");
    }
    void SwingEnd()
    {
        Debug.Log("스윙종료");
    }
}