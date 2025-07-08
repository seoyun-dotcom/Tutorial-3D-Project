using UnityEngine;
using UnityEngine.Rendering;

public class MultiDimensionalArray : MonoBehaviour
{
    public int[,] array1 = new int[3, 3];//행과 열이 3개인 2차원배열
    public int[,,] array2 = new int[3, 3, 3];// 3차원 배열 (큐브모양)
    void Start()
    {
        int number1 = array1[0, 0];
        int number2 = array1[1, 0];
        int number3 = array1[2, 2];
    }

}
