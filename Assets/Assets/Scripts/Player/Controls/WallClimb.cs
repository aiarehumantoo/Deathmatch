using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class WallClimb : MonoBehaviour
    {
        FirstPersonController firstPersonController;                                                    // Script.
        private CharacterController m_CharacterController;

        bool touchingWall = false;


        void Awake()
        {
            firstPersonController = GetComponent<FirstPersonController>();                              // Controller Script.
            m_CharacterController = GetComponent<CharacterController>();
        }

        // Touching wall, hold space to climb.                                      TODO; height limit.
        void Update()
        {
            if (Input.GetButton("Jump") && touchingWall)
            {
                firstPersonController.m_WallClimb = true;
            }
            else
            {
                firstPersonController.m_WallClimb = false;
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
