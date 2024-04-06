using UnityEngine;

public class PointController : MonoBehaviour
{
    private UIController uiController;
    private Point[] points;

    // Start is called befsore the first frame updates
    private void Start()
    {
        uiController = FindObjectOfType<UIController>();
        points = FindObjectsByType<Point>(FindObjectsSortMode.None);
    }

    public void CheckForCompletion()
    {
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
