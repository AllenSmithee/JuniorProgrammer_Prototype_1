using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    [SerializeField] private float m_interval = 1.0f;
    [SerializeField] private float m_lastPressTime = -1.0f;


    // Update is called once per frame
    void Update()
    {

        // Prevent spamming
        if (Time.time - m_lastPressTime < m_interval)
        {
            return;
        }
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            m_lastPressTime = Time.time;
        }
    }
}
