using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course_02
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> m_animalPrefabs;

        private float m_spawnRangeX = 20f;
        private float m_spawnPosZ = 20f;

        [SerializeField] private float m_startDelay = 2f;
        [SerializeField] private float m_spawnInterval = 1.5f;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("SpawnRandomAnimal", m_startDelay, m_spawnInterval);
        }

        void SpawnRandomAnimal()
        {
            int animalIndex = Random.Range(0, m_animalPrefabs.Count);
            Vector3 spawnPos = new Vector3(Random.Range(-m_spawnRangeX, m_spawnRangeX), 0, m_spawnPosZ);
            Instantiate(m_animalPrefabs[animalIndex], spawnPos, m_animalPrefabs[animalIndex].transform.rotation);

        }


    }
}