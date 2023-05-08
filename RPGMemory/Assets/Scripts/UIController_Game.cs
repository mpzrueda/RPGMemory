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
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.gameStates == GameStates.gameOver)
        {
            GameOverCanva();
        }
        else if(GameManager.Instance.gameStates == GameStates.attack)
        {
            StartCoroutine(AttackUI());
        }

    }
    public void GameOverCanva()
    {
        game0verPanel.gameObject.SetActive(true);
        winnerText.text = "Congrats. The Glory is yours!";
    }

    IEnumerator AttackUI()
    {
        attackText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        attackText.gameObject.SetActive(false);
    }
}
