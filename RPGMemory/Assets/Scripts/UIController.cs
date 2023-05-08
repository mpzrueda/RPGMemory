using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UIController : MonoBehaviour

{
    [SerializeField]
    Button StartButton;

    [SerializeField]
    Button ControlsButton;
    [SerializeField]
    public GameObject controlsUI;

    [SerializeField]
    Button CreditsButton;
    [SerializeField]
    public GameObject creditsUI;

    [SerializeField]
    Button PauseButton;
    [SerializeField]
    Button QuitButton;

    public void StartMenu()
    {
        controlsUI.SetActive(false);
        creditsUI.SetActive(false);

    }
   
    public void StartGame()
    {
        SceneManager.LoadScene("CutScene");        
    }

    public void StartBattle()
    {
        SceneManager.LoadScene("PrototypeScene");
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        SceneManager.LoadScene("Menu");
    }


}
