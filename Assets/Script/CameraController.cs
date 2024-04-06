using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
    private float rotX;
    private Vector3 rotation;

    private void Start()
    {
        rotX = cameraPos.eulerAngles.x;
        rotation = Vector3.zero;
        rotation.x = rotX;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = cameraPos.position;
        rotation.y = cameraPos.eulerAngles.y;
        transform.eulerAngles = rotation;   
    }
}
