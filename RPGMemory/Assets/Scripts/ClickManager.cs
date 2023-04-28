using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{

 //   public Cart carta_1;
  //  public Cart carta_2;
    public States state;

    void Start()
    {
        state = States.Free;
    }
/*
    public void Check(Cart carta_1, Cart carta_2)
    {
        if(carta_1.id == carta_2.id)
        {
            applyPoints(carta_1.points);
        }
    }

    void applyPoints(float points)
    {
        if(GameManager.Instance.gameStates.turnA)
        {
            GameManager.playerA+=points;
        }
        else if(GameManager.Instance.gameStates.turnB)
        {
            GameManager.playerB+=points;
        }
    }
*/
    private void OnMouseDown()
    {
        Debug.Log("Clicaso");
    }

}



public enum States
{
    Free,
    Chosing
}

