using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course_02
{
    public class MoveForward : MonoBehaviour
    {
        public float speed;
        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }


    }
}