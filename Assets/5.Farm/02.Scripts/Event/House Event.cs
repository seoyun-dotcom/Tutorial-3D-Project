using System;
using Unity.Cinemachine;
using UnityEngine;

public class HouseEvent : MonoBehaviour
{
    [SerializeField] private GameObject houseTop; // 지붕 오브젝트

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어가 집에 들어왔습니다.");
            houseTop.SetActive(false);

            GameManager.Instance.SetCameraState(CameraState.House);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            houseTop.SetActive(true);
            GameManager.Instance.SetCameraState(CameraState.Outside);
        }
    }
}