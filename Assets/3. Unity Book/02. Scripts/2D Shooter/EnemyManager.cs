using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingleTon<EnemyManager>
{
    public int poolSize = 10;

    //public GameObject[] enemyObjectPool;//배열
    //public List<GameObject> enemyObjectPool;//리스트
    public Queue<GameObject> enemyObjectPool;//큐

    public Transform[] spawnPoints;

    public GameObject enemyFactory;

    float currentTime;//타이머
    private float minTime = 1;
    private float maxTime = 5;
    public float createTime = 1;//생성주기

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        //enemyObjectPool = new GameObject[poolSize];//배열
        //enemyObjectPool = new List<GameObject>();//리스트
        enemyObjectPool = new Queue<GameObject>();//큐

        for(int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            //enemyObjectPool[i] = enemy;//배열
            //enemyObjectPool.Add(enemy);//리스트
            enemyObjectPool.Enqueue(enemy);//큐

            enemy.SetActive(false);
        }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        //랜덤한 시간이 될때마다 랜덤한 위치에 Enemy 생성
        if(currentTime > createTime)
        {
            //큐
            if(enemyObjectPool.Count > 0)
            {
                currentTime = 0f;
                createTime = Random.Range(minTime, maxTime);

                GameObject enemy = enemyObjectPool.Dequeue();

                int randomIndex = Random.Range(0, spawnPoints.Length);
                Transform spqwnPoint = spawnPoints[randomIndex];

                enemy.transform.position = spqwnPoint.position;
                enemy.SetActive(true);
            }



            //리스트
            //if (enemyObjectPool.Count > 0 )
            //{
            //    currentTime = 0f;
            //    createTime = Random.Range(minTime, maxTime);

            //    GameObject enemy = enemyObjectPool[0];
            //    enemyObjectPool.Remove(enemy);

            //    int randomIndex = Random.Range(0, spawnPoints.Length);
            //    Transform spqwnPoint = spawnPoints[randomIndex];

            //    enemy.transform.position = transform.position;
            //    enemy.SetActive(true);
            //}


            ///배열
            //for (int i = 0;i < poolSize;i++)
            //{
            //    GameObject enemy = enemyObjectPool[i];
            //    if(!enemy.activeSelf)
            //    {
            //        int randomIndex = Random.Range(0, spawnPoints.Length);
            //        Transform spqwnPoint = spawnPoints[randomIndex];

            //        enemy.transform.position = spqwnPoint.position;
            //        enemy.SetActive(true);

            //        break;
            //    }
            //}
        }
    }
}
