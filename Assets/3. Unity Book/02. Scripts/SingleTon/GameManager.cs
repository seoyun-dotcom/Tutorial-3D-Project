using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    protected override void Awake()
    {
        base.Awake();

        Debug.Log($"추가 할 기능");
    }
}
