using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Prototype");
        }
    }

    public void LoadNextLevel()
    {
        //StartCoroutine(LoadLevel(SceneManager.LoadScene("Prototype")));

    }
 
        IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
