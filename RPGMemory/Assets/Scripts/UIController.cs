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

    public void StartMenu()
    {
        controlsUI.SetActive(false);
        creditsUI.SetActive(false);

    }
   
    public void StartGame()
    {
        SceneManager.LoadScene("PrototypeScene");        
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PauseGame()
    {
        SceneManager.LoadScene("Menu");
    }


}
