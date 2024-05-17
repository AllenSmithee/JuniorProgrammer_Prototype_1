using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course_02
{
    public class DestroyOutOfBounds : MonoBehaviour
    {
        private float upLimit = 30f;
        private float bottomLimit = -10f;
        // Update is called once per frame
        void Update()
        {
            // Destroy dogs if x position less than left limit
            if (transform.position.z > upLimit)
            {
                Destroy(gameObject);
            }
            // Destroy balls if y position is less than bottomLimit
            else if (transform.position.z < bottomLimit)
            {
                Destroy(gameObject);
            }
        }


    }
}