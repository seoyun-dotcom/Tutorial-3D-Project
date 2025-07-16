using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 5;

    public GameObject explosionFactory;
    private void Start()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 3)//30%
        {
            GameObject target = GameObject.Find("Player");
            //플레이어를 바라보는 방향
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else//70%
        {
            dir = Vector3.down;
        }
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other)
    {
        GameObject smObject = GameObject.Find("Score Manager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        //sm.SetScore(sm.GetScore() + 1); //책에 적힌 내용
        var score = sm.GetScore() + 1;
        sm.SetScore(score);

        //파티클 생성
        GameObject explosions = Instantiate(explosionFactory);
        explosions.transform.position = transform.position;
        // 파괴 기능
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
