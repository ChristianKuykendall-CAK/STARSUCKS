using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CupSizes : MonoBehaviour
{

    public Transform CupSpawner;
    public GameObject Small;
    public GameObject Medium;
    public GameObject Large;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSmall() // SPAWNING ITEMS
    {
        Instantiate(Small, CupSpawner.position, CupSpawner.rotation);
    }

    public void SpawnMedium()
    {
        Instantiate(Small, CupSpawner.position, CupSpawner.rotation);
    }

    public void SpawnLarge()
    {
        Instantiate(Large, CupSpawner.position, CupSpawner.rotation);
    }


}
