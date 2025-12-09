using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
//Glenn
//M122777

public class UIManager : MonoBehaviour
{
    [Header("Player Stats and game settings")]
    public ScoreManager scoreManager;
    public int costMultiplier = 10;
    public float gameTime = 0f;
    private float perSecond = 1f;
    private bool isPaused = true;

    [Header("UI interactions")]
    public Button clickerButton;
    public Button upgradeButton;
    public Button autoUpgradeButton;
    public Slider upgradeSlider;

    [Header("UI labels")]
    public TMP_Text gameTimeText;
    public TMP_Text scoreText; // UI text to display score
    public TMP_Text statusText; // UI text to display status
    public TMP_Text startButtonText; // UI text to display start / pause

    public TMP_Text effectPerUpgradeText; //UI text to display upgrade effect
    public TMP_Text costPerUpgradeText; //UI text to display upgrade cost
    public TMP_Text scorePerClickText; //UI text to display current per click value

    public TMP_Text effectPerAutoUpgradeText; //UI text to display auto upgrade effect
    public TMP_Text costPerAutoUpgradeText; //UI text to display auto upgrade cost
    public TMP_Text scorePerAutoClickText; //UI text to display current per auto click value

    public void ToggleButtons()
    {
        // Invert pause state when toggled
        isPaused = !isPaused;

        // Show/hide buttons and slider
        bool isActive = !clickerButton.gameObject.activeSelf; // invert current state
        clickerButton.gameObject.SetActive(isActive);
        upgradeButton.gameObject.SetActive(isActive);
        autoUpgradeButton.gameObject.SetActive(isActive);
        upgradeSlider.gameObject.SetActive(isActive);

        // Update Start button text
        startButtonText.text = isActive ? "Pause" : "Start"; // ternary conditional operator, shorthand for if-else statement condition ? valueiftrue : valueiffalse.
    }
    // Button click methods
    public void OnClickerButtonClick()
    {
        scoreManager.AddScore();
        //debug
        scoreManager.DisplayScore();
        //Update status text
        UpdateScore();
    }
    public void OnUpgradeButtonClick()
    {
        int upgradeAmount = Mathf.RoundToInt(upgradeSlider.value);
        int cost = upgradeAmount * costMultiplier;
        if (scoreManager.score >= cost)
        {
            scoreManager.score -= cost;
            scoreManager.AddScorePerClick(upgradeAmount);
            UpdateScorePerClick();
            UpdateScore();
        }
        else
        {
            Debug.Log("Not enough score to upgrade!");
            statusText.text = "Not enough score to upgrade!";
        }
    }
    public void OnAutoUpgradeButtonClick()
    {
        int upgradeAmount = Mathf.RoundToInt(upgradeSlider.value);
        int cost = upgradeAmount * costMultiplier;
        if (scoreManager.score >= cost)
        {
            scoreManager.score -= cost;
            scoreManager.AddScorePerAutoClick(upgradeAmount);
            UpdateScorePerAutoClick();
            UpdateScore();
        }
        else
        {
            Debug.Log("Not enough score to upgrade!");
            statusText.text = "Not enough score to upgrade!";
        }
    }
    // Update methods to display labels
    public void UpdateScore()
    {
        scoreText.text = $"Score: {scoreManager.score}";
    }
    public void UpdateScorePerClick()
    {
        scorePerClickText.text = $"Score per click: {scoreManager.scorePerClick}";
    }
    public void UpdateScorePerAutoClick()
    {
        scorePerAutoClickText.text = $"Score per second: {scoreManager.scorePerAutoClick}";
    }
    // Update method to display slider cost and effect
    public void OnSliderUpgradeChanged(float value)
    {
        int upgradeAmount = Mathf.RoundToInt(value);
        int cost = upgradeAmount * costMultiplier;

        // Update the TMP_Texts
        effectPerUpgradeText.text = $"Score +{upgradeAmount} per click";
        costPerUpgradeText.text = $"Cost: {cost}";
        // Update the TMP_Texts for autominer
        effectPerAutoUpgradeText.text = $"Score +{upgradeAmount} per second";
        costPerAutoUpgradeText.text = $"Cost: {cost}";
    }
    //public void SaveScore()
    //{
    //    string directoryPath = Application.dataPath + "/DataFiles/";
    //    string filePath = directoryPath + saveFileName + ".csv";

    //    // Ensure folder exists
    //    if (!Directory.Exists(directoryPath))
    //        Directory.CreateDirectory(directoryPath);

    //    // CSV header
    //    string csv = "Score,ScorePerClick,ScorePerAutoClick\n";
    //    // CSV data
    //    csv += $"{score},{scorePerClick},{scorePerAutoClick}\n";

    //    File.WriteAllText(filePath, csv);
    //    Debug.Log("Saved score to: " + filePath);
    //}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clickerButton.gameObject.SetActive(false);
        upgradeButton.gameObject.SetActive(false);
        autoUpgradeButton.gameObject.SetActive(false);
        upgradeSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
            return; // Stop timer + auto clicker when paused
        gameTime += Time.deltaTime;
        perSecond -= Time.deltaTime;

        gameTimeText.text = gameTime.ToString("F2"); // F2 is 2 decimal places
        //If timer is 0, add autoclicker score and reset timer
        if (perSecond <= 0f)
        {
            scoreManager.score += scoreManager.scorePerAutoClick;
            UpdateScore();
            perSecond = 1f;
        }
    }
}
/* Notes
 * Time https://youtu.be/1bV3BlRvADE?t=55
 * Naming convention - prefix method with on. https://unity.com/how-to/naming-and-code-style-tips-c-scripting-unity
 * sidebar tutorial + basic cookie clicker https://www.youtube.com/watch?v=i2XnYFCkpr8
 * unused yet
 * slider script https://youtu.be/FMy5ixxBlYw?t=389
 */