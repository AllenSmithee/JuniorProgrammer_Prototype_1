using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;


namespace Course_01
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] PlayerType m_playerType;
        [SerializeField] bool m_forceMode = false;
        [SerializeField] float m_speed = 5f;
        [SerializeField] float m_turnSpeed;

        [SerializeField, ReadOnly] float m_horizontalInput;
        [SerializeField, ReadOnly] float m_verticalInput;

        private Rigidbody m_playerRb;
        [Space(10), Header("Horse Power & Torque")]
        [SerializeField] private float m_horsePower = 0.0f;
        [SerializeField] private float m_steeringValue = 0.0f;
        [SerializeField] private Transform m_centerOfMass;
        [SerializeField] private List<WheelCollider> m_wheels;
        [SerializeField] private List<WheelCollider> m_frontWheels;
        [SerializeField] private List<WheelCollider> m_rearWheels;
        float m_brakeForce = 10000;

        [SerializeField] private TextMeshProUGUI m_speedometerText;
        [SerializeField] private TextMeshProUGUI m_rpmText;
        private string m_speedString = "Speed : {0} km/h";
        private string m_rpmString = "RPM : {0}";

        void Start()
        {
            m_playerRb = GetComponent<Rigidbody>();
            m_playerRb.centerOfMass = m_centerOfMass.position;
        }

        void Update()
        {

            GetInputValue();

        }

        void FixedUpdate()
        {
            switch (m_forceMode)
            {
                case true:
                    HoursePowerApply(m_horizontalInput, m_verticalInput, m_isBrakePressed);
                    break;
                case false:
                    CourseMoveForward();
                    break;
            }
            m_speedometerText.text = string.Format(m_speedString, Mathf.RoundToInt(m_playerRb.velocity.magnitude * 3.6f));
            m_rpmText.text = string.Format(m_rpmString, Mathf.RoundToInt(Mathf.Abs(m_frontWheels[0].rpm * 10)));
        }

        bool m_isBrakePressed = false;
        void GetInputValue()
        {
            switch (m_playerType)
            {
                case PlayerType.PlayerOne:
                    m_horizontalInput = Input.GetAxis("Horizontal");
                    m_verticalInput = Input.GetAxis("Vertical");
                    break;
                case PlayerType.PlayerTwo:
                    m_horizontalInput = Input.GetAxis("Horizontal_2P");
                    m_verticalInput = Input.GetAxis("Vertical_2P");
                    break;
            }

            m_isBrakePressed = Input.GetKey(KeyCode.Space);

            if (m_isBrakePressed)
            {
                m_brakeForce += m_brakeForce * Time.deltaTime;
            }
            else
            {
                m_brakeForce = 10000;
            }

        }


        //todo : make vehicle forward method
        void CourseMoveForward()
        {
            //using transform position change to move forward
            //transform.Translate(Vector3.forward);
            transform.Translate(Vector3.forward * Time.deltaTime * m_speed * m_verticalInput);

            //transform.Translate(Vector3.right * Time.deltaTime * m_turnSpeed * m_horizontalInput);

            transform.Rotate(Vector3.up, m_turnSpeed * m_horizontalInput * Time.deltaTime);


        }

        void HoursePowerApply(float horizontalInput, float verticalInput, bool isBrake)
        {

            float brakeTorque = isBrake ? m_brakeForce : 0;

            foreach (WheelCollider wheel in m_frontWheels)
            {
                wheel.steerAngle = horizontalInput * m_steeringValue;
                wheel.brakeTorque = brakeTorque;
            }

            foreach (WheelCollider wheel in m_rearWheels)
            {
                wheel.motorTorque = verticalInput * m_horsePower;
                wheel.brakeTorque = brakeTorque;
            }

            /*
                        foreach (WheelCollider wheel in m_wheels)
                        {
                            wheel.motorTorque = verticalInput * m_horsePower;
                            wheel.steerAngle = horizontalInput * m_torque;
                        }
              */
        }


        enum PlayerType
        {
            PlayerOne,
            PlayerTwo
        }
    }
}