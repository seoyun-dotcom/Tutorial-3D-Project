using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    #region 간략하게 
    //public StudyDelegate studyDelegate;
   
    //private void Awake()
    //{
    //    StudyDelegate.onKeyDown += StopEvent1;
    //    StudyDelegate.onKeyDown += StopEvent2;

    //}
    //void StopEvent1()
    //{
    //    Debug.Log($"StopEvent1");
    //}
    //void StopEvent2()
    //{
    //    Debug.Log($"StopEvent2");
    //}
    #endregion

    //public StudyEvent studyEvent;

    //private void Awake()
    //{
    //    studyEvent = FindFirstObjectByType<StudyEvent>();
    //}

    //void Start()
    //{
    //    studyEvent.onInputKey += Event1;
    //}

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        studyEvent.onInputKey?.Invoke();
    //    }
    //}

    //private void Event1()
    //{
    //    Debug.Log("Event 1");
    //}
}
