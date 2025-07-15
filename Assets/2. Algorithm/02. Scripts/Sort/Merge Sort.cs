using UnityEngine;

public class MergeSort : MonoBehaviour
{
    private int[] array = { 5, 8, 9, 2, 4, 6, 1, 3 };

    private void Start()
    {
        Debug.Log("정렬 전: " + string.Join(",", array));

        MSort( array, 0, array.Length - 1);
        Debug.Log("정렬 후: " + string.Join(",", array));
    }

    void MSort(int[] arr, int left, int right)
    {
        if(left<right)
        {
            int mid = left + (right - left) / 2;

            MSort(arr, left, mid);
            MSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;//왼쪽 배열의 크기
        int n2 = right - mid;//오른쪽 배열의 크기

        int[] leftarr = new int[n1];//임시배열 크기 설정
        int[] rightarr = new int[n2];//임시배열 크기 설정

        for (int i = 0; i < n1; i++)//왼쪽 배열 값 초기화
            leftarr[i] = arr[left + i];

        for (int i = 0; i < n2; i++)//오른쪽 배열 값 초기화
            rightarr[i] = arr[mid + 1 + i];

        int j = left;//기존배열의 시작점
        int u = 0, v = 0;//반복문을 돌기위한 임시 변수

        while(u < n1 && v < n2)
        {
            if (leftarr[u] <= rightarr[v])//왼쪽값이 오른쪽 값보다 작다면
            {
                arr[j] = leftarr[u];
                u++;
            }
            else//오른쪽값이 왼쪽값보다 작다면
            {
                arr[j] = rightarr[v];
                v++;
            }
            j++;
        }

        while(u < n1)//왼쪽배열이 남았다먄
        {
            arr[j] = leftarr[u];
            u++;
            j++;
        }

        while (v < n2)//오른쪽배열이 남았다먄
        {
            arr[j] = rightarr[v];
            v++;
            j++;
        }
      
    }
}
