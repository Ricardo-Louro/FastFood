using Unity.VisualScripting;
using UnityEngine;

public class PointController : MonoBehaviour
{
    private Point[] points;

    // Start is called befsore the first frame updates
    private void Start()
    {
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
            CompleteLevel();
        }
    }


    private void CompleteLevel()
    {
        Debug.Log("Level complete!");
    }
}
