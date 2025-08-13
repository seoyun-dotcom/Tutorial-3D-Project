using UnityEngine;

public class BillboardCamera : MonoBehaviour
{
    private Transform mainCamera;
    private void Start()
    {
        mainCamera = Camera.main.transform;
    }
    void LateUpdate()
    {
        transform.LookAt(mainCamera.transform);
    }
}
