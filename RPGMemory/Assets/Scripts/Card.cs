using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    int id;
    float cardPoints;
    GameObject creature;
    bool isSelected;
    public string[] type = new string[4];
    void Start()
    {
        type[0] = "air";
        type[1] = "earth";
        type[2] = "fire";
        type[3] = "water";
    }

    void Flip()
    {
        if (isSelected)
        {
            transform.Rotate(Vector3.forward * 180);
        }
    }

    public void Match()
    {
        transform.localScale += Vector3.zero * 0.5f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Flip();
    }
}
