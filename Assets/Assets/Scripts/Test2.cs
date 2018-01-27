using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    // Point on the collider thats closest to player

    public Transform player;

    private void FixedUpdate()
    {
        var collider = GetComponent<Collider>();
        Vector3 closestPoint = collider.ClosestPoint(player.position);
        print(closestPoint);
    }
}
