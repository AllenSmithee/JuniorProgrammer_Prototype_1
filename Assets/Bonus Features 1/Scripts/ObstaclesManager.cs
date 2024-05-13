using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BonusFeatures1
{
    public class ObstaclesManager : MonoBehaviour
    {

        [SerializeField] private GameObject m_obstaclePrefab;


        [SerializeField] private float m_parentSpacingSetting = 25.0f;
        private float m_parentSpacingUsed = 0.0f;
        [SerializeField] private float m_prefabSpacingMultiplyer = 1.5f;


        // Start is called before the first frame update
        void Start()
        {
            SpawnTriangle();
            SpawnTallRectangle();
            SpawnLowRectangle();
            SpawnOneColumn();

            SpawnTriangle();
            SpawnTallRectangle();
            SpawnLowRectangle();
            SpawnTriangle();

            SpawnWall();
        }

        void IncreaseParentSpacing()
        {
            m_parentSpacingUsed += m_parentSpacingSetting;
        }

        // make a Triangle
        void SpawnTriangle()
        {
            IncreaseParentSpacing();
            // Create a parent object to collect obstacle prefabs
            GameObject parentObject = new GameObject("Triangle");

            // Set the position of the parent object
            parentObject.transform.position = transform.position + new Vector3(-2.5f, 0, m_parentSpacingUsed);


            int[,] layout =
            {
                {0, 0, 1, 0, 0},
                {0, 1, 1, 1, 0},
                {1, 1, 1, 1, 1}
            };

            for (int i = 0; i < layout.GetLength(0); i++)
            {
                for (int j = 0; j < layout.GetLength(1); j++)
                {
                    if (layout[i, j] == 1)
                    {
                        Vector3 position = parentObject.transform.position + new Vector3(j * m_prefabSpacingMultiplyer, (layout.GetLength(0) - 1 - i) * m_prefabSpacingMultiplyer, 0);
                        GameObject obstacle = Instantiate(m_obstaclePrefab, position, Quaternion.identity);
                        obstacle.transform.SetParent(parentObject.transform);
                    }
                }
            }
        }

        void SpawnTallRectangle()
        {
            IncreaseParentSpacing();
            // Create a parent object to collect obstacle prefabs
            GameObject parentObject = new GameObject("TallRectangle");

            // Set the position of the parent object
            parentObject.transform.position = transform.position + new Vector3(-1f, 0, m_parentSpacingUsed);

            int[,] layout =
            {
                {1,1,1},
                {1,1,1},
                {1,1,1},
                {1,1,1},
                {1,1,1}
            };

            for (int i = 0; i < layout.GetLength(0); i++)
            {
                for (int j = 0; j < layout.GetLength(1); j++)
                {
                    if (layout[i, j] == 1)
                    {
                        Vector3 position = parentObject.transform.position + new Vector3(j * m_prefabSpacingMultiplyer, (layout.GetLength(0) - 1 - i) * m_prefabSpacingMultiplyer, 0);
                        GameObject obstacle = Instantiate(m_obstaclePrefab, position, Quaternion.identity);
                        obstacle.transform.SetParent(parentObject.transform);
                    }
                }
            }
        }

        void SpawnLowRectangle()
        {
            IncreaseParentSpacing();
            // Create a parent object to collect obstacle prefabs
            GameObject parentObject = new GameObject("LowRectangle");

            // Set the position of the parent object
            parentObject.transform.position = transform.position + new Vector3(-4, 0, m_parentSpacingUsed);

            int[,] layout =
            {
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
            };

            for (int i = 0; i < layout.GetLength(0); i++)
            {
                for (int j = 0; j < layout.GetLength(1); j++)
                {
                    if (layout[i, j] == 1)
                    {
                        Vector3 position = parentObject.transform.position + new Vector3(j * m_prefabSpacingMultiplyer, (layout.GetLength(0) - 1 - i) * m_prefabSpacingMultiplyer, 0);
                        GameObject obstacle = Instantiate(m_obstaclePrefab, position, Quaternion.identity);
                        obstacle.transform.SetParent(parentObject.transform);
                    }
                }
            }
        }

        void SpawnOneColumn()
        {
            IncreaseParentSpacing();
            // Create a parent object to collect obstacle prefabs
            GameObject parentObject = new GameObject("OneColumn");

            // Set the position of the parent object
            parentObject.transform.position = transform.position + new Vector3(0, 0, m_parentSpacingUsed);

            int[,] layout =
            {
                {1},
                {1},
                {1},
                {1},
                {1},
                {1},
                {1}
            };

            for (int i = 0; i < layout.GetLength(0); i++)
            {
                for (int j = 0; j < layout.GetLength(1); j++)
                {
                    if (layout[i, j] == 1)
                    {
                        Vector3 position = parentObject.transform.position + new Vector3(j * m_prefabSpacingMultiplyer, (layout.GetLength(0) - 1 - i) * m_prefabSpacingMultiplyer, 0);
                        GameObject obstacle = Instantiate(m_obstaclePrefab, position, Quaternion.identity);
                        obstacle.transform.SetParent(parentObject.transform);
                    }
                }
            }
        }

        void SpawnWall()
        {
            IncreaseParentSpacing();
            // Create a parent object to collect obstacle prefabs
            GameObject parentObject = new GameObject("Wall");

            // Set the position of the parent object
            parentObject.transform.position = transform.position + new Vector3(-7, 0, m_parentSpacingUsed);

            int[,] layout =
            {
                {1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1}
            };

            for (int i = 0; i < layout.GetLength(0); i++)
            {
                for (int j = 0; j < layout.GetLength(1); j++)
                {
                    if (layout[i, j] == 1)
                    {
                        Vector3 position = parentObject.transform.position + new Vector3(j * m_prefabSpacingMultiplyer, (layout.GetLength(0) - 1 - i) * m_prefabSpacingMultiplyer, 0);
                        GameObject obstacle = Instantiate(m_obstaclePrefab, position, Quaternion.identity);
                        obstacle.transform.SetParent(parentObject.transform);
                    }
                }
            }
        }


    }



}
