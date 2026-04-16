using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public TMP_Text dialogueTextBox;

    int dialoguecounter = 0;

    public void Counter(){
        dialoguecounter++;
    }
    void Update(){
        if (dialoguecounter == 0)
        {
            dialogueTextBox.text = "Narrator:\nIlluminating the night sky sits the moon that rests on the horizon, " +
                                   "reflecting the sunlight that shines on a winding path.";
        }
        else if (dialoguecounter == 1)
        {
            dialogueTextBox.text = "Narrator:\nOur protagonist, Cassie, walks this path to something not of her regular of the world of normalcy " +
                                   "but to a truth which she will encounter that will change her whole reality";
        }
        else if (dialoguecounter == 2)
        {
            dialogueTextBox.text = "Cassie:\nOH MY GOSH!!! A REAL VAMPIRE";
        }
        else if (dialoguecounter == 3)
        {
            dialogueTextBox.text = "Jackie Daytona:\nWait? Your not afraid of me?";
        }
        else if (dialoguecounter == 4)
        {
            dialogueTextBox.text = "Cassie:\nOf course not. It was my lifelong dream to meet a real vampire.";
        }
        else if (dialoguecounter == 5)
        {
            dialogueTextBox.text = "Jackie Daytona:\nIn that case do you want to start working for me at my cafe.";
        }
        else if (dialoguecounter == 6)
        {
            dialogueTextBox.text = "Cassie:\nI absolutely will!";
        }
        else if (dialoguecounter == 7)
        {
            SceneManager.LoadScene("Cafe");
        }

    }
}
