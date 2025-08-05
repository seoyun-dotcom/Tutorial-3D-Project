using System.Collections;
using UnityEngine;

public class StudyCoroutine : MonoBehaviour
{
    private IEnumerator enumerator;

    void Start()
    {
        enumerator = Numbers();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enumerator.MoveNext();
            var result = enumerator.Current;

            Debug.Log(result);
        }
    }

    IEnumerator Numbers()
    {
        yield return "어서오세요";
        yield return "과일판매중이에요";
        yield return "구경하세요";

        yield return null;
    }
}