using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Course_01
{
    public class PlayerController : MonoBehaviour
    {

        void Update()
        {
            CourseMoveForward();
        }
        //todo : make vehicle forward method
        void CourseMoveForward()
        {
            //using transform position change to move forward
            transform.Translate(Vector3.forward);
        }
    }
}