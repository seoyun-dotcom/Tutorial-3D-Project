using System.Collections.Generic;
using UnityEngine;

public class DinamicArray : MonoBehaviour
{
    public List<int> list1 = new List<int>() { 1, 2, 3 };

    void Start()
    {
        list1.Add(10);//�������� 10 �߰���

        for(int i=0; i<10; i++)//0~9���� ���� �߰�
        {
            list1.Add(i);
        }

        list1.Insert(5,100);//6��°���� 100
    }
}
