using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Glenn
//M122777

public class UIManager : MonoBehaviour
{
    [Header("Player Stats")]
    public ScoreManager scoreManager;

    [Header("UI interactions")]
    public Button clickerButton;
    public Button upgradeButton;
    public Slider upgradeSlider;

    [Header("UI labels")]
    public TMP_Text scoreText; // UI text to display score (Status Text)

    public void ToggleClickerButton()
    {
        // Toggle active state
        clickerButton.gameObject.SetActive(!clickerButton.gameObject.activeSelf);
    }

    public void OnClickerButtonClick()
    {
        scoreManager.AddScore();
        //debug
        scoreManager.DisplayScore();
        //Update status text
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + scoreManager.score;
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