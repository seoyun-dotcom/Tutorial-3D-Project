using UnityEngine;

public class SingleTonEx2 : MonoBehaviour
{
    public static SingleTonEx2 Instance
    {
        get; //접근가능
        private set;//수정불가
    }

    private void Awake()
    {
        if (Instance == null)//인스턴스가 비어있으면 자신(this)을 할당
            Instance = this;
        else//이미 SingleTonEx2가 존재하면 this스크립트 삭제 -> 중복생성방지
            Destroy(gameObject);
    }
    
}
