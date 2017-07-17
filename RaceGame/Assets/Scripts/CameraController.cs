using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EnableMoveCameraDelegate();
public delegate void DisableMoveCameraDelegate();

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float _MoveSpeed, speedH, speedV, _ZoomSpeed;

    private float xRotation;
    private float yRotation;

    //Used to disable other componments.
    public event EnableMoveCameraDelegate EnableMoveCameraEvent;
    public event DisableMoveCameraDelegate DisableMoveCameraEvent;


    //Checks when to disable the UI and when to call which movement functions.
    private void Update ()
    {
#region UI calling
        if (EnableMoveCameraEvent != null)
        {
            //Check when the player wants to move the camera.
            if ((Input.GetMouseButtonDown(1)) || (Input.GetAxis("Mouse ScrollWheel") != 0))
            {
                EnableMoveCameraEvent.Invoke();

                //Make sure there is no cursor in the screen.
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            //Check when the player stops moving the camera.
            if ((Input.GetMouseButtonUp(1)) || (Input.GetAxis("Mouse ScrollWheel") == 0))
            {
                DisableMoveCameraEvent.Invoke();

                //Make sure the cursor reapears in the screen.
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        #endregion
#region Movement calling
        //Make sure the user can always zoom.
        Zoom();

        //While the player moves the camera.
        if (Input.GetMouseButton(1))
        {
            MoveCamera();
            RotateCamera();
        }
#endregion
    }


    //Moves the camera
    private void MoveCamera()
    {
        //Sideway movement.
        transform.position += transform.right * Input.GetAxis("Horizontal") * _MoveSpeed * Time.deltaTime;

        //Forward and backward movement.
        transform.position += transform.forward * Input.GetAxis("Vertical") * _MoveSpeed * Time.deltaTime;
    }


    //Makes the camera face into the right the direction.
    private void RotateCamera()
    {
        xRotation += speedH * Input.GetAxis("Mouse X");
        yRotation -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(yRotation, xRotation, 0.0f);
    }


    //Move the camera forward and backward (functions as zoom).
    private void Zoom()
    {
        transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * _ZoomSpeed * Time.deltaTime;
    }
}
