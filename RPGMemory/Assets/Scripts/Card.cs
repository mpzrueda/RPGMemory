using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int id;
    public float cardValuePoints;
    //GameObject creature;
    bool isSelected;
    [SerializeField]
    Vector3 currentVelocity;
    [SerializeField]
    CardType cardType;
    void Start()
    {
        
    }

    void Flip()
    {
        var smooth = Vector3.SmoothDamp(transform.position, transform.eulerAngles * 180, ref currentVelocity , 0.5f, 1);
        transform.Rotate(smooth);

        isSelected = true;
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

    /*
     private void OnMouseDown()
    {
        pool.Recycling(this);
        GameManager.Instance.availCards -= 1;
        gameObject.SetActive(false);
    }*/

}
