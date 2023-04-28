using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTest : MonoBehaviour
{
    Pool<CardTest> pool;
    void Start()
    {
        var spawner = GetComponentInParent<CardSpawner>();
        pool = spawner.pool;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        pool.Recycling(this);
        GameManager.Instance.availCards -= 1;
        gameObject.SetActive(false);
    }
}
