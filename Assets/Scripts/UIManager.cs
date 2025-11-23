using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Glenn
//M122777

public class UIManager : MonoBehaviour
{
    [Header("Player Stats and game settings")]
    public ScoreManager scoreManager;
    public int costMultiplier = 10;

    [Header("UI interactions")]
    public Button clickerButton;
    public Button upgradeButton;
    public Slider upgradeSlider;

    [Header("UI labels")]
    public TMP_Text scoreText; // UI text to display score (Status Text)
    public TMP_Text effectPerUpgradeText; //UI text to display upgrade effect
    public TMP_Text costPerUpgradeText; //UI text to display upgrade cost
    public TMP_Text scorePerClickText; //UI text to display current per click value

    public TMP_Text effectPerAutoUpgradeText; //UI text to display auto upgrade effect
    public TMP_Text costPerAutoUpgradeText; //UI text to display auto upgrade cost
    public TMP_Text scorePerAutoClickText; //UI text to display current per auto click value

    public void ToggleClickerButton()
    {
        // Toggle active state
        clickerButton.gameObject.SetActive(!clickerButton.gameObject.activeSelf);
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
        } 
        else
        {
            Debug.Log("Not enough score to upgrade!");
            scoreText.text = "Not enough score to upgrade!";
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
        }
        else
        {
            Debug.Log("Not enough score to upgrade!");
            scoreText.text = "Not enough score to upgrade!";
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/* Notes
 * Naming convention - prefix method with on. https://unity.com/how-to/naming-and-code-style-tips-c-scripting-unity
 */