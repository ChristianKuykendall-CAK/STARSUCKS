using UnityEngine;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour
{
    [Header("Random Characters")]
    public List<string> randomNames;
    public List<string> randomIntroDialogs;

    [Header("Pre-made Characters")]
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

    public Character GenerateRandomCharacter()
    {
        Character newChar = new Character();

        newChar.name = randomNames[Random.Range(0, randomNames.Count)];
        newChar.dlines[0] = randomIntroDialogs[Random.Range(0, randomIntroDialogs.Count)];

        return newChar;
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
