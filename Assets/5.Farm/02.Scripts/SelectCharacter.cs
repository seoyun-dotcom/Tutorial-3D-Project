using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private Transform centerPivot;

    [SerializeField] private Animator[] characterAnims;

    [SerializeField] private Button[] turnButtons;//0:Left,1:Right
    [SerializeField] private Button selectButton;

    private int currentIndex;
    private bool isTurn;

    private void Start()
    {

        turnButtons[0].onClick.AddListener(() => Turn(true));
        turnButtons[1].onClick.AddListener(() => Turn(false));

        selectButton.onClick.AddListener(Select);
    }
    void Turn(bool isLeft)
    {
        if(!isTurn)
        {
            int value = isLeft ? -1 : 1;
            currentIndex += value;

            //캐릭터가 4개이기 때문에 0~3까지 범위로 설정
            if(currentIndex < 0)
                currentIndex = 3;
            else if(currentIndex > 3)
                currentIndex = 0;

                float turnValue = value * 90;
                            //현재회전상태                   //회전
            var targetRot = centerPivot.transform.rotation * Quaternion.Euler(0, turnValue, 0);

            isTurn = true;
            StartCoroutine(TurnRoutine(targetRot));
        }
    }
    IEnumerator TurnRoutine(Quaternion targetRot)
    {
        while (true)
        {
            yield return null;//while (true)를 사용시 무조건 안에 yield return 필요(무한루프방지)
            //부드럽게회전
            centerPivot.rotation = Quaternion.Slerp(centerPivot.rotation, targetRot, 5f * Time.deltaTime);

            Debug.Log("Turn");

            var angle = Quaternion.Angle(centerPivot.rotation, targetRot);
            if(angle <= 0.1f)
            {
                isTurn = false;
                Debug.Log("Completed Turn");
                centerPivot.rotation = targetRot;
                yield break;
            }
        }

    }
    void Select()
    {
        Debug.Log($"현재 선택한 캐릭터는 {currentIndex} 입니다.");

        StartCoroutine(SelectRoutine());
    }
    IEnumerator SelectRoutine()
    {
        characterAnims[currentIndex].SetTrigger("Select");
        yield return new WaitForSeconds(3f);

        Fade.onFadeAction?.Invoke(3f, Color.white, true, null);
        yield return new WaitForSeconds(3.5f);

        //LoadScene

    }
}
