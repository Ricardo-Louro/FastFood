using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private UIController uIController;
    [SerializeField] private float desiredTime;
    private float initialTime;
    public float timer;

    // Start is called before the first frame update
    private void Start()
    {
        uIController = FindObjectOfType<UIController>();
        initialTime = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateTime();
        uIController.UpdateTimeUI(timer);
        CheckTimeOver();
    }

    private void UpdateTime()
    {
        timer = desiredTime - (Time.time - initialTime);
    }

    private void CheckTimeOver()
    {
        if(timer <= 0)
        {
            uIController.FailLevel();
            Destroy(this);
            
        }
    }
}
