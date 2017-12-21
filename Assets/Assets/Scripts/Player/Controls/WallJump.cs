using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class WallJump : MonoBehaviour
    {
        FirstPersonController firstPersonController;                                                    // Script.
        private CharacterController m_CharacterController;

        bool notWallJumped = true;
        bool touchingWall = false;


        void Awake()
        {
            firstPersonController = GetComponent<FirstPersonController>();                              // Controller Script.
            m_CharacterController = GetComponent<CharacterController>();
        }

        void Start()
        {
            // happens after awake?
        }

        void Update()
        {
            // WallJump. On air, touching wall, hasnt walljumped yet.
            if (Input.GetButtonDown("Jump") && !m_CharacterController.isGrounded && touchingWall && notWallJumped)
            {
                firstPersonController.m_WallJump = true;
                notWallJumped = false;
            }

            // Reset walljump after landing
            if (m_CharacterController.isGrounded)
            {
                notWallJumped = true;
            }
        }

        // Wall check. Tag suitable walls as Terrain.
        void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Terrain")
            {
                //print("object;" + collider.tag);
                touchingWall = true;
            }
            
        }
        void OnTriggerExit(Collider collider)
        {
            if (collider.tag == "Terrain")
            {
                touchingWall = false;
            }

        }
    }
}
