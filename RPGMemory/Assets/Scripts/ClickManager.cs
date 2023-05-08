using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour
{
    [HideInInspector]
    public Card carta_1;
    [HideInInspector]
    public Card carta_2;
    [HideInInspector]
    public Card lastCardRef;
    private States state;
    WaitForSeconds WaitFor = new WaitForSeconds(3.5f);
    DecisioningManager decisioningManager;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out decisioningManager);
        state = States.Free;
    }

    void Update()
    {
        Playing();
    }


    void Playing()
    {
        if(GameManager.Instance.modality == Modality.Multiplayer &&(GameManager.Instance.gameStates == GameStates.turnA || GameManager.Instance.gameStates == GameStates.turnB))
        {
            DetectObjectClicked();
        }
        else if(GameManager.Instance.modality == Modality.SinglePlayer)
        {
            if(Input.GetMouseButtonDown(0) && GameManager.Instance.gameStates == GameStates.turnA)
            {
                //Debug.Log("Te toca");
                DetectObjectClicked();
            }
        }
    }

    void DetectObjectClicked()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.GetComponent<Card>() != null)
                {
                    if(state == States.Free && carta_1 == null)
                    {
                        carta_1 = hit.collider.gameObject.GetComponent<Card>();
                        state = States.Chosing;
                        carta_1.Flip();
                        
                    }
                    
                    else if(state == States.Chosing && carta_1!= hit.collider.gameObject.GetComponent<Card>())
                    {
                        carta_2 = hit.collider.gameObject.GetComponent<Card>();
                        state = States.Free;
                        carta_2.Flip();
                        StartCoroutine(Check());
                    }
                }
            }
        }
    }


    public IEnumerator Check()
    {
        if(carta_1.id == carta_2.id)
        {
            //Debug.Log("Son iguales");
            //StartCoroutine(carta_1.MatchAnimTrigger());
            carta_1.ActivateEffect();
            carta_2.ActivateEffect();
            yield return StartCoroutine(carta_2.MatchAnimTrigger());
            yield return StartCoroutine(carta_1.MatchAnimTrigger());
            StartCoroutine(decisioningManager.ActivateDecisionMaking());
            lastCardRef = carta_1;
            carta_1.DestroyMe();
            carta_2.DestroyMe();
            
        }
        else
        {
            //Debug.Log("Son distintas");
            yield return WaitFor;
            carta_1.FlipBack();
            carta_2.FlipBack();
            state = States.Free;
            SwitchTurn();
        }
    }
    public void SwitchTurn()
    {
        if (GameManager.Instance.gameStates == GameStates.gameOver) return;
        if (GameManager.Instance.gameStates == GameStates.turnA)
        {
            GameManager.Instance.gameStates = GameStates.turnB;
        }
        else if (GameManager.Instance.gameStates == GameStates.turnB)
        {
            GameManager.Instance.gameStates = GameStates.turnA;
        }
        carta_1 = null;
        carta_2 = null;
    }
}

public enum States
{
    Free,
    Chosing
}

