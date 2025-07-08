using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody bombRb;
    public float bombTime = 4f;
    public float bombRange = 10f;
    public LayerMask layerMask;

    private void Awake()
    {
        bombRb = GetComponent<Rigidbody>();
    }
    //원하는 타이밍에 폭파 효과
    IEnumerator Start()
    {
        yield return new WaitForSeconds(bombTime);

        BombForce();
    }

    void BombForce()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRange, layerMask);

        foreach(var collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            //AddExplosionForce(폭발 파워, 폭발 위치, 폭발 범위, 폭발 높이)
            rb.AddExplosionForce(100f, transform.position, bombRange, 1f);
        }

        Destroy(gameObject);
    }
}
