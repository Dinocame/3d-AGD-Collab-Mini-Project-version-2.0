using UnityEngine;
using TMPro;

public class DisplayFinalTime : MonoBehaviour
{
    public TextMeshProUGUI finalTimeText;

    void Start()
    {
        finalTimeText.text = "You Lasted: " + StopwatchUI.Timer;
    }
}