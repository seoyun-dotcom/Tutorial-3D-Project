using System.Collections.Generic;
using UnityEngine;

public class StudyQueue : MonoBehaviour
{
    public Queue<int> queue = new Queue<int>();

    private void Start()
    {
        for(int i = 0; i<=10;i++)
        {
            queue.Enqueue(i);//1~10까지 추가
        }

        int output = queue.Dequeue();//값을 뽑음
        Debug.Log(output);

        Debug.Log(queue.Peek());//그 다음에 뽑을 값을 확인

        Debug.Log(queue.Contains(5));//값 5가 포함되어있는지 확인

        queue.Clear();//모든 값 삭제

        Debug.Log(queue.Count);//갯수 확인
    }
}
