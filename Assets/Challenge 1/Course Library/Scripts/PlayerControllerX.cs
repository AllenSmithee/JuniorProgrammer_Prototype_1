using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge_1
{
    public class PlayerControllerX : MonoBehaviour
    {
        [SerializeField] private float m_speed;
        [SerializeField] private float m_rotationSpeed;
        [SerializeField] private float m_verticalInput;

        public float Speed => m_speed;

        // Start is called before the first frame update
        void Start()
        {

        }

        void Update()
        {
            GetInputValue();

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            RotatePlane();
            MoveForward();
        }



        void GetInputValue()
        {
            // get the user's vertical input
            m_verticalInput = Input.GetAxis("Vertical");
        }

        void MoveForward()
        {
            // move the plane forward at a constant rate
            transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
        }

        void RotatePlane()
        {
            // turn on freezerotationX constraints and reset value of physic of rotation while input is not 0
            var rb = GetComponent<Rigidbody>();
            rb.constraints = m_verticalInput != 0 ? (rb.constraints | RigidbodyConstraints.FreezeRotationX) : (rb.constraints & ~RigidbodyConstraints.FreezeRotationX);


            // tilt the plane up/down based on up/down arrow keys
            transform.Rotate(Vector3.right * m_rotationSpeed * Time.deltaTime * m_verticalInput);

        }




    }
}