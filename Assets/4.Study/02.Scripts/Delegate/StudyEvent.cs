using UnityEngine;

public class StudyEvent : MonoBehaviour
{
    public delegate void InputKeyHandler(string msg);
    public event InputKeyHandler onInputKey;
    private void Start()
    {
        onInputKey += Event1;

        //onInputKey += delegate
        //{
        //    Event1("Hello Unity");
        //    Event2();
        //    Event3();
        //};
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            onInputKey?.Invoke("Hello Unity");
        }
    }
    void Event1(string msg)
    {
        Debug.Log(msg);
    }
    void Event2()
    {
        Debug.Log("Event2");
    }
    void Event3()
    {
        Debug.Log("Event3");
    }
}
