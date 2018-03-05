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

    // camera rotated 90 degrees to the side works in weird ways. Swapping axis works fine, but only within certain angle.



    // TODO;
    // character controllers ground check does not work with reversed gravity since ground is "above"
    // camera "animation"



    private CharacterController _controller;

    float gravity = 20.0f;      // Gravity
    //float rotation = 0;     // player / view rotation, testing
    bool upsideDown = false;

    private bool wishJump = false;

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

    #region MovementVariables

    float moveSpeed = 7.0f;                // Ground move speed
    float runAcceleration = 10.0f;         // Ground accel
    float runDeacceleration = 6.0f;       // Deacceleration that occurs when running on the ground
    float airAcceleration = 0.1f;          // Air accel
    float airDecceleration = 0.1f;         // Deacceleration experienced when ooposite strafing
    float airControl = 0.3f;               // How precise air control is
    float sideStrafeAcceleration = 100.0f;  // How fast acceleration occurs to get up to sideStrafeSpeed when
    float sideStrafeSpeed = 1.0f;          // What the max speed to generate when side strafing
    float jumpSpeed = 8.0f;                // The speed at which the character's up axis gains when hitting jump
    float moveScale = 1.0f;

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

        //Alter mouse controls. reverse gravity test
        if (!upsideDown)
        {
            this.transform.rotation = Quaternion.Euler(0, rotY, 0); // Rotates the collider
            playerView.rotation = Quaternion.Euler(rotX, rotY, 0); // Rotates the camera
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, rotY, 180); // Rotates the collider
            playerView.rotation = Quaternion.Euler(-rotX, -rotY, 180); // Rotates the camera
        }

        #endregion

        QueueJump();

        if (_controller.isGrounded)
        {
            GroundMove();
        }
        else if (!_controller.isGrounded)
        {
            AirMove();
        }

        // Move the controller
        _controller.Move(playerVelocity * Time.deltaTime);

        //Need to move the camera after the player has been moved because otherwise the camera will clip the player if going fast enough and will always be 1 frame behind.
        // Set the camera's position to the transform
        playerView.position = new Vector3(transform.position.x, transform.position.y + playerViewYOffset, transform.position.z);
    }

    private void QueueJump()
    {
        if (Input.GetButtonDown("Jump") && !wishJump)
        {
            wishJump = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            wishJump = false;
        }
    }

    private void GroundMove()
    {
        //Simple ground movement for testing
        playerVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));        //input
        playerVelocity = transform.TransformDirection(playerVelocity);                                  //direction
        playerVelocity *= moveSpeed;                                                                    //speed multiplier

        // Reset the gravity velocity
        playerVelocity.y = 0;

        if (wishJump)
        {
            playerVelocity.y = jumpSpeed;
            wishJump = false;
        }
    }

    private void AirMove()
    {
        //gravity
        playerVelocity.y -= gravity * Time.deltaTime;
    }

    public void ChangeGravity()
    {
        //Change camera rotation / player gravity
        gravity = -gravity;
        upsideDown = !upsideDown;
        playerViewYOffset = -playerViewYOffset;
    }
}
