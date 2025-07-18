using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 5;

    public GameObject explosionFactory;

    private void OnEnable()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 7)//30%
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
        /*점수 증가
        //GameObject smObject = GameObject.Find("Score Manager");
        //ScoreManager sm = smObject.GetComponent<ScoreManager>();

        ////sm.SetScore(sm.GetScore() + 1); //책에 적힌 내용
        //var score = sm.GetScore() + 1;
        //sm.SetScore(score);
        */

        //ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);
        ScoreManager.Instance.Score++;

        //파티클 생성
        GameObject explosions = Instantiate(explosionFactory);
        explosions.transform.position = transform.position;

        if (other.gameObject.name.Contains("Bullet"))
        {
            //PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            //PlayerFire.Instance.bulletObjectPool.Add(other.gameObject);
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject);

            other.gameObject.SetActive(false);//총알
        }
        else
        {

            Destroy(other.gameObject);// 플레이어 오브젝트
        }

        //EnemyManager.Instance.enemyObjectPool.Add(gameObject);
        EnemyManager.Instance.enemyObjectPool.Enqueue(gameObject);

        gameObject.SetActive(false);
    }
}
