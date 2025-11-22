using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Score counter
    public int scorePerClick = 1; //Upgrade counter

    // method to add score
    public void AddScore()
    {
        score += scorePerClick;
    }
    public void AddScorePerClick(int amount)
    {
        scorePerClick += amount;
    }
    // display method for debugging
    public void DisplayScore()
    {
        Debug.Log($"Score: {score}, ScorePerClick: {scorePerClick}");
    }
}