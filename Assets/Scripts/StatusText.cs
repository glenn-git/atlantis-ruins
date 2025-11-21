using TMPro;
using UnityEngine;

public class StatusText : MonoBehaviour
{
    public TMP_Text StatusTMP;
    public void DisplayStatus()
    {
        StatusTMP.text = "Hello";
    }
}
