using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private GameObject levelComplete;
    [SerializeField] private GameObject levelFail;
    [SerializeField] private TextMeshProUGUI levelCompleteTimer;

    private TimerManager timerManager;
    

    private void Start()
    {
        timerManager = FindObjectOfType<TimerManager>();
    }

    public void UpdateSpeedUI(float value)
    {
        speed.text = "Speed: " + value.ToString("0.#");
    }

    public void UpdateTimeUI(float value)
    {
        timer.text = "Time: " + value.ToString("00.##");
    }

    public void CompleteLevel()
    {
        timer.enabled = false;
        speed.enabled = false;
        levelComplete.SetActive(true);
        levelCompleteTimer.text = "Time left: " + timerManager.timer.ToString("00.##");
        Destroy(timerManager);
    }

    public void FailLevel()
    {
        timer.enabled = false;
        speed.enabled = false;
        levelFail.SetActive(true);
    }
}
