using System.Collections.Generic;
using UnityEngine;

public class DinamicArray : MonoBehaviour
{
    public List<int> list1 = new List<int>() { 1, 2, 3 };

    void Start()
    {
        list1.Add(10);//마지막에 10 추가됨

        for(int i=0; i<10; i++)//0~9까지 값을 추가
        {
            list1.Add(i);
        }

        list1.Insert(5,100);//6번째값에 100
    }
}
