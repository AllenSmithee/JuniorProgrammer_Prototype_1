using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


namespace Course_01
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float m_speed = 5f;
        [SerializeField] float m_turnSpeed;

        [SerializeField, ReadOnly] float m_horizontalInput;
        [SerializeField, ReadOnly] float m_verticalInput;

        

        void Update()
        {
            GetInputValue();
            CourseMoveForward();
        }

        void GetInputValue()
        {
            m_horizontalInput = Input.GetAxis("Horizontal");
            m_verticalInput = Input.GetAxis("Vertical");
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
    }
}