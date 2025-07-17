using UnityEngine;

public class SingleTonEx3 : MonoBehaviour
{
    private static SingleTonEx3 instance = new SingleTonEx3();
    public static SingleTonEx3 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingleTonEx3();
            }
            return instance;
        }
    }
}
