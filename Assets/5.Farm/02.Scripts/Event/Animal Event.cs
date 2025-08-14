using System;
using Random = UnityEngine.Random;
using UnityEngine;

public class AnimalEvent : MonoBehaviour
{
    [SerializeField] private GameObject flag;
    [SerializeField] private GameObject followTarget;

    private BoxCollider boxCollider;

    public static Action failAction;

    private float timer;
    private bool isTimer;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        failAction += SetRandomPosition;
    }
    private void Update()
    {
        if (!isTimer)
            return;

        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTimer = true;
            SetRandomPosition();

            followTarget.SetActive(true);

            GameManager.Instance.SetCameraState(CameraState.Animal);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"깃발을 찾는데 걸린 시간은 {timer:F1}입니다.");
            isTimer = false;
            timer = 0f;

            SetFlag(Vector3.zero, false);
            GameManager.Instance.SetCameraState(CameraState.Outside);
            followTarget.SetActive(false);
        }
    }
    void SetRandomPosition()
    {
        float randomX = Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
        float randomZ = Random.Range(boxCollider.bounds.min.z, boxCollider.bounds.max.z);

        var randomPos = new Vector3 (randomX, 0f, randomZ);

        SetFlag(randomPos, true);
    }
    void SetFlag(Vector3 pos, bool isActive)
    {
        flag.transform.SetParent(transform);
        flag.transform.position = pos;
        flag.SetActive(isActive);
    }
}
