using System.Collections.Generic;
using UnityEngine;

public class BreadthFirstSearch : MonoBehaviour
{
    private int[,] nodes = new int[8, 8]
    {
        //0  1  2  3  4  5  6  7
        { 0, 1, 1, 1, 0, 0, 0, 0},//0
        { 1, 0, 0, 0, 1, 1, 0, 0},//1
        { 1, 0, 0, 0, 0, 0, 0, 0},//2
        { 1, 0, 0, 0, 0, 0, 1, 0},//3
        { 0, 1, 0, 0, 0, 1, 0, 0},//4
        { 0, 1, 0, 0, 0, 1, 0, 1},//5
        { 0, 0, 0, 1, 0, 0, 0, 0},//6
        { 0, 0, 0, 0, 0, 1, 0, 0},//7

    };


    public Queue<int> queue = new Queue<int>();
    private bool[] visited = new bool[8];

    private void Start()
    {
        DFSearch(0);
    }

    void DFSearch(int start)
    {
        queue.Enqueue(start);//0번에 방문하겠다.

        while (queue.Count > 0)
        {
            int index = queue.Dequeue();

            if (!visited[index])//방문했는지 안했는지
            {
                visited[index] = true;//방문완료설정
                Debug.Log($"{index}번 노드에 방문");

                for (int i = 0; i < nodes.GetLength(0); i++)
                {
                    if (nodes[index, i] == 1 && !visited[i])
                    {
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
