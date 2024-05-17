using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Course_02
{
    public class DetectCollisions : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }


    }
}