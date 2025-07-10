﻿using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();//오브젝트에 들어갈 큐

    public GameObject objPrefab;//생성할 오브젝트
    public Transform parent;//계측 구조상 들어갈 부모 오브젝트

    private void Start()
    {
        CreateObject();
    }

    void CreateObject()//오브젝트를 생성하는 기능 -> Pool을 채우는 기능
    {
        for(int i = 0; i < 30; i++)
        {
            GameObject obj = Instantiate(objPrefab,parent);//오브젝트를 생성하고, 계층구조

            EnqueueObject(obj);
        }
    }

    public void EnqueueObject(GameObject newObj)//안에 집어넣는 함수
    {
        newObj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        newObj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        objQueue.Enqueue(newObj);
        newObj.SetActive(false);// 오브젝트가 작동되지 않도록 Active -> false
    }

    public GameObject DequeueObject()//꺼내쓰는 함수
    {
        if (objQueue.Count < 10)
            CreateObject();
        
        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);

        return obj;   
    }
}
