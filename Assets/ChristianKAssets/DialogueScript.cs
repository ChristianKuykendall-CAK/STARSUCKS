using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    [Header("Scene References")]
    public TMP_Text nameTextBox;
    public TMP_Text dialogTextBox;
    public Image jackieImage;

    [Header("Dialogs")]
    public string[] dialogs =
    {
        "Narrator:Illuminating the night sky sits the moon that rests on the horizon, reflecting the sunlight that shines on a winding path.",
        "Narrator:Our protagonist, Cassie, walks this path to something not of her regular of the world of normalcy but to a truth which she will encounter that will change her whole reality",
        "Cassie:OH MY GOSH!!! A REAL VAMPIRE",
        "Jackie Daytona:Wait? Your not afraid of me?",
        "Cassie:Of course not. It was my lifelong dream to meet a real vampire.",
        "Jackie Daytona:In that case do you want to start working for me at my cafe.",
        "Cassie:I absolutely will!"
    };

    private int currDialogIndex = 0;

    void Start()
    {
        IncrementDialog();
    }

    public void IncrementDialog(){
        if (currDialogIndex >= dialogs.Length) SSSceneManager.instance.GoToNextScene();
        if (currDialogIndex == 2) jackieImage.enabled = true;
        string[] dialogParts = dialogs[currDialogIndex++].Split(":");
        nameTextBox.text = dialogParts[0];
        dialogTextBox.text = dialogParts[1];
    }
}
