using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    //public CardTest[] cardTypes = new CardTest[8];
    [SerializeField]
    SpawnSpot[] spots = new SpawnSpot[7];
    [SerializeField]
    Pool<CardTest> pool;
    [SerializeField]
    float cardFloatHeight;
    private void Awake()
    {
        spots = GetComponentsInChildren<SpawnSpot>();
        for (int i = 0; i < spots.Length; i++)
        {
            var parent = spots[i];
            pool.parents.Add(parent);
        }
    }
    void Start()
    {

        pool.Init();

        FillSpots();
    }

    void FillSpots()
    {
        for (int i = 0; i < spots.Length; i++)
        {
            var newItem = pool.ActivatingItem();
            newItem.transform.position = spots[i].transform.position + Vector3.up * cardFloatHeight;
            newItem.gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
