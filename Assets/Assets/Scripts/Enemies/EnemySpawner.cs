using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemy;

        void Start()
        {
            StartCoroutine(SpawnEnemy2());
        }

        public void SpawnEnemy()
        {
            StartCoroutine(SpawnEnemy2());
        }

        // Respawn enemy with delay
        IEnumerator SpawnEnemy2()
        {
            yield return new WaitForSeconds(1);
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
