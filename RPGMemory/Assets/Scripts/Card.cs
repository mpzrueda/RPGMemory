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
    bool isSelected;
    [SerializeField]
    Vector3 currentVelocity;
    [SerializeField]
    CardType cardType;
    WaitForSeconds WaitFor = new WaitForSeconds(3.5f);
    void Start()
    {
        var spawner = GetComponentInParent<CardSpawner>();
        pool = spawner.pool;
        creature.gameObject.SetActive(false);
    }

    public void Flip()
    {
        var smooth = Vector3.SmoothDamp(transform.position, transform.eulerAngles * 180, ref currentVelocity , 0.5f, 1);
        transform.Rotate(smooth);

        isSelected = true;
    }

    public void DestroyMe()
    {
        pool.Recycling(this);
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

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
