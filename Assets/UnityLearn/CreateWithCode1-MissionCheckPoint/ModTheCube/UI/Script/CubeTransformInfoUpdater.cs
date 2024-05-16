using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModTheCube
{
    public class CubeTransformInfoUpdater : MonoBehaviour
    {
        [SerializeField] private Transform m_targetTransform;

        [SerializeField] private TMPro.TextMeshProUGUI m_positionText;
        [SerializeField] private TMPro.TextMeshProUGUI m_rotationText;
        [SerializeField] private TMPro.TextMeshProUGUI m_scaleText;

        void Update()
        {
            if (m_targetTransform != null)
            {
                m_positionText.text = $"Position: {m_targetTransform.position.ToString()}";
                m_rotationText.text = $"Rotation: {m_targetTransform.rotation.eulerAngles.ToString()}";
                m_scaleText.text = $"Scale: {m_targetTransform.localScale.ToString()}";
            }
        }







    }
}