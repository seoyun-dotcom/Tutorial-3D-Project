using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StudyUnityAction : MonoBehaviour
{
    public UnityAction unityAction;
    public Button button;
    private void Start()
    {
        unityAction += MethodA;

        button.onClick.AddListener(MethodA);

        button.onClick.AddListener(() =>
        {
            Debug.Log("Hello");
            MethodA();
        });
    }
    void MethodA()
    {
        Debug.Log("MethodA");
    }
}
