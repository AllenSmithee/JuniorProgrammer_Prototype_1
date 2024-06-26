using System.Collections;
using System.Collections.Generic;
using Course_01;
using UnityEngine;


namespace BonusFeatures1
{
    public class CameraSwitcher : MonoBehaviour
    {
        [SerializeField] FollowPlayer m_followPlayer;
        
        
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                if(m_followPlayer.CurrentCameraType == FollowPlayer.CameraType.FirstPerson)
                {
                    m_followPlayer.SetCameraType(FollowPlayer.CameraType.ThirdPerson);
                }
                else
                {
                    m_followPlayer.SetCameraType(FollowPlayer.CameraType.FirstPerson);
                }
            }
        }
        
        
        
        
        
    }
}