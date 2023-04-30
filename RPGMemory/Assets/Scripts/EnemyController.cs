using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    List<Cart> activeCards;

    private Cart cart_1;
    private Cart cart_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    Cart pick()
    {
        int randomNumber = Random.Range(0, activeCards.Count);
        return activeCards[randomNumber];
    }


}
