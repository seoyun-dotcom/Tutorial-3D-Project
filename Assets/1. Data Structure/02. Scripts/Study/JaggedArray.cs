using UnityEngine;

public class JaggedArray : MonoBehaviour
{
    public int[] array1 = new int[3];
    public int[][] jaggedArray1 = new int[3][];
    //int타입 배열이 3개

    void Start()
    {
        array1[0] = 1;
        array1[1] = 2;
        array1[2] = 3;

        jaggedArray1[0] = new int[3] { 1, 2, 3 };
        jaggedArray1[1] = new int[2] {4, 5 };
        jaggedArray1[2] = new int[5] {6,7,8,9,10 };
    }
}
