using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int id;
    public float cardValuePoints;
    public int points;
    Pool<Card> pool;
    [SerializeField]
    GameObject creature;    
    [SerializeField]
    Transform physicalCard;
    [SerializeField]
    float rotSpeed;    
    [SerializeField]
    Quaternion targetRot;
    [SerializeField]
    Vector3 currentVelocity;
    [SerializeField]
    CardType cardType;
    WaitForSeconds WaitFor = new WaitForSeconds(3.5f);
    public bool flip;
    void Start()
    {
        var spawner = GetComponentInParent<CardSpawner>();
        pool = spawner.pool;
        creature.gameObject.SetActive(false);
        flip = false;
    }

    public void Flip()
    {
        targetRot = Quaternion.Euler(180, 0, 0f);
        physicalCard.transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed);
        flip = true;

    }
    public void FlipBack()
    {
        targetRot = Quaternion.Euler(360, 0, 0f);
        physicalCard.transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed);
        flip = false;
    }

    public void DestroyMe()
    {
        pool.Recycling(this);
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flip)
            {
                FlipBack();
            }
            else
            {
                Flip();
            }
        }*/
    }

    public IEnumerator MatchAnimTrigger()
    {
        creature.gameObject.SetActive(true);
        GameStates tmpState = GameManager.Instance.gameStates;
        GameManager.Instance.gameStates = GameStates.attack;
        //Pending to add particle effects
        yield return WaitFor;
        creature.gameObject.SetActive(false);
        //yield return WaitFor;
     //   pool.Recycling(this);
     //   gameObject.SetActive(false);
        GameManager.Instance.gameStates = tmpState;
    }


}
