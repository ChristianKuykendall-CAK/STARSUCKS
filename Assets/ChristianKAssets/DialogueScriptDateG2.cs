using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueScriptDateG2 : MonoBehaviour
{
    public TMP_Text dialogueTextBox;

    int dialoguecounter = 0;

    public void Counter(){
        dialoguecounter++;
    }
    void Update(){
        if (dialoguecounter == 0)
        {
            dialogueTextBox.text = "Narrator:\nCassie arrives at the end of block in an uber. She gets out of the car and starts " +
                                   "heading towards the movie theater.";
        }
        else if (dialoguecounter == 1)
        {
            dialogueTextBox.text = "Narrator:\nAs Cassie gets closer they notice their date coming from the other side and they lock eyes. " +
                                   "Never looking away from each other they meet right in front of the theater.";
        }
        else if (dialoguecounter == 2)
        {
            dialogueTextBox.text = "Cassie:\nI didn't take you for someone who enjoys movies.";

        }
        else if (dialoguecounter == 3)
        {
            dialogueTextBox.text = "G2:\nAre you kidding? I liked going to the movies ever since they first came out.";
        }
        else if (dialoguecounter == 4)
        {
            dialogueTextBox.text = "G2:\nThey certainly keep getting better when you get to see the progress of filmaking over 100 years.";
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
