using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyKilled : MonoBehaviour
    {
        // Respawn enemy when killed
        void OnDestroy()
        {
            //print("Script was destroyed");
            GameObject spawner = GameObject.Find("Spawn_Enemy");
            spawner.GetComponent<EnemySpawner>().SpawnEnemy();
        }
    }
}