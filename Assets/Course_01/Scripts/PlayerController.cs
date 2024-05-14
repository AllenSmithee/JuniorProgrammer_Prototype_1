using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


namespace Course_01
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] PlayerType m_playerType;
        [SerializeField] float m_speed = 5f;
        [SerializeField] float m_turnSpeed;

        [SerializeField, ReadOnly] float m_horizontalInput;
        [SerializeField, ReadOnly] float m_verticalInput;



        void Update()
        {
            GetInputValue();

        }

        void FixedUpdate()
        {
            CourseMoveForward();
        }

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

        enum PlayerType
        {
            PlayerOne,
            PlayerTwo
        }
    }
}