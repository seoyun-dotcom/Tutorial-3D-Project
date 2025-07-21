using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    //수류탄이 무엇인가와 충돌했을 경우
    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(bombEffect);//파티클 생성
        eff.transform.position = transform.position;//파티클 위치 초기화

        Destroy(gameObject);
    }
}
