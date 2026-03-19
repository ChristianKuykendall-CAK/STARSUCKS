 using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CupSizes : MonoBehaviour
{

    public Transform CupSpawner;
    private GameObject currentCup;
    private GameObject cupLid;
    private GameObject straw;

    public GameObject Small;
    public GameObject Medium;
    public GameObject Large;
    public GameObject Lid;
    public GameObject Straw;

    public void SpawnSmall() // SPAWNING ITEMS
    {
        if (currentCup == null)
        {
            currentCup = Instantiate(Small, CupSpawner);
            currentCup.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            CoffeeBuilder.instance.SetSize(CoffeeOptions.Sizes.small);
        } 
    }

    public void SpawnMedium()
    {
        if (currentCup == null)
        {
            currentCup = Instantiate(Medium, CupSpawner);
            currentCup.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            CoffeeBuilder.instance.SetSize(CoffeeOptions.Sizes.medium);
        } 
    }

    public void SpawnLarge()
    {
        if (currentCup == null)
        {
            currentCup = Instantiate(Large, CupSpawner);
            currentCup.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            CoffeeBuilder.instance.SetSize(CoffeeOptions.Sizes.large);
        } 
    }

    public void SpawnLid()
    {
        if (cupLid == null)
        {
            cupLid = Instantiate(Lid, CupSpawner);
            cupLid.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        } 
    }

    public void SpawnStraw()
    {
        if (straw == null)
        {
            straw = Instantiate(Straw, CupSpawner);
            straw.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        } 
    }


}
