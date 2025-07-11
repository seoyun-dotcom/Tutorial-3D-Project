using UnityEngine;

public class BinarySearch : MonoBehaviour
{
    //BinarySearch는 정렬된 데이터만 사용가능!
    private int[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    private int target = 7;

    private void Start()
    {
        int result = BSearch();//target의 인덱스값
        Debug.Log($"{target}번은 {result}번째에 있습니다.");
    }

    private int BSearch()
    {
        int left = 0;//처음 left 값
        int right = array.Length - 1;//처음 right 값

        while(left<=right)
        {
            int mid = (left + right) / 2;

            if (array[mid] == target)
                return mid;
            else if(array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
}
