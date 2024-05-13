using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject m_player;
    
    Vector3 m_offset;


    // Start is called before the first frame update
    void Start()
    {
        m_offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SetCameraPosition();
    }

    void SetCameraPosition()
    {
        transform.position = m_player.transform.position + m_offset;
    }
}
