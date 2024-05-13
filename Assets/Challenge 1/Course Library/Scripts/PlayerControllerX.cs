using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private float m_verticalInput;

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
        MoveForward();

        RotatePlane();

    }


    void GetInputValue()
    {
        // get the user's vertical input
        m_verticalInput = Input.GetAxis("Vertical");
    }

    void MoveForward()
    {
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * m_speed);
    }

    void RotatePlane()
    {
        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * m_rotationSpeed * Time.deltaTime * m_verticalInput);
    }




}
