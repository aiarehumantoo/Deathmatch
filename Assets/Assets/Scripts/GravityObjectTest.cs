using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gravity
{
    public class GravityObjectTest : MonoBehaviour
    {
        //simple test for altering object gravity
        //simpler transform move would probably be better? this one is copy of players gravity code


        float gravity = 20.0f;      // Gravity
        public bool normalGravity;

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
            // Apply gravity
            if (normalGravity)
            {
                objectVelocity.y -= gravity * Time.deltaTime;
            }
            else
            {
                objectVelocity.y = 0;
                objectVelocity.x += gravity * Time.deltaTime;
            }

            // Move the controller
            _controller.Move(objectVelocity * Time.deltaTime);
        }
    } 
}
