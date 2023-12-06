using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f;

    public Camera firstPersonCam;
    public Camera thirdPersonCam;
    public Camera secondPersonCam;

    public KeyCode keyCode;

    public GameDevStudents gameDevStudents;
    // Start is called before the first frame update
    void Start()
    {
        thirdPersonCam.enabled = true;
        firstPersonCam.enabled = false;
        secondPersonCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCamsUsingOneKey();
        //SwitchCamsUsing();
        MoveForward(transform, speed);
    }

    private void SwitchCamsUsingOneKey()
    {
        if (Input.GetKeyDown(keyCode))
        {
            thirdPersonCam.enabled = !thirdPersonCam.enabled;
            firstPersonCam.enabled = !firstPersonCam.enabled;

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

    private void MoveForward(Transform player, float speed = 10.0f)
    {
        player.Translate(player.forward * speed * Time.deltaTime);
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
