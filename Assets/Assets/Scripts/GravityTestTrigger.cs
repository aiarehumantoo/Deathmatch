using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gravity
{
    public class GravityTestTrigger : MonoBehaviour
    {
        public GravityObjectTest _test;

        bool activated;         //Has this trigger been activated before?

        void Start()
        {
            
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && !activated)
            {
                // Alter test objects gravity
                //_test.ChangeGravity();
                _test.gravity = -_test.gravity;     //reverse gravity. test includes only normal and "up" states

                //get player controller script and reverse gravity
                if (other.GetComponent<RotatedControls>())
                    other.GetComponent<RotatedControls>().ChangeGravity();

                activated = true;
                StartCoroutine(Wait());     //just reverse gravity --> can be toggled. Adding short wait just in case so that same trigger cant activate it multiple times.
            }
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(5);
            activated = false;
        }
    }
}
