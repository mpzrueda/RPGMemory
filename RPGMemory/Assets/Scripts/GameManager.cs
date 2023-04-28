using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    public int availCards;
    [SerializeField]
    int totalDeck;
    public GameStates gameStates;

    public float playerA = 0;
    public float playerB = 0;

    private void Awake()
    {
        if(instance != null)
        {
            if(instance != this)
            {
                DestroyImmediate(this);
            }
        }
        instance = this;
    }
    void Start()
    {
        GameStart();
    }

    void GameStart()
    {
        totalDeck = availCards;
        gameStates = GameStates.gameStart;
    }
    // Update is called once per frame
    void Update()
    {
        if(availCards < totalDeck / 2)
        {
            gameStates = GameStates.distribute;
        }
    }
}

public enum GameStates
{
    gameStart,
    turnA,
    turnB,
    distribute,
    attack,
    gameOver
}
