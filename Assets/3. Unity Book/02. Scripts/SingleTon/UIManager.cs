using UnityEngine;

public class UIManager : SingleTon<UIManager>
{
    protected override void Awake()
    {
        base.Awake();

        Debug.Log($"추가 할 기능");
    }
}
