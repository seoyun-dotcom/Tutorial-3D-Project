using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public enum WeatherType
{
    Sun, Rain, Snow
}

public class WeatherSystem : MonoBehaviour
{
    public WeatherType weatherType;

    public static event Action<WeatherType> weatherAction;

    [SerializeField] private GameObject[] weatherParticles;

    private IEnumerator Start()
    {
        while (true)
        {
            //날씨에 따라서 환경음 재생
            yield return new WaitForSeconds(15f);
            //환경음종료

            int weatherCount = Enum.GetValues(typeof(WeatherType)).Length;

            int ranIndex = Random.Range(0, weatherCount);

            weatherType = (WeatherType)ranIndex;

            foreach ( var particle  in weatherParticles )
                particle.SetActive(false);

            weatherParticles[ranIndex].SetActive(true);

            weatherAction?.Invoke(weatherType);
        }
    }
}
