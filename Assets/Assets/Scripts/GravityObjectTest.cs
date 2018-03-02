using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gravity
{
    public class GravityObjectTest : MonoBehaviour
    {
        //simple test for altering object gravity
        //simpler transform move would probably be better? this one is copy of players gravity code


        public float gravity = 20.0f;      // Gravity
        bool normalGravity = true;

        private Vector3 objectVelocity = Vector3.zero;
        private CharacterController _controller;


        // Use this for initialization
        void Start()
        {
            _controller = GetComponent<CharacterController>();
            normalGravity = true;
        }

        // Update is called once per frame
        void Update()
        {
            //not on the ground, apply gravity
            if (!_controller.isGrounded)
            {
                objectVelocity.y -= gravity * Time.deltaTime;
            }
            else
            {
                objectVelocity.y = 0;
            }

            // Move the controller
            _controller.Move(objectVelocity * Time.deltaTime);
        }

        /*
        public void ChangeGravity()
        {
            if (normalGravity)
            {
                gravity = -20f;
            }
            else
            {
                gravity = 20f;
            }
            normalGravity = !normalGravity;
        }
        */
    }   
}
