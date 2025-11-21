using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Show / hide button
    public GameObject clickerButton;
    public void ToggleClickerButton()
    {
        // Toggle active state
        clickerButton.SetActive(!clickerButton.activeSelf);
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
