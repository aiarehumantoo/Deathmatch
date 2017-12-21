using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Double jump speed for short duration after jumping.

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class DoubleJump : MonoBehaviour
    {
        float timer;                                    // Timer.
        float doubleJumpWindow = 0.6f;                  // How long player has time to do higher jump after jumping once. Must be less than normal jump takes.
        float defaultJumpSpeed;                         // Default value.
        bool doubleJump = false;

        FirstPersonController firstPersonController;    // Script.
        private CharacterController m_CharacterController;

        void Awake()
        {
            firstPersonController = GetComponent<FirstPersonController>();                              // Controller Script.
            defaultJumpSpeed = firstPersonController.m_JumpSpeed;                                       // Get default value.
            m_CharacterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            if (Input.GetButtonDown("Jump") && m_CharacterController.isGrounded)
            {
                timer = 0f;                                                                             // Reset the timer.
                doubleJump = true;                                                                      // Active
                //firstPersonController.m_JumpSpeed = firstPersonController.m_JumpSpeed*2;                // Double jump speed.
            }

            // DoubleJump active and player on the ground again + some time has passed so that first jump does not count.
            if (doubleJump == true && m_CharacterController.isGrounded && timer >= 0.05)
            {
                firstPersonController.m_JumpSpeed = 15;                                                                                       // Default is 10. Setting to 20 instead of *2 coz this is done each update. CHANGE THIS TO BE DONE ONCE PER JUMP.
            }

            // Disable DoubleJump after expiring.
            if (timer >= doubleJumpWindow)
            {
                firstPersonController.m_JumpSpeed = defaultJumpSpeed;                                   // Reset jump speed.
                doubleJump = false;
            }
        }
    }
}
