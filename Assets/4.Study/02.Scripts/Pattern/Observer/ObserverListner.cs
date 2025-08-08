using UnityEngine;

public class ObserverListner : MonoBehaviour, IObserver
{
    public ISubject subject;

    void OnEnable()
    {
        subject.AddObserver(this);
    }

    void OnDisable()
    {
        subject.RemoveObserver(this);
    }

    public void Notify(int score)
    {
        Debug.Log("보스 몬스터 처치");
    }
}