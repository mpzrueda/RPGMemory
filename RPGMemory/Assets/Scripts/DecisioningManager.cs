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

    void Start()
    {
        TryGetComponent(out clickManager);
        uiGame.attackBtn.onClick.AddListener(AttackMode);
        uiGame.specialModeBtn.onClick.AddListener(SpecialMode);
        
    }

    public void AttackMode()
    {
        if (GameManager.Instance.gameStates == GameStates.turnA)
        {
            GameManager.Instance.summonerB.life -= clickManager.carta_1.attackPoints;
        }
        else if (GameManager.Instance.gameStates == GameStates.turnB)
        {
            GameManager.Instance.summonerA.life -= clickManager.carta_1.attackPoints;
        }
        uiGame.decisionPanel.gameObject.SetActive(false);
        clickManager.SwitchTurn();
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
                onClickOption = true;
                uiGame.decisionPanel.gameObject.SetActive(false);
                clickManager.SwitchTurn();

                break;
            case CardSpecialModes.elementDefense:
                //call the specialMode code
                onClickOption = true;
                uiGame.decisionPanel.gameObject.SetActive(false);
                clickManager.SwitchTurn();

                break;

        }
    }
    public IEnumerator ActivateDecisionMaking()
    {
        uiGame.decisionPanel.gameObject.SetActive(true);
        uiGame.attackText.text = "Attack Points: " + clickManager.carta_1.attackPoints.ToString();
        uiGame.cardPowerText.text = "Heal Points: " + clickManager.carta_1.deffense.ToString();
        yield return null;
    }

}

public enum CardSpecialModes
{ 
    heal, 
    elementDefense
}
