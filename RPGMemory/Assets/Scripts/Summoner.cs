using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{

    public float life = 100;
    public float defense = 100;

    void Update()
    {
        if (CheckIsImDead())
        {
            LoseGame();
        }
        
    }

    public bool CheckIsImDead()
    {
        if(life<=0 && GameManager.Instance.gameStates != GameStates.gameOver)
        {
            return true;
        }
        return false;
    }

    public void LoseGame()
    {
        GameManager.Instance.gameStates = GameStates.gameOver;
        Destroy(this.gameObject);
    }
}
