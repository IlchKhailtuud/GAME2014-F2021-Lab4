using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour
{
    private int nextSceneIndex;
    private int previousSceneIndex;

    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }
    
    public void OnNextBtnPressed()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void OnBackBtnPress()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }
}
