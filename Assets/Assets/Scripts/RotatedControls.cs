using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatedControls : MonoBehaviour
{
    // test test test
    // simple player controller but with 90 degree rotation. wall is new floor

    // world vs local???
    // gravity is positive x axis

    //camera controls for new rotation
    //add gravity, movement
    //altering gravity, camera/player turn, change controls

    // single axis camera controls work, but using both axis at the same time results in weird mouse controls?

    private CharacterController _controller;

    #region MouseControls

    //Camera
    public Transform playerView;
    public float playerViewYOffset = 0.6f; // The height at which the camera is bound to
    public float xMouseSensitivity = 30.0f;
    public float yMouseSensitivity = 30.0f;

    // Camera rotations
    private float rotX = 0.0f;
    private float rotY = 0.0f;
    private Vector3 moveDirectionNorm = Vector3.zero;
    private Vector3 playerVelocity = Vector3.zero;
    private float playerTopVelocity = 0.0f;

    #endregion

    private void Start()
    {
        // Hide the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Put the camera inside the capsule collider
        playerView.position = new Vector3(transform.position.x, transform.position.y + playerViewYOffset, transform.position.z);

        // Controller reference
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        #region MouseControls

        /* Ensure that the cursor is locked into the screen */
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            if (Input.GetButtonDown("Fire1"))
                Cursor.lockState = CursorLockMode.Locked;
        }

        /* Camera rotation stuff, mouse controls this shit */
        rotX -= Input.GetAxisRaw("Mouse Y") * xMouseSensitivity * 0.02f;
        rotY += Input.GetAxisRaw("Mouse X") * yMouseSensitivity * 0.02f;

        // Clamp the X rotation
        if (rotX < -90)
            rotX = -90;
        else if (rotX > 90)
            rotX = 90;

        //this.transform.rotation = Quaternion.Euler(0, rotY, rotation); // Rotates the collider
        //playerView.rotation = Quaternion.Euler(rotX, rotY, rotation); // Rotates the camera

        this.transform.rotation = Quaternion.Euler(rotY, 0, 90); // Rotates the collider
        playerView.rotation = Quaternion.Euler(-rotY, rotX, 90); // Rotates the camera

        #endregion

        Move();
    }

    private void Move()
    {
        // Simple player movement
    }
}
