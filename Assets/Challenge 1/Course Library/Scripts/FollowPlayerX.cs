﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge_1
{
    public class FollowPlayerX : MonoBehaviour
    {
        [SerializeField] GameObject m_plane;
        private Vector3 m_offset = new Vector3(40.0f, 0, 15.0f);
        private Vector3 m_initialRotation = new Vector3(0, -90, 0);


        // Start is called before the first frame update
        void Start()
        {
            transform.Rotate(m_initialRotation);
        }
        
        // Update is called once per frame
        void LateUpdate()
        {
            DynamicFollowPlayer();
        }

        void DynamicFollowPlayer()
        {
            Vector3 rotatedOffset = m_plane.transform.rotation * m_offset;
            transform.position = m_plane.transform.position + rotatedOffset;
            transform.LookAt(m_plane.transform);
        }


    }
}