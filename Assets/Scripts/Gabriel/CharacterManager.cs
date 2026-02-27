using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
    public Character[] characters;

    public void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        string jsonText = Resources.Load<TextAsset>("characters").text;
        CharacterList characterList = JsonUtility.FromJson<CharacterList>(jsonText);

        characters = characterList.characters;
    }

    public void Start()
    {
        foreach (Character c in characters)
        {
            Debug.Log(c.name);
            foreach(string line in c.dlines)
            {
                Debug.Log(line);
            }
        }
    }
}



[System.Serializable]
public class CharacterList
{
    public Character[] characters;
}

[System.Serializable]
public class Character
{
    public string name;
    public string[] dlines;
}
