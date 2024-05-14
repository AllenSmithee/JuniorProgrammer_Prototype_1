using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Challenge_1
{
    public class PlanePropeller : MonoBehaviour
    {
        [SerializeField] Rigidbody m_planeRb;

        PlayerControllerX m_playerControllerX;

        void Awake()
        {
            if (m_planeRb is null)
                m_planeRb = GetComponentInParent<Rigidbody>();
            
            if(m_playerControllerX is null)
                m_playerControllerX = GetComponentInParent<PlayerControllerX>();
        }
        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {
            ProperllerRotateBySpeedValue();
        }

        void ProperllerRotateByVelocity()
        {
            // Rotate the propeller of the plane
            transform.Rotate(Vector3.forward * Time.deltaTime * m_planeRb.velocity.magnitude * 100 * Time.deltaTime);
        }

        void ProperllerRotateBySpeedValue()
        {
            // Rotate the propeller of the plane
            transform.Rotate(Vector3.forward * Time.deltaTime * m_playerControllerX.Speed * 100);
        }

    }
}