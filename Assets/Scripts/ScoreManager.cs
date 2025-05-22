using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int player1Score = 0;
    private int player2Score = 0;

    public int scoreToReach;

    public Text player1ScoreText;
    public Text player2ScoreText;

    public void Player1Goal()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        CheckScore();
    }

    public void Player2Goal()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        CheckScore();
    }

    public void CheckScore()
    {
        if (player1Score == scoreToReach || player2Score == scoreToReach)
        {
            SceneManager.LoadScene(2);
        }
    }
}
