using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecisioningManager : MonoBehaviour
{
    ClickManager clickManager;
    bool onClickOption;

    //For the UI
    [SerializeField]
    Button attackBtn;
    [SerializeField]
    Button specialModeBtn;
    public GameObject decisionPanel;
    [SerializeField]
    Slider playerAlifeSlider;
    [SerializeField]
    Slider playerBlifeSlider;

    void Start()
    {
        TryGetComponent(out clickManager);
        attackBtn.onClick.AddListener(AttackMode);
        specialModeBtn.onClick.AddListener(SpecialMode);
        //For the UI
        decisionPanel.gameObject.SetActive(false);
        onClickOption = false;
        playerAlifeSlider.minValue = 0;
        playerAlifeSlider.maxValue = GameManager.Instance.summonerA.initialLife;
        playerAlifeSlider.value = GameManager.Instance.summonerA.life;
        playerBlifeSlider.minValue = 0;
        playerBlifeSlider.maxValue = GameManager.Instance.summonerB.initialLife;
        playerBlifeSlider.value = GameManager.Instance.summonerB.life;

    }

    public void AttackMode()
    {
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
        decisionPanel.gameObject.SetActive(false);
        onClickOption = true;
    }

    public void SpecialMode()
    {
        switch (clickManager.carta_1.cardSpecialModes)
        {
            case CardSpecialModes.heal:
                if(GameManager.Instance.gameStates == GameStates.turnA)
                {
                    GameManager.Instance.summonerB.life += clickManager.carta_1.deffense;
                }
                else if(GameManager.Instance.gameStates == GameStates.turnB)
                {
                    GameManager.Instance.summonerA.life += clickManager.carta_1.deffense;
                }
                Debug.Log("click special Mode");
                onClickOption = true;
                decisionPanel.gameObject.SetActive(false);

                break;
            case CardSpecialModes.elementDefense:
                //call the specialMode code
                onClickOption = true;
                decisionPanel.gameObject.SetActive(false);

                break;

        }
    }
    public IEnumerator ActivateDecisionMaking()
    {
        decisionPanel.gameObject.SetActive(true);
        yield return null;
    }

}

public enum CardSpecialModes
{ 
    heal, 
    elementDefense
}
