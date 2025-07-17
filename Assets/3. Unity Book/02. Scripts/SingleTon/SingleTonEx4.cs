using UnityEngine;

public class SingleTonEx4 : MonoBehaviour
{
    private static SingleTonEx4 instance;
    public static SingleTonEx4 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingleTonEx4();
            }
            return instance;
        }
    }

}
