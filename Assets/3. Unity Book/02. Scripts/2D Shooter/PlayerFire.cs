#define DEBUG_TEST

using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : SingleTon<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;
    //public GameObject[] bulletObjectPool;//배열
    //public List<GameObject> bulletObjectPool;//리스트
    public Queue<GameObject> bulletObjectPool;//큐

    /*
    //void Start()
    //{
    //    bulletFactory = Resources.Load<GameObject>("Bullet");
    //}
    */

    private void Start()
    {
        //bulletObjectPool = new GameObject[poolSize];//배열
        //bulletObjectPool = new List<GameObject>();//리스트
        bulletObjectPool = new Queue<GameObject>();//큐

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            //bulletObjectPool[i] = bullet;//배열
            //bulletObjectPool.Add(bullet);//리스트
            bulletObjectPool.Enqueue(bullet);//큐

            bullet.SetActive(false);

        }
    }

    void Update()
    {
#if UNITY_STANDALONE || UNITY_EDITOR || DEBUG_TEST
        if(Input.GetButtonDown("Fire1"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //큐
                if(bulletObjectPool.Count > 0)
                {
                    GameObject bullet = bulletObjectPool.Dequeue();
                    bullet.SetActive(true);
                    bullet.transform.position = firePosition.transform.position;
                }

                //리스트
                //if (bulletObjectPool.Count > 0)
                //{



                //    //GameObject bullet = bulletObjectPool[0];// 가져올 오브젝트 선택
                //    //bullet.SetActive(true);// 오브젝트 사용

                //    //bulletObjectPool.Remove(bullet);// Pool에서 오브젝트 제거

                //    //bullet.transform.position = firePosition.transform.position;
                //}
            }
            /*
            for (int i = 0;i < poolSize;i++)
            {

                GameObject bullet = bulletObjectPool[i];
                if(!bullet.activeSelf)//선택한 총알오브젝트가 비활성화 상태인지 확인
                {
                    bullet.SetActive(true);//총알 사용하기위해 활성화
                    //발사 위치 조정
                    bullet.transform.position = firePosition.transform.position;

                    break;//반복문 종료
                }
            */

        }

#elif UNITY_ANDROID || UNITY_IOS
        if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
        }
#else
        Debug.log("그 외 나머지 플랫폼");

#endif
    }
}
