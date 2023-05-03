using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{

    public float life = 100;
    public float defense = 100;

    void Update()
    {
        CheckIsImDead();
    }

    public void CheckIsImDead()
    {
        if(life<=0 && GameManager.Instance.gameStates != GameStates.gameOver)
        {
            Debug.Log("Se acabo el juego");
            GameManager.Instance.gameStates = GameStates.gameOver;
            Destroy(this.gameObject);
        }
    }
}
