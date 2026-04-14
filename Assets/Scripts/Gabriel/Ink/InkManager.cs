using Ink.Runtime;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class InkManager : MonoBehaviour
{
    public CafeSceneManager cafeSceneManager;

    [Header("Ink")]
    public TextAsset inkJSONAsset;
    public Story story;

    [Header("Prefabs")]
    public Button choiceButtonPrefab;

    [Header("Scene references")]
    public Transform choiceButtonContainer;

    [Header("Gameplay Variables")]
    public int day = 1;

    public void DisplayDialog(int currentGirlIndex)
    {
        story = new Story(inkJSONAsset.text);

        story.variablesState["girl"] = currentGirlIndex + 1;
        story.variablesState["day"] = GameManager.instance.GetCurrentDay();

        RefreshStory();
    }

    void RefreshStory()
    {
        if (!story.canContinue) {
            cafeSceneManager.ToggleButtonsActive();
            return;
        }

        cafeSceneManager.DisplayDialog(story.Continue());

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