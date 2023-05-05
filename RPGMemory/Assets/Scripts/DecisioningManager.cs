using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecisioningManager : MonoBehaviour
{
    ClickManager clickManager;
    bool onClickOption;
    [SerializeField]
    UIController_Game uiGame;
    [SerializeField]
    TextMeshProUGUI textTrial;

    void Start()
    {
        TryGetComponent(out clickManager);
        uiGame.attackBtn.onClick.AddListener(AttackMode);
        uiGame.specialModeBtn.onClick.AddListener(SpecialMode);
        
    }

    public void AttackMode()
    {
        uiGame.cardPowerText.text = "Attack Points " + clickManager.carta_1.attackPoints.ToString();
        //attack points must be obtained from the clicker manager
        if (GameManager.Instance.gameStates == GameStates.turnA)
        {
            GameManager.Instance.summonerB.life -= clickManager.carta_1.attackPoints;
            GameManager.Instance.gameStates = GameStates.turnB;
        }
        else if (GameManager.Instance.gameStates == GameStates.turnB)
        {
            GameManager.Instance.summonerA.life -= clickManager.carta_1.attackPoints;
            GameManager.Instance.gameStates = GameStates.turnA;
        }
        Debug.Log("click attack");
        uiGame.decisionPanel.gameObject.SetActive(false);
        onClickOption = true;
    }

    public void SpecialMode()
    {
        switch (clickManager.carta_1.cardSpecialModes)
        {
            case CardSpecialModes.heal:
                if(GameManager.Instance.gameStates == GameStates.turnA)
                {
                    GameManager.Instance.summonerA.life += clickManager.carta_1.deffense;
                }
                else if(GameManager.Instance.gameStates == GameStates.turnB)
                {
                    GameManager.Instance.summonerB.life += clickManager.carta_1.deffense;
                }
                Debug.Log("click special Mode");
                onClickOption = true;
                uiGame.decisionPanel.gameObject.SetActive(false);

                break;
            case CardSpecialModes.elementDefense:
                //call the specialMode code
                onClickOption = true;
                uiGame.decisionPanel.gameObject.SetActive(false);

                break;

        }
    }
    public IEnumerator ActivateDecisionMaking()
    {
        uiGame.decisionPanel.gameObject.SetActive(true);
        //textTrial.text = clickManager.carta_1.cardType.ToString();
        //Debug.Log("switched to text");

        yield return null;
    }

}

public enum CardSpecialModes
{ 
    heal, 
    elementDefense
}
