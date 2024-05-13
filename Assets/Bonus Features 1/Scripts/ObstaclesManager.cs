using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BonusFeatures1.EasyObstaclesPyramids
{
    public class ObstaclesManager : MonoBehaviour
    {

        [SerializeField] private GameObject m_obstaclePrefab;


        [SerializeField] private float m_parentSpacingSetting = 20.0f;
        private float m_parentSpacingUsed = 0.0f;
        [SerializeField] private float m_prefabSpacingMultiplyer = 1.55f;


        [Space(10)]
        [Header("Easy : Obstacles pyramids")]
        [SerializeField] private bool m_easyObstaclesPyramids = false;

        [Space(10)]
        [Header("Medium : OnComing Vehicles")]
        [SerializeField] private bool m_mediumOnComingVehicles = false;



        Vector3 m_oneInitPos = new Vector3(-0.15f, 0, 0);
        Vector3 m_triangleInitPos = new Vector3(-3.25f, 0, 0);
        Vector3 m_tallRectangleInitPos = new Vector3(-1.75f, 0, 0);
        Vector3 m_lowRectangleInitPos = new Vector3(-4.0f, 0, 0);
        Vector3 m_oneColumnInitPos = new Vector3(-0.15f, 0, 0);
        Vector3 m_wallInitPos = new Vector3(-7.15f, 0, 0);




        #region ObstacleLayouts
        int[,] m_oneLayout =
        {
            {1}
        };

        int[,] m_traingleLayout =
        {
            {0, 0, 1, 0, 0},
            {0, 1, 1, 1, 0},
            {1, 1, 1, 1, 1}
        };

        int[,] m_tallRectangleLayout =
        {
            {1,1,1},
            {1,1,1},
            {1,1,1},
            {1,1,1},
            {1,1,1}
        };

        int[,] m_lowRectangleLayout =
        {
            {1,1,1,1,1,1},
            {1,1,1,1,1,1},
            {1,1,1,1,1,1},
        };

        int[,] m_oneColumnLayout =
        {
            {1},
            {1},
            {1},
            {1},
            {1},
            {1},
            {1}
        };

        int[,] m_wallLayout =
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1}
        };
        #endregion


        // Start is called before the first frame update
        void Start()
        {
            if (m_easyObstaclesPyramids)
                EasyObstaclesPyramids();

            if (m_mediumOnComingVehicles)
                MediumOnComingVehicles();

        }

        void IncreaseParentSpacing()
        {
            // Increase the parent spacing by each call
            m_parentSpacingUsed += m_parentSpacingSetting;
        }


        void EasyObstaclesPyramids()
        {
            // Easy : Obstacles Pyramids part
            SpawnObstacles("Triangle", m_triangleInitPos, m_traingleLayout);
            SpawnObstacles("TallRectangle", m_tallRectangleInitPos, m_tallRectangleLayout);
            SpawnObstacles("LowRectangle", m_lowRectangleInitPos, m_lowRectangleLayout);
            SpawnObstacles("OneColumn", m_oneColumnInitPos, m_oneColumnLayout);
            SpawnObstacles("Triangle2", m_triangleInitPos, m_traingleLayout);
            SpawnObstacles("LowRectangle2", m_lowRectangleInitPos, m_lowRectangleLayout);
            SpawnObstacles("TallRectangle2", m_tallRectangleInitPos, m_tallRectangleLayout);
            SpawnObstacles("Triangle3", m_triangleInitPos, m_traingleLayout);
            SpawnObstacles("Wall", m_wallInitPos, m_wallLayout);
        }

        void MediumOnComingVehicles()
        {
            // Medium : OnComing Vehicles part
            for (int i = 1; i <= 8; i++)
            {
                SpawnObstacles("One" + i, m_oneInitPos, m_oneLayout);
            }
        }

        void SpawnObstacles(string collectorName, Vector3 positionOffset, int[,] layout)
        {

            IncreaseParentSpacing();
            // Create a parent object to collect obstacle prefabs
            GameObject collectorObject = new GameObject(collectorName);
            collectorObject.transform.SetParent(transform);

            // Create a parent object to collect obstacle prefabs
            collectorObject.transform.position = transform.position + (positionOffset + new Vector3(0, 0, m_parentSpacingUsed));

            for (int i = 0; i < layout.GetLength(0); i++)
            {
                for (int j = 0; j < layout.GetLength(1); j++)
                {
                    if (layout[i, j] == 1)
                    {
                        Vector3 position = collectorObject.transform.position + new Vector3(j * m_prefabSpacingMultiplyer, (layout.GetLength(0) - 1 - i) * m_prefabSpacingMultiplyer, 0);
                        Instantiate(m_obstaclePrefab, position, Quaternion.identity, collectorObject.transform);
                    }
                }
            }
        }


    }



}
