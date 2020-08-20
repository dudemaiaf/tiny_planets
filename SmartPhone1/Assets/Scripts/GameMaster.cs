using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject restartPanel;
    private bool asLost;
    public Text timerDisplay;
    public float timer;
    public void GoToGameScene ()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver ()
    {
        asLost = true;
        Invoke("Delay", 1.5f);
    }

    public void Delay ()
    {
        restartPanel.SetActive(true);
    }
    
    private void Update ()
    {
        if(asLost == false)
        {
            timerDisplay.text = timer.ToString("F0");
        }

        if(timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else{
            timer -= Time.deltaTime;
        }
    }

}
