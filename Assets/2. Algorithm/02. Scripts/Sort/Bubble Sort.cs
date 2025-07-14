﻿using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    private int[] array = { 5, 8, 9, 2, 4, 5, 1, 3 };

    private void Start()
    {
        Debug.Log("정렬 전: " + string.Join(",", array));

        Bubble(array);
        Debug.Log("정렬 후: " + string.Join(",", array));
    }

    void Bubble(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}
