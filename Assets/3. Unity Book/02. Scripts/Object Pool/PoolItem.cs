using UnityEngine;

public class PoolItem : MonoBehaviour
{
    private PoolManager poolManager;

    private void Awake()
    {
        poolManager = GameObject.FindFirstObjectByType<PoolManager>();
    }

    private void OnEnable()
    {
        Invoke("ReturnObject", 2f);

    }

    void ReturnObject()
    {
        poolManager.pool.Release(gameObject);
    }
}
