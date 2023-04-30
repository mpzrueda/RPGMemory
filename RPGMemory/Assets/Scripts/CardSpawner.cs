using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{

    [SerializeField]
    SpawnSpot[] spots = new SpawnSpot[12];
    public Pool<Card> pool;
    [SerializeField]
    float cardFloatHeight;
    public List<bool> spotOccupied = new List<bool>();
    public List<Card> desktopCards = new List<Card>();

    void Start()
    {
        spots = GetComponentsInChildren<SpawnSpot>();
        for (int i = 0; i < spots.Length; i++)
        {
            var parent = spots[i];
            spotOccupied.Add(false);
            pool.parents.Add(parent);
        }
        pool.Init();
        FillSpots();
    }

    void FillSpots()
    {
        for (int i = 0; i < spots.Length; i++)
        {
            if (!spotOccupied[i])
            {
                var newItem = pool.ActivatingItem();
                newItem.transform.position = spots[i].transform.position + Vector3.up * cardFloatHeight;
                newItem.gameObject.SetActive(true);
                GameManager.Instance.availCards += 1;
                desktopCards.Add(newItem);
                spotOccupied.Add(true);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameStates == GameStates.gameOver) return;
        //CODE FOR RPG VERSION, WKILL REFILL THE BOARD WHEN HALF OF THE CARDS ARE USED
        /*
        if(GameManager.Instance.gameStates == GameStates.distribute)
        {
            FillSpots();
        }*/
    }
}
