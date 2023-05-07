using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[Serializable]
public class Pool<Card>
{
    [SerializeField]
    GameObject[] prefabs = new GameObject[4];
    public List<SpawnSpot> parents = new List<SpawnSpot>();
    [SerializeField]
    int initSize;
    [SerializeField]
    List<Card> itemsInPool = new List<Card>();
    [SerializeField]
    List<bool> activeItems = new List<bool>();
    public void Init()
    {
        GrowPool();
    }
    void GrowPool()
    {
        for (int i = 0; i < parents.Count; i++)
        {
            if (!parents[i].occupied)
            {
                var randomCard = Random.Range(0, prefabs.Length);
                var newItem = GameObject.Instantiate(prefabs[randomCard], parents[i].transform);
                newItem.gameObject.SetActive(false);
                itemsInPool.Add(newItem.GetComponent<Card>());
                activeItems.Add(false);
            }
        }
    }

    public Card ActivatingItem()
    {
        for (int i = 0; i < itemsInPool.Count; i++)
        {
            if (!activeItems[i])
            {
                activeItems[i] = true;

                return itemsInPool[i];
            }
        }
        var lastItemitem = itemsInPool.Count;
        GrowPool();
        activeItems[lastItemitem] = true;
        return itemsInPool[lastItemitem];
    }

    public void Recycling(Card usedItem)
    {
        var idx = itemsInPool.IndexOf(usedItem);
        activeItems[idx] = false;

    }
}
