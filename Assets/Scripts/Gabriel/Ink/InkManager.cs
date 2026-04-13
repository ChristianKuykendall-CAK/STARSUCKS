using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InkManager : MonoBehaviour
{
    public TextAsset inkJSONAsset;
    private Story story;
    public TMP_Text nameBox;
    public TMP_Text dialogueBox;
    public Button choiceButtonPrefab;
    public Transform choiceButtonContainer;
    public string girl1Name = "Madaleine";
    public string girl2Name = "Priscilla";
    public string girl3Name = "Guinevere";
    public int girl = 1;
    public int day = 1;

    void Start()
    {
        // Load the compiled JSON asset into the Story object
        story = new Story(inkJSONAsset.text);
        story.variablesState["girl"] = girl;
        story.variablesState["day"] = day;

        nameBox.text = girl == 1 ? girl1Name : girl == 2 ? girl2Name : girl3Name;

        RefreshStory();
    }

    void RefreshStory()
    {
        if (!story.canContinue) return;

        dialogueBox.text = story.Continue();

        if (story.currentChoices.Count > 0)
        {
            foreach (var choice in story.currentChoices)
            {
                Button newButton = Instantiate(choiceButtonPrefab, choiceButtonContainer);
                newButton.GetComponentInChildren<TMP_Text>().text = choice.text;
                newButton.onClick.AddListener(() =>
                {
                    story.ChooseChoiceIndex(choice.index);
                    story.Continue();
                    DestroyButtons();
                    RefreshStory();
                });
            }
        }
        else if (story.canContinue) {
            Button newButton = Instantiate(choiceButtonPrefab, choiceButtonContainer);
            newButton.GetComponentInChildren<TMP_Text>().text = "continue";
            newButton.onClick.AddListener(() =>
            {
                DestroyButtons();
                RefreshStory();
            });
        }
    }

    void DestroyButtons()
    {
        for (int i = 0; i < choiceButtonContainer.childCount; i++)
        {
            Destroy(choiceButtonContainer.GetChild(i).gameObject);
        }
    }

    // Example: Setting a variable from C#
    public void SetVariable(string name, object value)
    {
        story.variablesState[name] = value;
    }
}   