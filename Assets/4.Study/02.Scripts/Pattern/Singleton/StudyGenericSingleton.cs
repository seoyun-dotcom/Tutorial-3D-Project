using UnityEngine;

public class StudyGenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<T>();

                if (instance == null)
                {
                    var newObject = new GameObject(typeof(T).ToString());
                    instance = newObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }
    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
        //생성된 오브젝트에서 사용하는기능
        //StudyObjectPool2.Instance.objPool.Release(GameObject);
    }

}
