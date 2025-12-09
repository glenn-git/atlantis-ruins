using TMPro;
using UnityEngine;

public class StatusText : MonoBehaviour
{
    public TMP_Text StatusTMP;
    public void DisplayStatus()
    {
        StatusTMP.text = "Use Click Me button to start earning points!";
    }
}
