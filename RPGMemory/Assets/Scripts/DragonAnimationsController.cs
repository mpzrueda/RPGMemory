using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimationsController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        TryGetComponent(out animator);
    }

    void OnCardElementInvoke(CardType cardType)
    {
        if (GameManager.Instance.gameStates == GameStates.attack)
        {
            animator.SetTrigger("Attack");

        }
    }

    // Update is called once per frame
    void Update()
    {
        OnCardElementInvoke(GameManager.Instance.cardType);
    }
}
