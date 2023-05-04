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
        playing();
    }


    void playing()
    {
        if(GameManager.Instance.modality == Modality.Multiplayer &&(GameManager.Instance.gameStates == GameStates.turnA || GameManager.Instance.gameStates == GameStates.turnB))
        {
            DetectObjectClicked();
        }
        else if(GameManager.Instance.modality == Modality.SinglePlayer)
        {
            if(Input.GetMouseButtonDown(0) && GameManager.Instance.gameStates == GameStates.turnA)
            {
                Debug.Log("Te toca");
                DetectObjectClicked();
            }
        }
    }

    void DetectObjectClicked()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.GetComponent<Card>() != null)
                {
                    if(state == States.Free)
                    {
                        carta_1 = hit.collider.gameObject.GetComponent<Card>();
                        state = States.Chosing;
                        carta_1.Flip();
                        
                    }
                    
                    else if(state == States.Chosing)
                    {
                        carta_2 = hit.collider.gameObject.GetComponent<Card>();
                        carta_2.Flip();
                        state = States.Free;
                        //check();
                        StartCoroutine(Check());
                    }
                }
            }
        }
    }
/*
    public void check()
    {
        if(carta_1.id == carta_2.id)
        {
            Debug.Log("Son iguales");
            carta_1.MatchAnimTrigger();
            carta_2.MatchAnimTrigger();
            applyPoints(carta_1.points);
            carta_1.DestroyMe();
            carta_2.DestroyMe();
        }
        else
        {
            carta_1.FlipBack();
            carta_2.FlipBack();
            applyPoints(0);
        }
    }
*/

    public IEnumerator Check()
    {
        if(carta_1.id == carta_2.id)
        {
            Debug.Log("Son iguales");
            carta_1.MatchAnimTrigger();
            //yield return(carta_1.MatchAnimTrigger());
            //yield return(carta_2.MatchAnimTrigger());
            //carta_1.StartCoroutine(carta_1.MatchAnimTrigger());
            yield return carta_2.StartCoroutine(carta_2.MatchAnimTrigger());
            StartCoroutine(decisioningManager.ActivateDecisionMaking());
            Debug.Log("Cambiare de turno");
            carta_1.DestroyMe();
            carta_2.DestroyMe();


        }
        else
        {
            Debug.Log("Son distintas");

            yield return WaitFor;
            carta_1.FlipBack();
            carta_2.FlipBack();
            Debug.Log("Cambiare de turno");

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
            GameManager.Instance.gameStates = GameStates.turnB;
        }
    }
}

public enum States
{
    Free,
    Chosing
}

