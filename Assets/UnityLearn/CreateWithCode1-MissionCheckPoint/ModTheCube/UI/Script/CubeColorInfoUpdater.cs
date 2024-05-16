using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ModTheCube
{
    public class CubeColorInfoUpdater : MonoBehaviour
    {
        [SerializeField] private Material m_targetMaterial;

        [SerializeField] private TextMeshProUGUI m_rValueText;
        [SerializeField] private TextMeshProUGUI m_gValueText;
        [SerializeField] private TextMeshProUGUI m_bValueText;
        [SerializeField] private TextMeshProUGUI m_aValueText;

        void Update()
        {
            if (m_targetMaterial != null)
            {
                Color color = m_targetMaterial.color;
                m_rValueText.text = $"R: {color.r:F2}";
                m_gValueText.text = $"G: {color.g:F2}";
                m_bValueText.text = $"B: {color.b:F2}";
                m_aValueText.text = $"A: {color.a:F2}";
            }
        }
    }
}