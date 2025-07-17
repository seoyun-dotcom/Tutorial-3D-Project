using UnityEngine;

public class SingleTonEx5 : MonoBehaviour
{
    private static SingleTonEx5 instance;
    public static SingleTonEx5 Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindFirstObjectByType<SingleTonEx5>();//찾아보는 기능

                if (obj != null)//찾은경우
                {
                    instance = obj;
                }
                else//못찾은경우
                {
                    var newObj = new GameObject("SingleTon");//SingleTon이라는 이름의 오브젝트 생성
                    newObj.AddComponent<SingleTonEx5>();
                    instance = newObj.GetComponent<SingleTonEx5>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)//할당을 해서 싱글톤화
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else//중복 제거
        {
            Destroy(gameObject);
        }
    }
}
