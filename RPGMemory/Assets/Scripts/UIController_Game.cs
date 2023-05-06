using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController_Game : MonoBehaviour
{
    public Button attackBtn;
    public Button specialModeBtn;

    public GameObject decisionPanel;
    [SerializeField]
    Slider playerAlifeSlider;
    [SerializeField]
    Slider playerBlifeSlider;

    //To assign in the inspector
    public TextMeshProUGUI cardPowerText;
    public TextMeshProUGUI specialModeText;
    public TextMeshProUGUI attackText;

    //fOR THE GAME OVER WINDOW
    [SerializeField]
    UIController uIController;
    [SerializeField]
    GameObject game0verPanel;
    [SerializeField]
    Button replayButton;
    [SerializeField]
    Button mainMenuButton;
    [SerializeField]
    TextMeshProUGUI winnerText;
    // Start is called before the first frame update
    void Start()
    {
        decisionPanel.gameObject.SetActive(false);
        game0verPanel.gameObject.SetActive(false);
        game0verPanel.gameObject.SetActive(false);
        replayButton.onClick.AddListener(uIController.StartGame);
        mainMenuButton.onClick.AddListener(uIController.QuitGame);
        playerAlifeSlider.minValue = 0;
        playerAlifeSlider.maxValue = GameManager.Instance.summonerA.initialLife;
        playerAlifeSlider.value = GameManager.Instance.summonerA.life;
        playerBlifeSlider.minValue = 0;
        playerBlifeSlider.maxValue = GameManager.Instance.summonerB.initialLife;
        playerBlifeSlider.value = GameManager.Instance.summonerB.life;
    }

    // Update is called once per frame
    void Update()
    {
        playerAlifeSlider.value = GameManager.Instance.summonerA.life;
        Debug.Log(playerAlifeSlider.value);
        playerBlifeSlider.value = GameManager.Instance.summonerB.life;
        Debug.Log(playerAlifeSlider.value);


        if (GameManager.Instance.gameStates == GameStates.gameOver)
        {
            GameOverCanva();
        }
        else if(GameManager.Instance.gameStates == GameStates.attack)
        {
            StartCoroutine(AttackUI());
        }

    }
    void GameOverCanva()
    {
        game0verPanel.gameObject.SetActive(true);
        winnerText.text = "Congrats " + GameManager.Instance.gameStates + "They Glory is yours.";
        Debug.Log("GameOverIsTrue");
    }

    IEnumerator AttackUI()
    {
        attackText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        attackText.gameObject.SetActive(false);
    }
}
