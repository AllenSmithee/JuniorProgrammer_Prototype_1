using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course_02
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] float m_horizontalInput;
        [SerializeField] float m_speed = 5f;
        [SerializeField] float m_boundX = 10.0f;

        [SerializeField] GameObject m_projectilePrefab;
        [SerializeField] GameObject m_projectileContainer;

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                var projectile = Instantiate(m_projectilePrefab, transform.position, m_projectilePrefab.transform.rotation);
                projectile.transform.parent = m_projectileContainer.transform;
            }
            if (transform.position.x < -m_boundX)
            {
                transform.position = new Vector3(-m_boundX, transform.position.y, transform.position.z);
            }
            if (transform.position.x > m_boundX)
            {
                transform.position = new Vector3(m_boundX, transform.position.y, transform.position.z);
            }
            m_horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * m_horizontalInput * Time.deltaTime * m_speed);
        }
    }
}