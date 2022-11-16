using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject pauseButton, pausePanel, gameUIPanel,startButton,gameEndPanel,inputPanel;
    public bool isGameStarted;

    
    private void Start()
    {
        isGameStarted = false;
        gameEndPanel.SetActive(false);
        pausePanel.SetActive(false);
        inputPanel.SetActive(false);
        SoundManager.instance.AddButtonSound();
    }
    public void StartGame()
    {
        isGameStarted = true;
        startButton.SetActive(false);
        inputPanel.SetActive(true);
    }
    public void OpenPausePanel()
    {
        inputPanel.SetActive(false);
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }
    public void ClosePausePanel()
    {
        inputPanel.SetActive(true);
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        isGameStarted = false;
        PlayerMovement.Instance.speedZ = 0;
        gameEndPanel.SetActive(true);
        inputPanel.SetActive(false);
        pauseButton.SetActive(false);
    }
}
