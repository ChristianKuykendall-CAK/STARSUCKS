using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InkManager : MonoBehaviour
{
    public CafeSceneManager cafeSceneManager;

    [Header("Ink")]
    public TextAsset inkJSONAsset;

    [Header("Prefabs")]
    public Button choiceButtonPrefab;

    [Header("Scene references")]
    public Transform choiceButtonContainer;

    private Story story;

    public void BeginMainGirlDialog(int currentGirlIndex)
    {
        story = new Story(inkJSONAsset.text);

        story.variablesState["girl"] = currentGirlIndex + 1;
        story.variablesState["day"] = GameManager.instance.GetCurrentDay();

        ProgressStory();
    }

    void ProgressStory()
    {
        if (story.canContinue)
        {
            cafeSceneManager.DisplayDialog(story.Continue());
        }
    }

    public void ShowProgressionOption()
    {
        if (story != null)
        {
            if (story.currentChoices.Count > 0) {
                foreach (var choice in story.currentChoices)
                {
                    Button newButton = Instantiate(choiceButtonPrefab, choiceButtonContainer);
                    newButton.GetComponentInChildren<TMP_Text>().text = choice.text;
                    newButton.onClick.AddListener(() =>
                    {
                        DestroyButtons();
                        story.ChooseChoiceIndex(choice.index);
                        ProgressStory();
                    });
                }
            }
            else if (story.canContinue) {
                Button newButton = Instantiate(choiceButtonPrefab, choiceButtonContainer);
                newButton.GetComponentInChildren<TMP_Text>().text = "...";
                newButton.onClick.AddListener(() =>
                {
                    DestroyButtons();
                    ProgressStory();
                });
            }
            else {
                cafeSceneManager.ToggleButtonsActive();
                story = null;
                return;
            }
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