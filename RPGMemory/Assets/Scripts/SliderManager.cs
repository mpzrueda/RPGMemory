using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField]
    Slider playerAlifeSlider;
    [SerializeField]
    Slider playerBlifeSlider;

    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log(GameManager.Instance.summonerA.life);
        playerAlifeSlider.value = GameManager.Instance.summonerA.life;
        Debug.Log(playerAlifeSlider.value);
        playerBlifeSlider.value = GameManager.Instance.summonerB.life;
    }
}
