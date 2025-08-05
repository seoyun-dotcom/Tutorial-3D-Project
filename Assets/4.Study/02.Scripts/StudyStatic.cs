using UnityEngine;

public class StudyStatic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"정적변수에접근: {StaticClass.number}");
    }

    public class StaticClass
    {
        public static StaticClass instance = new StaticClass();
        public static int number = 10;

        public StaticClass()
        {
            Debug.Log($"생성자 실행 : {number}");
        }
    }
}
