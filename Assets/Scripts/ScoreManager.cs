using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Score counter
    public TMP_Text scoreText; // UI text to display score

    // method to add score
    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
