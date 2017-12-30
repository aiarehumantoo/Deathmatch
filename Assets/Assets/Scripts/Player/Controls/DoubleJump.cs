using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Increase jump speed for short duration after jumping.

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class DoubleJump : MonoBehaviour
    {
        float timer;                                    // Timer.
        float doubleJumpWindow = 0.6f;                  // How long player has time to do higher jump after jumping once. Must be less than what normal jump takes.
        float defaultJumpSpeed;                         // Default value.
        float doubleJumpSpeed = 15;
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
            }

            // DoubleJump active and player on the ground again + some time has passed so that first jump does not count.
            if (doubleJump == true && m_CharacterController.isGrounded && timer >= 0.05)
            {
                firstPersonController.m_JumpSpeed = doubleJumpSpeed;                                    // Increase jump speed.
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
