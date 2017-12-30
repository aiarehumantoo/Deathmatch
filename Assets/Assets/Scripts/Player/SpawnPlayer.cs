using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class SpawnPlayer : MonoBehaviour
    {
        public GameObject player;

        //Spawn player. TODO; respawn system.
        void Start()
        {
            Instantiate(player, transform.position, Quaternion.identity);
        }
    }
}