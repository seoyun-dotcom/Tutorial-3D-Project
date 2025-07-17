using UnityEngine;

public class SingleTonEx1 : MonoBehaviour
{
    public static SingleTonEx1 Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
