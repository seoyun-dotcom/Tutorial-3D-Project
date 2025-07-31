using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class StudyEmitters : MonoBehaviour
{
    public PlayableDirector timeline;
    public SignalReceiver receiver;
    public SignalAsset signal;

    private void Start()
    {
        SetSignalEvent();
    }
    public void OnTimeLineSpeed(float speed)
    {
        //타임라인의 속도제어
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }
    //시그널에 이벤트를 등록하는 함수
    public void SetSignalEvent()
    {
        UnityEvent eventContainer = new UnityEvent();//이벤트를 담는 변수

        eventContainer.AddListener(() => OnTimeLineSpeed(0.2f));//이벤트 등록

        receiver.AddReaction(signal, eventContainer);//signal에 Event 연결
    }
}
