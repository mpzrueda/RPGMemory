using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int id;
    public float attackPoints = 50;
    public float deffense = 10;

    Pool<Card> pool;
    [SerializeField]
    GameObject creature;    
    [SerializeField]
    Transform physicalCard;
    [SerializeField]
    float rotSpeed;    
    Quaternion targetRot;
    [SerializeField]
    CardType cardType;
    public CardSpecialModes cardSpecialModes;
    CardSpawner spawner;
    public bool flip;
    [SerializeField]
    ParticleSystem particleEffect;
    void Start()
    {
        spawner = GetComponentInParent<CardSpawner>();
        pool = spawner.pool;
        creature.gameObject.SetActive(false);
        flip = false;
    }

    public void Flip()
    {
        targetRot = Quaternion.Euler(180, 0, 0f);
        physicalCard.transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed);
        flip = true;
        creature.gameObject.SetActive(true);
    }
    public void FlipBack()
    {
        targetRot = Quaternion.Euler(360, 0, 0f);
        physicalCard.transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed); 
        flip = false;
        creature.gameObject.SetActive(false);
    }

    public void DestroyMe()
    {
        pool.Recycling(this);
        gameObject.SetActive(false);
        spawner.desktopCards.Remove(this);
    }
    // Update is called once per frame
    void Update()
    {
        
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
        }
    }

    public IEnumerator MatchAnimTrigger()
    {
        GameStates tmpState = GameManager.Instance.gameStates;
        GameManager.Instance.gameStates = GameStates.attack;
        StartCoroutine(ActivateEffect());
        //Pending to add particle effects
        yield return new WaitForSeconds(2f);
        GameManager.Instance.gameStates = tmpState;
    }

    public IEnumerator ActivateEffect()
    {
        particleEffect.Play();
        yield return new WaitForSeconds(2f);
        particleEffect.Stop();
    }
}
