using UnityEngine;

public class Point : MonoBehaviour
{
    private PointController pointController;
    public bool completed = false;
    private new Renderer renderer;
    private Animator animator;

    private void Start()
    {
        pointController = FindObjectOfType<PointController>();

        renderer = GetComponent<Renderer>();

        animator = GetComponent<Animator>();
    }

    private void SetActive()
    {
        completed = true;
        animator.Play("Vanish");
        
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