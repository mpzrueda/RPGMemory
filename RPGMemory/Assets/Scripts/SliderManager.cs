using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderManager : MonoBehaviour
{
    [SerializeField]
    ClickManager clic;
    [SerializeField]
    Slider playerAlifeSlider;
    [SerializeField]
    Image sliderFillPA;    
    [SerializeField]
    Image sliderFillPB;
    [SerializeField]
    Slider playerBlifeSlider;
    [SerializeField]
    float speed;
    float lifeA;
    float lifeB;
    [SerializeField]
    TextMeshProUGUI lifeTextPA;
    [SerializeField]
    TextMeshProUGUI lifeTextPB;

    // Start is called before the first frame update
    void Start()
    {
        lifeTextPA.gameObject.SetActive(false);
        lifeTextPB.gameObject.SetActive(false);


        playerAlifeSlider.minValue = 0;
        playerAlifeSlider.maxValue = GameManager.Instance.summonerA.initialLife;
        playerAlifeSlider.value = GameManager.Instance.summonerA.life;
        playerBlifeSlider.minValue = 0;
        playerBlifeSlider.maxValue = GameManager.Instance.summonerB.initialLife;
        playerBlifeSlider.value = GameManager.Instance.summonerB.life;
        lifeA = playerAlifeSlider.maxValue;
        lifeB = playerBlifeSlider.maxValue;

    }

    // Update is called once per frame
    void Update()
    {
        var currPointsA = GameManager.Instance.summonerA.life;
        if (currPointsA < lifeA)
        {
            lifeTextPA.text = "-" + clic.lastCardRef.attackPoints.ToString();
            lifeTextPA.gameObject.SetActive(true);
            sliderFillPA.color = Color.green;
            lifeA -= lifeA * speed * Time.deltaTime;
            playerAlifeSlider.value = lifeA;
            return;
        }
        else if(currPointsA > lifeA)
        {
            lifeTextPA.text = "+" + clic.lastCardRef.deffense.ToString();
            lifeTextPA.gameObject.SetActive(true);
            sliderFillPA.color = Color.green;
            lifeA += lifeA * speed * Time.deltaTime;
            playerAlifeSlider.value = lifeA;
            return;
        }
        lifeTextPB.gameObject.SetActive(false);

        sliderFillPA.color = Color.green;        
        
        var currPointsB = GameManager.Instance.summonerB.life;
        if (currPointsB < lifeB)
        {
            lifeTextPB.text = "-" + clic.lastCardRef.attackPoints.ToString();
            lifeTextPB.gameObject.SetActive(true);
            sliderFillPB.color = Color.red;
            lifeB -= lifeB * speed * Time.deltaTime;
            playerBlifeSlider.value = lifeB;
            return;
        }
        else if (currPointsA > lifeB)
        {
            lifeTextPB.text = "-" + clic.lastCardRef.deffense.ToString();
            lifeTextPB.gameObject.SetActive(true);
            sliderFillPB.color = Color.red;
            lifeB += lifeB * speed * Time.deltaTime;
            playerBlifeSlider.value = lifeB;
            return;
        }
        lifeTextPB.gameObject.SetActive(false);

        sliderFillPB.color = Color.red;

    }
}
