using UnityEngine;
using UnityEngine.UI;
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
        if(dialoguecounter == 0){
            dialogueTextBox.text = "Cassie:\nOH MY GOSH!!! A REAL VAMPIRE";
        }
        else if(dialoguecounter == 1){
            dialogueTextBox.text = "Jackie Daytona:\nWait? Your not afraid of me?";
        }
        else if(dialoguecounter == 2){
            dialogueTextBox.text = "Cassie:\nOf course not. It was my lifelong dream to meet a real vampire.";
        }
        else if(dialoguecounter == 3){
            dialogueTextBox.text = "Jackie Daytona:\nIn that case do you want to start working for me at my cafe.";
        }
        else if(dialoguecounter == 4){
            dialogueTextBox.text = "Cassie:\nI absolutely will!";
        }
        else if (dialoguecounter == 5)
        {
            SceneManager.LoadScene("Cafe");
        }

    }
}
