using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Score counter
    public int scorePerClick = 1;
    public TMP_Text scoreText; // UI text to display score

    // method to add score
    public void AddScore()
    {
        score += scorePerClick;
        UpdateScoreText();
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);
    }
    public void UpgradeClick()
    {
        scorePerClick += 1;
        Debug.Log("Score per click: " + scorePerClick);
    }
}
