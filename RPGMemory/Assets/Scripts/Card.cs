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
    Quaternion initRot;
    Quaternion targetRot;

    public CardType cardType;
    public CardSpecialModes cardSpecialModes;
    [HideInInspector]
    public CardSpawner spawner;
    SpawnSpot spawnSpot;
    public bool flip;
    public ParticleSystem particleEffect;

    private AudioSource audioSource;

    public AudioClip flipCardSound;
    public AudioClip matchCardSound;

    void Start()
    {
        spawner = GetComponentInParent<CardSpawner>();
        pool = spawner.pool;
        creature.gameObject.SetActive(false);
        particleEffect.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        initRot = transform.rotation;
    }

    public void Flip()
    {
        targetRot = Quaternion.Euler(180, 0, 0);
        physicalCard.transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed) ;
        flip = true;
        creature.gameObject.SetActive(true);
        audioSource.PlayOneShot(flipCardSound,1.0f);

    }
    public void FlipBack()
    {
        targetRot = Quaternion.Euler(360, 0, 0);
        physicalCard.transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed); 
        flip = false;
        creature.gameObject.SetActive(false);
        audioSource.PlayOneShot(flipCardSound,1.0f);
    }

    public void DestroyMe()
    {
        FlipBack();
        pool.Recycling(this);
        creature.gameObject.SetActive(false);
        particleEffect.gameObject.SetActive(false);
        spawnSpot = GetComponentInParent<SpawnSpot>();
        spawnSpot.occupied = false;
        gameObject.SetActive(false);
        spawner.desktopCards.Remove(this);
        
    }
    void Update()
    {

    }

    public IEnumerator MatchAnimTrigger()
    {
        GameStates tmpState = GameManager.Instance.gameStates;
        GameManager.Instance.gameStates = GameStates.attack;
        audioSource.PlayOneShot(matchCardSound,1.0f);
        yield return new WaitForSeconds(2f);
        GameManager.Instance.gameStates = tmpState;

    }

    public void ActivateEffect()
    {
        particleEffect.gameObject.SetActive(true);
    }
}
