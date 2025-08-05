using UnityEngine;
using UnityEngine.UI;

public class StudyDelegate : MonoBehaviour
{
    //Delegate: 대리자
    //함수 참조 역할
//접근제한자 키워드 반환타입 변수명(매개변수(함수명))
    public delegate void MyDelegate();
    public static MyDelegate onKeyDown;

    public KeyCode keyCode = KeyCode.Space;
    public float timer;
    public bool isTimer = true;

    public Button button;

    private void Start()
    {
        #region 간략하게
        //옛날방식 호출
        //myDelegate = new MyDelegate(Method);
        //myDelegate();

        //요즘호출
        //myDelegate = MethodA;

        //myDelegate += MethodB;
        //myDelegate += MethodC;
        //myDelegate -= MethodB;

        //myDelegate = MethodB;


        //?: null이 아니라면 실행하겠다. (참조오류 대비)
        //null 체크 연산자
        //myDelegate?.Invoke(10,20);
        #endregion

        AddMethod(Respond);
        AddMethod(StopTimer);
        AddMethod(StopBomb);
        
        button.onClick.AddListener(Respond);
        button.onClick.AddListener(StopTimer);
        button.onClick.AddListener(StopBomb);

    }
    private void Update()
    {
        if(isTimer)
        {
            timer += Time.deltaTime;
        }
        // 버튼을 누른 이벤트 발생
        if (Input.GetKeyDown(keyCode))
        {
            onKeyDown?.Invoke();
        }
    }
    void AddMethod(MyDelegate myDelegate)
    {
        onKeyDown += myDelegate;
    }
    void Respond()
    {
        Debug.Log($"키가 눌렸습니다");
    }
    void StopTimer()
    {
        isTimer = false;
        Debug.Log("타이머 정지");
    }

    private void StopBomb()
    {
        Debug.Log("폭탄 기능 정지");
    }


}
