using UnityEngine;

public class QuickSort : MonoBehaviour
{
    private int[] array = { 5, 8, 9, 2, 4, 5, 1, 3 };

    private void Start()
    {
        Debug.Log("정렬 전: " + string.Join(",", array));

        Quick(array, 0, array.Length - 1);
        Debug.Log("정렬 후: " + string.Join(",", array));
    }

    void Quick(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            Quick(arr, left, pivot - 1);
            Quick(arr, pivot + 1, right);
        }
    }

    //피봇을 활용해서 분할하는 기능
    private int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int index = left - 1;

        for (int i =  left; i < right; i++)
        {
            if (arr[i] < pivot)
            {
                index++;

                int temp = arr[i];
                arr[i] = arr[index];
                arr[index] = temp;
            }
        }

        int temp2 = arr[index + 1];
        arr[index + 1] = arr[right];
        arr[right] = temp2;

        return index + 1;
    }
}
