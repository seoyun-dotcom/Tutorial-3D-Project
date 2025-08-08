using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonParser : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string CharID;
        public string Name;
        public int HP;
        public int Attack;

    }

    [System.Serializable]
    public class CharacterListWrapper
    {
        public List<CharacterData> characters;
    }

    public List<CharacterData> characterDatas = new List<CharacterData>();
    private void Start()
    {
        var dataFile = Resources.Load<TextAsset>("jsonData");
        var data = dataFile.text;

        //var data = File.ReadAllText(Application.dataPath + "/Resources/JsonData.json");

        ParsingCharacterJsonData(data);
    }
    private void ParsingCharacterJsonData(string data)
    {
        Debug.Log(data);
        CharacterListWrapper wrapper = JsonUtility.FromJson<CharacterListWrapper>(data);

        foreach (CharacterData cData in wrapper.characters)
        {
            characterDatas.Add(cData);
            Debug.Log($"{cData.CharID} / {cData.Name} / {cData.HP} / {cData.Attack}");
        }
    }
}
