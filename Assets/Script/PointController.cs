using UnityEngine;

public class PointController : MonoBehaviour
{
    private UIController uiController;
    private Point[] points;
    public int pointAmount;
    private int pointCompleted;

    // Start is called befsore the first frame updates
    private void Start()
    {
        uiController = FindObjectOfType<UIController>();
        points = FindObjectsByType<Point>(FindObjectsSortMode.None);
        pointAmount = points.Length;
        pointCompleted = 0;
        uiController.UpdateDeliveriesUI(0);
    }

    public void CheckForCompletion()
    {
        pointCompleted++;
        uiController.UpdateDeliveriesUI(pointCompleted);
        
        bool completed = true;

        foreach(Point point in points)
        {
            if(!point.completed)
            {
                completed = false;
                break;
            }
        }
        
        if(completed)
        {
            uiController.CompleteLevel();
        }
    }
}
