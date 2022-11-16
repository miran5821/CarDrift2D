using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public Text gameScoreText, gameEndScoreText, gameEndHightScore;
    float score;

    public Text coinText;
    public int coin;

    private void Start()
    {
        coin = PlayerPrefs.GetInt("Coin");
    }

    private void Update()
    {
        
        if (GameManager.Instance.isGameStarted)
        {
            score += Time.deltaTime * 20;
            gameScoreText.text = ((int)score).ToString();
        }

        if (!GameManager.Instance.isGameStarted)
        {
            gameEndScoreText.text = ((int)score).ToString();
        }

        if (score > PlayerPrefs.GetInt("hightScore"))
        {
            PlayerPrefs.SetInt("hightScore", (int)score);
            gameEndHightScore.text = PlayerPrefs.GetInt("hightScore").ToString();
        }
        else
        {
            gameEndHightScore.text = PlayerPrefs.GetInt("hightScore").ToString();
        }

        coinText.text = coin.ToString();
        PlayerPrefs.SetInt("Coin", coin);
    }

    
}
