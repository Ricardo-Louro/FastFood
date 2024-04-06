using UnityEngine;

public class Point : MonoBehaviour
{
    //private static List<Point> points;
    public bool completed = false;
    private new Renderer renderer;
    [SerializeField] private Material completedMaterial;
    

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        
        /*
        if(points == null)
        {
            points = new List<Point>();
            points.Add(this);
        }
        */
    }

    private void SetActive()
    {
        completed = true;
        renderer.material = completedMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<CarController>() != null)
        {
            SetActive();
        }
    }
}