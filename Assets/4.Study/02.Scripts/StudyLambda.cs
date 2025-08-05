using UnityEngine;
using UnityEngine.UI;

public class StudyLambda : MonoBehaviour
{
    public delegate void Mydelegate(string s);
    public Mydelegate mydelegate;
    public Button button;

    private void Start()
    {
        /*mydelegate += NoNameMethod;
        //mydelegate += delegate(string s)
        //{
        //    OnLog(s);
        //};

        mydelegate?.Invoke("Hello Unity");
        */

        // 버튼에 1개의 기능을 등록하는 방법
        button.onClick.AddListener(ButtonEvent);
        // button.onClick.AddListener(OnLog("Hello")); // 사용 X

        // 익명함수로 여러 기능을 등록하는 방법
        button.onClick.AddListener(delegate
        {
            ButtonEvent();
            OnLog("Lambda");
        });

        // 람다식으로 1개의 기능을 등록하는 방법
        button.onClick.AddListener(() => OnLog("Hello"));

        // 람다식으로 여러 기능을 등록하는 방법
        button.onClick.AddListener(() =>
        {
            ButtonEvent();
            OnLog("Lambda");
        });
    }
    private void ButtonEvent()
    {
        Debug.Log("Button Event");
    }
    void OnLog(string s)
    {
        Debug.Log(s);
    }
    /*void NoNameMethod()
    //{
    //    OnLog();
    //    OnLog();
    //    OnLog();
    //    OnLog();
    //}
    */
}
