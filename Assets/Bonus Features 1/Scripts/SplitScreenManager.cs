using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BonusFeatures1
{
    public class SplitScreenManager : MonoBehaviour
    {
        [SerializeField] Camera m_camera1;
        [SerializeField] Camera m_camera2;

        void Start()
        {
            m_camera1.rect = new Rect(0, 0, 0.5f, 1);
            m_camera2.rect = new Rect(0.5f, 0, 0.5f, 1);
        }









    }
}