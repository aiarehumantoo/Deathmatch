using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    bool moveLeft = true;
    float timer;
    float delay = 2.0f;

    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // Move left/right
        if (moveLeft)
        {
            //transform.Translate(Vector3.left * Time.deltaTime*5);
            transform.Translate(Vector3.forward * Time.deltaTime * 5);
        }
        else
        {
            //transform.Translate(Vector3.right * Time.deltaTime*5);
            transform.Translate(Vector3.back * Time.deltaTime * 5);
        }
        
        // Toggle direction every 2 seconds
        if (timer >= delay)
        {
            moveLeft = !moveLeft;
            timer = 0f;
        }
    }
}
