using UnityEngine;

public class AudioService : MonoBehaviour, IAudioService
{
    public void PlaySound()
    {
        Debug.Log("PlaySound");
    }
    public void StopSound()
    {
        Debug.Log("StopSound");

    }

}
