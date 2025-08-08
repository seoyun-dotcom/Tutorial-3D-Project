using UnityEngine;


public class QuestSystem : MonoBehaviour
{
    public void StartQuest(string questName)
    {
        Debug.Log($"{questName} 획득");
    }
    public void HasQuest(string questName)
    {
        Debug.Log($"{questName} 유무");

    }
    public void ComleteQuest(string questName)
    {
        Debug.Log($"{questName} 포기");

    }

}
