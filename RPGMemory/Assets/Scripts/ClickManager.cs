using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour
{

    
    private Cart carta_1;
    private Cart carta_2;

    private States state;
    // Start is called before the first frame update
    void Start()
    {
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
                if(hit.collider.gameObject.GetComponent<Cart>() != null)
                {
                    if(state == States.Free)
                    {
                        //Debug.Log("El primer objeto es: " + hit.collider.gameObject.name);
                        carta_1 = hit.collider.gameObject.GetComponent<Cart>();
                        state = States.Chosing;
                    }
                    
                    else if(state == States.Chosing)
                    {
                        //Debug.Log("El segundo objeto es: " + hit.collider.gameObject.name);
                        carta_2 = hit.collider.gameObject.GetComponent<Cart>();
                        state = States.Free;
                        check(carta_1,carta_2);
                    }
                }
            }
        }
    }

    bool check(Cart carta_1, Cart carta_2)
    {
        if(carta_1.id == carta_2.id)
        {
            Debug.Log("Son iguales");
            applyPoints(carta_1.points);
            DestroyImmediate(carta_1.gameObject);
            DestroyImmediate(carta_2.gameObject);
            return true;
        }
        return false;
    }


    void applyPoints(int points)
    {
        if(GameManager.Instance.gameStates == GameStates.turnA)
        {
            GameManager.Instance.playerAPoints+=points;
            GameManager.Instance.gameStates = GameStates.turnB;
        }
        else if(GameManager.Instance.gameStates == GameStates.turnB)
        {
            GameManager.Instance.playerBPoints+=points;
            GameManager.Instance.gameStates = GameStates.turnA;
        }

    }
}

public enum States
{
    Free,
    Chosing
}

