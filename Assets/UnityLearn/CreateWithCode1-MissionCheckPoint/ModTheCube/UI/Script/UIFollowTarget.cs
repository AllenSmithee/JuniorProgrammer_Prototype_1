using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModTheCube
{
    public class UIFollowTarget : MonoBehaviour
    {

        [SerializeField] GameObject m_target;
        [SerializeField] TextMeshProUGUI m_text;
        [SerializeField] Slider m_slider;
        [SerializeField] Vector2 m_offset;

        void Start()
        {
            m_text = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            if (m_target != null)
            {
                transform.position = m_target.transform.position + new Vector3(m_offset.x, m_offset.y, 0);
                m_text.text = m_slider.value.ToString("F2");
            }

        }









    }
}