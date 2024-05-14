using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BonusFeatures1.MediumOnComingVehicles
{
    public class OnComingVehiclesManager : MonoBehaviour
    {

        [Header("Vehicles Prefabs")]
        [SerializeField] private GameObject m_vehiclePrefabOne;
        [SerializeField] private GameObject m_vehiclePrefabTwo;
        [SerializeField] private GameObject m_vehiclePrefabThree;
        [SerializeField] private GameObject m_vehiclePrefabFour;

        [Header("Vehicle Spawning Spacing")]

        [SerializeField] private float m_vehicleSpacing = 30.0f;
        [SerializeField] private float m_vehcileSpacingInUse = 0.0f;

        [Space(10)]
        [Header("Medium : OnComing Vehicles")]
        [SerializeField] private bool m_mediumOnComingVehicles = false;


        // Start is called before the first frame update
        void Start()
        {
            if (!m_mediumOnComingVehicles)
                return;

            SpawnVehicles();
        }

        [SerializeField] float m_leftSpawnX = -7.0f;
        [SerializeField] float m_rightSpawnX = 7.0f;
        [SerializeField] private Vector3 m_initDirection = new Vector3(0.0f, -180.0f, 0.0f);
        void SpawnVehicles()
        {
            GameObject collecorObject = new GameObject("Vehicles");
            collecorObject.transform.SetParent(transform);

            for (int i = 1; i <= 8; i++)
            {
                if (Mathf.Repeat(i, 2) == 0)
                {
                    //even left
                    Instantiate(RandomVehcile(), new Vector3(m_leftSpawnX, 0, i * m_vehicleSpacing), Quaternion.Euler(m_initDirection), collecorObject.transform);

                }
                else
                {
                    //odd right
                    Instantiate(RandomVehcile(), new Vector3(m_rightSpawnX, 0, i * m_vehicleSpacing), Quaternion.Euler(m_initDirection), collecorObject.transform);
                }
            }

            //last one tank!
            Instantiate(m_vehiclePrefabFour, new Vector3(0, 0, 180.0f), Quaternion.Euler(m_initDirection));
        }

        //random vehicle
        GameObject RandomVehcile()
        {
            int randomVehicle = Random.Range(1, 4);

            switch (randomVehicle)
            {
                case 1:
                    return m_vehiclePrefabOne;
                case 2:
                    return m_vehiclePrefabTwo;
                case 3:
                    return m_vehiclePrefabThree;
                default:
                    return m_vehiclePrefabOne;
            }
        }

    }
}