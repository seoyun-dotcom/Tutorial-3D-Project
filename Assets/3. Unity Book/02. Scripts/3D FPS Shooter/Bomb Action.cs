using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    public int attackPower = 10;
    public float explosionRadius = 5f;

    //수류탄이 무엇인가와 충돌했을 경우
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius, 1 << 8);

        Debug.Log("담긴 수 :" + cols.Length);

        for (int i = 0; i < cols.Length; i++)
            cols[i].GetComponent<EnemyFSM>().HitEnemy(attackPower);

        GameObject eff = Instantiate(bombEffect);//파티클 생성
        eff.transform.position = transform.position;//파티클 위치 초기화

        Destroy(gameObject);
    }
}
