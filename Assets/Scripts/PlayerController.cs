using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput, verticalInput;

    public float speed = 20.0f;
    public float defaultSpeed = 20.0f;
    public float sprintSpeed = 4.0f;

    public float rotateSpeed = 45.0f;

    public Rigidbody playerRb;


    public string horizontalInputValue;
    public string verticalInputValue;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();     
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        SetSpeed();
    }

    public void GetInput()
    {
        horizontalInput = Input.GetAxis(horizontalInputValue);
        verticalInput = Input.GetAxis(verticalInputValue);
    }

    private void FixedUpdate()
    {
        MoveCarWithPhysicsRotation();
    }

    private void MoveCarWithForceAndTorque()
    {
        if (verticalInput > 0.01f || verticalInput < -0.01f)
        {
            playerRb.AddForce(transform.forward * verticalInput * speed);
        }

        if (horizontalInput > 0.01f || horizontalInput < -0.01f)
        {
            playerRb.AddTorque(transform.up * horizontalInput * rotateSpeed);
        }
    }

    private void MoveCarWithPhysicsRotation()
    {
        //Vector3 moveDirection = new Vector2(horizontalInput, verticalInput);

        Vector3 moveDirection = transform.forward * verticalInput;
        playerRb.MovePosition(playerRb.position + moveDirection * speed * Time.fixedDeltaTime);

        if (horizontalInput > 0.01f || horizontalInput < -0.01f)
        {
            float turnSpeed = horizontalInput * rotateSpeed * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turnSpeed, 0f);
            playerRb.MoveRotation(playerRb.rotation * turnRotation);
        }

    }

    public void SetSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = defaultSpeed;
        }
    }
}
