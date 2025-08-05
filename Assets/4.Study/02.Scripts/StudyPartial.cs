using UnityEngine;

public partial class StudyPartial : MonoBehaviour
{
    void Start()
    {
        MethodA();
        MethodB();
    }

    public void MethodA()
    {
        Debug.Log("Method A");
    }
}

public partial class StudyPartial : MonoBehaviour
{
    public void MethodB()
    {
        Debug.Log("Method B");
    }
}