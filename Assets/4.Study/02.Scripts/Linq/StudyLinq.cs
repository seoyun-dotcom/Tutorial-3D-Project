using UnityEngine;
using System.Linq;

public class StudyLinq : MonoBehaviour
{
    // var result = from 변수 in Collection
    //              where 조건
    //              select 조건을 통과한 대상
    public int[] numbers = { 1, 2, 3, 4, 5 };

    private void Start()
    {
        //where: 조건을 뜻함 3보다 큰숫자
        //    var result = from number in numbers 
        //                 where number > 3 
        //                 select number;
        //    Debug.Log(result);

        //위에 세줄 람다식으로 줄임
        var result = numbers.Where(n => n > 3);

        foreach (var n in result)
            Debug.Log(n);
    }

}
