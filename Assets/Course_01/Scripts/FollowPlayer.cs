using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject m_player;
    
    Vector3 m_offset = new Vector3(0f,5f,-10f);


    // Start is called before the first frame update
    void Start()
    {
        
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
