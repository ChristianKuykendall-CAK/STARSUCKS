using UnityEngine;

public class CharacterManager : MonoBehaviour
{    
    [SerializeField]
    public Character[] characters;

    public void Awake()
    {
        TextAsset json = Resources.Load<TextAsset>("characters");
        CharacterList characterList = JsonUtility.FromJson<CharacterList>(json.text);

        characters = characterList.characters;
        Debug.Log(characters);
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



[SerializeField]
public class CharacterList
{
    public Character[] characters;
}



[SerializeField]
public class Character
{
    public string name;
    public string[] dlines;
}
