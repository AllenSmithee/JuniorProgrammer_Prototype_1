using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Course_01
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float m_speed = 5f;


        void Update()
        {
            CourseMoveForward();
        }
        //todo : make vehicle forward method
        void CourseMoveForward()
        {
            //using transform position change to move forward
            //transform.Translate(Vector3.forward);
            transform.Translate(Vector3.forward * Time.deltaTime * m_speed);
        }
    }
}