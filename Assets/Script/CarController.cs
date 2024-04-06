using System.Runtime.CompilerServices;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private UIController uiController;
    private Rigidbody rb;

    [SerializeField] private AudioSource breakingAudio; 
    [SerializeField] private AudioSource acceleratingAudio; 

    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider backRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider backLeft;


    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform backRightTransform;
    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform backLeftTransform;
    
    [SerializeField] private float baseAccel;
    [SerializeField] private float catchupVelocity;
    [SerializeField] private float catchupAccel;
    [SerializeField] private float breakingForce;
    [SerializeField] private float maxTurnAngle;
    
    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;


    private void Start()
    {
        uiController = FindObjectOfType<UIController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Debug.Log("Current Accel: " + currentAcceleration);

        uiController.UpdateSpeedUI(rb.velocity.magnitude);

        breakingAudio.pitch = Random.Range(.8f, 1);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            breakingAudio.Play();
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            breakingAudio.Stop();
        }

        if(Input.GetAxis("Vertical") <= .7f)
        {
            acceleratingAudio.Stop();
        }
        else
        {
            if(!acceleratingAudio.isPlaying)
            {
                acceleratingAudio.pitch = Random.Range(0.5f, 1);
                acceleratingAudio.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        if(rb.velocity.magnitude <= catchupVelocity)
        {
            currentAcceleration = catchupAccel * 1000 * Input.GetAxis("Vertical");
        }
        else
        {
            currentAcceleration = baseAccel * 1000 * Input.GetAxis("Vertical");
        }

        if(Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breakingForce * 1000;
            
        }
        else
        {
            currentBreakForce = 0f;
        }

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;


        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        //UpdateWheel(frontLeft, frontLeftTransform);
        //UpdateWheel(frontRight, frontRightTransform);
        //UpdateWheel(backLeft, backLeftTransform);
        //UpdateWheel(backRight, backRightTransform);
    }

    /*
    private void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        
        trans.position = position;
        trans.rotation = rotation;
    }
    */
}