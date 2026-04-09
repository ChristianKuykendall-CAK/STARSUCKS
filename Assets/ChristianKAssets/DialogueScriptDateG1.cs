using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueScriptDateG1 : MonoBehaviour
{
    public TMP_Text dialogueTextBox;

    int dialoguecounter = 0;

    public void Counter(){
        dialoguecounter++;
    }
    void Update(){
        if (dialoguecounter == 0)
        {
            dialogueTextBox.text = "G1:\nThank you for taking the time off work to meet me here";
        }
        else if (dialoguecounter == 1)
        {
            dialogueTextBox.text = "Cassie:\nWell... thank you for inviting me.";
        }
        else if (dialoguecounter == 2)
        {
            dialogueTextBox.text = "Narrator:\nCassie and G1 take a stroll around the park for hours, talking about their childhoods " +
                                   "to how they got to where they are now.";
        }
        else if (dialoguecounter == 3)
        {
            dialogueTextBox.text = "Cassie:\n... In fact, this park is where I met my manager who offered me the job right on the spot.";
        }
        else if (dialoguecounter == 4)
        {
            dialogueTextBox.text = "G1:\nHaha, that is so funny. I always wondered how that guy could ever get a human like you to work for him.";
        }
        else if (dialoguecounter == 5)
        {
            dialogueTextBox.text = "G1:\n*looks at watch* Oh no, looks like we lost track of time. I have to head home soon before the sun comes up.";
        }
        else if (dialoguecounter == 6)
        {
            dialogueTextBox.text = "Cassie:\nI understand. Do you think that you'll swing by for a drink at my work. I could throw in an employees discount.";
        }
        else if (dialoguecounter == 7)
        {
            dialogueTextBox.text = "G1:\nUnfortuantly, I have some plans for the next couple of days but you will defintely see me again " +
                                   "before the end of the week.";
        }
        else if (dialoguecounter == 8)
        {
            dialogueTextBox.text = "Cassie:\nI'll be waiting then. See you later.";
        }
        else if (dialoguecounter == 9)
        {
            dialogueTextBox.text = "G1:\nI'll see you later too.";
        }
        else if (dialoguecounter == 10)
        {
            dialogueTextBox.text = "Narrator:\nG1 turns into a bat and flies off into the night.";
        }
        else if (dialoguecounter == 11)
        {
            dialogueTextBox.text = "Narrator:\nCassie feeling fulfilled with the time she had with G1, walks home to prepare for another day of stealing and selling blood.";
        }

    }
    // SceneManager.LoadScene("Cafe");
}
