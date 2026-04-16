using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChanceScript : MonoBehaviour
{
    private int chances;
    public Image img;
    public Transform chanceContainer;
    private float offset;
    public GameObject needle;

    private List<Image> lives = new List<Image>();

    void Start()
    {
        UpdateHearts(NeedleMinigameManager.instance.GetChances());
    }
    void Update()
    {
        if (needle.GetComponent<NeedleController>().hitVein)
        {
            gameObject.SetActive(false);
        }
    }
    public void UpdateHearts(int newLives)
    {
        
        chances = newLives;
        // Add hearts if needed
        while (lives.Count < chances)
        {
            Vector3 spriteOffset = new Vector3(chanceContainer.position.x + offset, chanceContainer.position.y, chanceContainer.position.z);
            Image heart = Instantiate(img, spriteOffset, chanceContainer.rotation, gameObject.transform);
            offset = offset + 100f;
            lives.Add(heart);
        }

        // Remove hearts if needed
        while (lives.Count > chances)
        {
            Image heart = lives[lives.Count - 1];
            lives.RemoveAt(lives.Count - 1);
            Destroy(heart.gameObject);
        }
    }
}
