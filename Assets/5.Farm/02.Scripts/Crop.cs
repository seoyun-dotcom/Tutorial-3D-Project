using System;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] private string cropName;
    //[SerializeField] private GameObject obj;
    public Sprite icon;

    public Action useAction;
    private void Start()
    {
        useAction += Use;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Get();
        }
    }
    public void Get()//인벤토리에 작물 추가
    {
        if (GameManager.Instance.item.CheckItemCount())
        {
            GameManager.Instance.item.GetItem(this);
            Debug.Log($"{cropName}을 획득하였습니다.");
            gameObject.SetActive(false);
        }
        else
            Debug.Log($"인벤토리가 가득 찼습니다.");
    }
    public void Use()//체력,스테미나를 회복,인벤토리에서 버튼을 눌렀을 때 실행
    {
        Debug.Log($"{cropName}을 사용하였습니다.");
    }
}
