using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            //PlayerFire.Instance.bulletObjectPool.Add(other.gameObject);
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject);

            other.gameObject.SetActive(false);
        }
        else
        {
            //EnemyManager.Instance.enemyObjectPool.Add(gameObject);
            EnemyManager.Instance.enemyObjectPool.Enqueue(gameObject);
            other.gameObject.SetActive(false);//총알,적 비행기 오브젝트
        }
    }
}
