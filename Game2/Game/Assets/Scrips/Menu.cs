using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool IsPlayerDead = false;
    private bool soundPlayed = false;
    private HealthSystem health;

    public GameObject pauseMenuUI;
    public GameObject GameOverUI;
    public GameObject levelCompletedUI;

    [SerializeField] private AudioSource levelCompleteSound;
    // Update is called once per frame
    void Update()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();

        if(Input.GetKeyDown(KeyCode.Escape) && !IsPlayerDead){
            if(GameIsPaused){
                Continue();
            }else{
                Pause();
            }
        }
        if(health.currentHealth<=0){
            IsPlayerDead = true;
        }
        if(IsPlayerDead){
            GameOver();
        }
        if (CollectCoinsToContinue.allCoinsCollected && !soundPlayed)
        {
            LevelCompleted();
        }
    }

    public void Continue(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void GameOver(){
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LevelCompleted()
    {
        levelCompleteSound.Play();
        levelCompletedUI.SetActive(true);
        Time.timeScale = 0f;
        soundPlayed = true;
    }

    public void Respawn(string sceneName){
        health.currentHealth=10;
        IsPlayerDead = false;
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
        SC_2DCoin.totalCoins=0;
        Movement.gravityOn = false;
        //GameOverUI.SetActive(false);
        CollectCoinsToContinue.allCoinsCollected = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void GoToScene(string sceneName){
        //pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        health.currentHealth=10;
        SC_2DCoin.totalCoins=0;
        CollectCoinsToContinue.allCoinsCollected = false;
        IsPlayerDead = false;
        SceneManager.LoadScene(sceneName);
    }
}
