using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BonusFeatures1.MediumOnComingVehicles
{
    public class VehicleMovement : MonoBehaviour
    {
        [SerializeField] private float m_speed = 5f;
        [SerializeField] private GameObject m_rayOrigin;
        [SerializeField] private float m_rayDistance = 3f;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Moveforward();
        }

        void Moveforward()
        {

            RaycastHit hit;
            float speed = 0;
            if (Physics.Raycast(m_rayOrigin.transform.position, m_rayOrigin.transform.forward, out hit, m_rayDistance))
            {
                if (hit.collider.gameObject.tag == "Vehicle")
                {
                    speed = m_speed * 0.5f;
                }
            }
            else
            {
                speed = m_speed;
            }

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

    }
}