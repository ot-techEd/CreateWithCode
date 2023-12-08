using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private float currentBreakForce;
    private bool isBreaking;

    public WheelCollider leftFrontWheel;
    public WheelCollider rightFrontWheel;
    public WheelCollider leftRearWheel;
    public WheelCollider rightRearWheel;

    public Transform leftFrontWheelTransform;
    public Transform rightFrontWheelTransform;
    public Transform leftRearWheelTransform;
    public Transform rightRearWheelTransform;

    public float motorForce;
    public float breakForce;

    public float currentSteerAngle;
    public float maxSteeringAngle;

    private void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        RotateWheels();
        ApplyBreak();
        HandleSteering();
        UpdateWheels();
    }

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.X);
    }

    public void RotateWheels()
    {
        leftFrontWheel.motorTorque = verticalInput * motorForce;
        rightFrontWheel.motorTorque = verticalInput * motorForce;
        if (isBreaking)
        {
            currentBreakForce = breakForce;
        }
        else
        {
            currentBreakForce = 0f;
        }
        ApplyBreak();
    }

    public void ApplyBreak()
    {
        leftFrontWheel.brakeTorque = currentBreakForce;
        rightFrontWheel.brakeTorque = currentBreakForce;
        leftRearWheel.brakeTorque = currentBreakForce;
        rightRearWheel.brakeTorque = currentBreakForce;
    }

    public void HandleSteering()
    {
        currentSteerAngle = maxSteeringAngle * horizontalInput;
        leftFrontWheel.steerAngle = currentSteerAngle;
        rightFrontWheel.steerAngle = currentSteerAngle;
    }

    public void UpdateWheels()
    {
        UpdateWheel(leftFrontWheel, leftFrontWheelTransform);
        UpdateWheel(rightFrontWheel, rightFrontWheelTransform);
        UpdateWheel(leftRearWheel, leftRearWheelTransform);
        UpdateWheel(rightRearWheel, rightRearWheelTransform);
    }

    public void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 wheelPosition;
        Quaternion wheelRotation;
        wheelCollider.GetWorldPose(out wheelPosition, out wheelRotation);
        wheelTransform.rotation = wheelRotation;
        wheelTransform.position = wheelPosition;
    }
}
