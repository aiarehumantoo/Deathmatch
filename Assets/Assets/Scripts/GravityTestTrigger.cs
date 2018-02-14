using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gravity
{
    public class GravityTestTrigger : MonoBehaviour
    {
        public GravityObjectTest _test;

        void Start()
        {
            
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                // Alter test objects gravity
                _test.normalGravity = false;
            }
        }
    }
}
