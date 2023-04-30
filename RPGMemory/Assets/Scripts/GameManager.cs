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

    public int playerAPoints;
    public int playerBPoints;

    public int availCards;
    [SerializeField]
    int totalDeck;
    public GameStates gameStates;
    public Modality modality;
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
        playerAPoints=0;
        playerBPoints=0;
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

public enum Modality
{
    SinglePlayer,
    Multiplayer
}