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

    public Camera CameraPlayerA;
    public Camera CameraPlayerB;

    public GameObject boardBase;
    
    public int playerAPoints;
    public int playerBPoints;
    
    public Summoner summonerA;
    public Summoner summonerB;

    public UIController_Game mainUI;

    public GameObject board;
    float smooth = 5.0f;

    public int availCards;
    [SerializeField]
    int totalDeck;
    public GameStates gameStates;

    public Modality modality;

    public CardType cardType;
    public bool readyToRedistribute;
    CardSpawner spawner;
    public bool refilDeck;
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
        spawner = boardBase.GetComponentInChildren<CardSpawner>();
    }

    void GameStart()
    {
        CameraPlayerA.enabled = true;
        CameraPlayerB.enabled = false;
        playerAPoints=0;
        playerBPoints=0;
        readyToRedistribute = true;
        gameStates = GameStates.turnA;
    }
    // Update is called once per frame
    void Update()
    {
        availCards = spawner.desktopCards.Count;
        if(availCards <= 6)
        {
            Debug.Log("A rellenar");
            readyToRedistribute = true;
        }
        if(gameStates == GameStates.turnA)
        {
            CameraPlayerA.enabled = true;
            CameraPlayerB.enabled = false;
            Quaternion target = Quaternion.Euler(0, 0, 0);
            boardBase.transform.rotation = Quaternion.Slerp(boardBase.transform.rotation, target,  Time.deltaTime * smooth);
        }
        if(gameStates == GameStates.turnB)
        {
            CameraPlayerA.enabled = false;
            CameraPlayerB.enabled = true;
            Quaternion target = Quaternion.Euler(0, 180, 0);
            boardBase.transform.rotation = Quaternion.Slerp(boardBase.transform.rotation, target,  Time.deltaTime * smooth);
        }
        if(gameStates == GameStates.gameOver)
        {
            mainUI.GameOverCanva();
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

public enum CardType
{
    air,
    earth,
    fire,
    water
}
