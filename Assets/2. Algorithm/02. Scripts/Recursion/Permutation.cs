using UnityEngine;

public class Permutation : MonoBehaviour
{
    public int[] array = new int[3] { 1, 2, 3 };

    private void Start()
    {
        PermutationFunction(array,0);
    }

    void PermutationFunction(int[] arr, int start)
    {
        if(start == array.Length)
        {
            Debug.Log(string.Join(",", arr));
            return;
        }

        for(int i = start; i<arr.Length;i++)
        {
            //swap:자리바꾸기
            var temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;

            PermutationFunction(arr, start + 1);//재귀

            //원상복구 BackTracking
            temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;
        }
    }
}
