using UnityEngine;
using UnityEngine.Pool;

public class StudyObjectPool2 : MonoBehaviour
{
    public ObjectPool<GameObject> objPool;
    public GameObject objPrefab;
    private void Awake()
    {
        objPool = new ObjectPool<GameObject> (CreateObject, GetObject, ReleaseObject);
    }
    GameObject CreateObject()
    {
        GameObject obj = Instantiate(objPrefab, transform);
        obj.SetActive(false);

        return obj;
    }
    void GetObject(GameObject obj)
    {
        Debug.Log("풀에서 오브젝트를 뽑는 기능");
        obj.SetActive(true);
    }
    void ReleaseObject(GameObject obj)
    {
        Debug.Log("풀에 오브젝트를 넣는 기능");
        obj.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = objPool.Get();
        }
    }
}
