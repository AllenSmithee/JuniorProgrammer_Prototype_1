using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course_01
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] GameObject m_player;

        [SerializeField] CameraType m_cameraType = CameraType.ThirdPerson;

        internal CameraType CurrentCameraType => m_cameraType;

        Vector3 m_offsetPosition1 = new Vector3(0f, 5f, -10f);
        Vector3 m_offsetRotation1 = new Vector3(10.0f, 0.0f, 0.0f);

        Vector3 m_offsetPosition2 = new Vector3(0.0f, 2.0f, 0.0f);
        Vector3 m_offsetRotation2 = new Vector3(-5f, 0.0f, 0.0f);


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void LateUpdate()
        {
            switch (m_cameraType)
            {
                case CameraType.FirstPerson:
                    SetCameraPosition(m_offsetPosition2);
                    SetCameraRotation(m_offsetRotation2);
                    break;
                case CameraType.ThirdPerson:
                    SetCameraPosition(m_offsetPosition1);
                    SetCameraRotation(m_offsetRotation1);
                    break;
            }

        }

        void SetCameraPosition(Vector3 offset)
        {
            transform.position = m_player.transform.position + offset;

        }

        void SetCameraRotation(Vector3 rotation)
        {
            switch (m_cameraType)
            {
                case CameraType.FirstPerson:
                    transform.rotation = Quaternion.Euler(rotation + m_player.transform.rotation.eulerAngles);
                    break;
                case CameraType.ThirdPerson:
                    transform.rotation = Quaternion.Euler(rotation);
                    break;
            }
            
        }



        internal void SetCameraType(CameraType cameraType)
        {
            m_cameraType = cameraType;
        }


        internal enum CameraType
        {
            FirstPerson,
            ThirdPerson
        }
    }
}