using UnityEngine;

public class Point : MonoBehaviour
{
    private PointController pointController;
    public bool completed = false;
    private new Renderer renderer;
    [SerializeField] private Material completedMaterial;
    

    private void Start()
    {
        pointController = FindObjectOfType<PointController>();

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
        
        pointController.CheckForCompletion();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<CarController>() != null)
        {
            SetActive();
        }
    }
}