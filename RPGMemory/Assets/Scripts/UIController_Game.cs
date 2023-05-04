using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController_Game : MonoBehaviour
{
    [SerializeField]
    Button attackBtn;
    [SerializeField]
    Button specialModeBtn;

    public GameObject decisionPanel;
    [SerializeField]
    Slider playerAlifeSlider;
    [SerializeField]
    Slider playerBlifeSlider;


    // Start is called before the first frame update
    void Start()
    {
        decisionPanel.gameObject.SetActive(false);
        
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
        
    }
}
