using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float rotateSpeed = 30.0f;

    public Camera firstPersonCam;
    public Camera thirdPersonCam;
    public Camera secondPersonCam;

    public KeyCode keyCode;

    public GameDevStudents gameDevStudents;

    private float horizontalInput;
    private float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        InitialiseCameras();
    }

    private void InitialiseCameras()
    {
        thirdPersonCam.enabled = true;
        firstPersonCam.enabled = false;
        secondPersonCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        SwitchCamsUsingOneKey();
        //SwitchCamsUsing();
        //MovePlayerWithTranslate(transform, speed);
        //MovePlayerWithRotate(transform,rotateSpeed, speed);
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void SwitchCamsUsingOneKey()
    {
        if (Input.GetKeyDown(keyCode))
        {
            thirdPersonCam.enabled = !thirdPersonCam.enabled;
            firstPersonCam.enabled = !firstPersonCam.enabled;

        }
    }

    private void SwitchCamsUsingTwoKeys()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            firstPersonCam.enabled = true;
            thirdPersonCam.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            thirdPersonCam.enabled = true;
            firstPersonCam.enabled = false;
        }
    }

    private void MovePlayerWithTranslate(Transform player, float speed = 10.0f)
    {
        player.Translate(player.forward * speed * verticalInput * Time.deltaTime);
        player.Translate(player.right * speed * horizontalInput * Time.deltaTime);
    }

    private void MovePlayerWithRotate(Transform player, float rotateSpeed = 15.0f, float speed = 10.0f)
    {
        player.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        if (verticalInput > 0.01f || verticalInput < -0.01f)
        {
            player.Rotate(Vector3.up, rotateSpeed * horizontalInput * Time.deltaTime);
        }


    }

    public enum GameDevStudents
    {
        Moby,
        Andrea,
        Cel,
        Thomas,
        Wayne,
        Sam,
        Oliver,
        Peridot
    }
}

//private void SwitchCamsUsing()
//{
//    if (Input.GetKeyDown(KeyCode.C))
//    {
//        if (thirdPersonCam.enabled == true)
//        {
//            thirdPersonCam.enabled = false;
//            firstPersonCam.enabled = true;
//            secondPersonCam.enabled = false;
//            Debug.Log("Third");
//        }
//        else
//        if (firstPersonCam.enabled == true)
//        {
//            thirdPersonCam.enabled = false;
//            firstPersonCam.enabled = false;
//            secondPersonCam.enabled = true;
//            Debug.Log("First");
//        }
//        else
//        if (secondPersonCam.enabled == true)
//        {
//            thirdPersonCam.enabled = true;
//            firstPersonCam.enabled = false;
//            secondPersonCam.enabled = false;
//            Debug.Log("Second");
//        }
//    }
//}