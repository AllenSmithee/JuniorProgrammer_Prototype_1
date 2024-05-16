using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ModTheCube
{
    public class ApplyFromUI : MonoBehaviour
    {
        [SerializeField] private Cube m_targetCube;

        [SerializeField] private Toggle m_rotateXToggle;
        [SerializeField] private Toggle m_rotateYToggle;
        [SerializeField] private Toggle m_rotateZToggle;
        [SerializeField] private Toggle m_isRandomColorToggle;
        [SerializeField] private Toggle m_isChangeGraduallyToggle;

        [SerializeField] private Slider m_alphaSlider;
        [SerializeField] private Slider m_rotateSpeedSlider;
        [SerializeField] private Slider m_intervertTimeSlider;
        [SerializeField] private Slider m_changeGraduallyDurationSlider;

        [SerializeField] private Button m_changeColorButton;
        [SerializeField] private Button m_randomEverythingButton;


        void OnEnable()
        {
            m_changeColorButton.onClick.AddListener(() =>
            {
                m_targetCube.ChangeColorAction();
            });

            m_randomEverythingButton.onClick.AddListener(() =>
            {
                m_targetCube.RandomEverythingAction();
            });
        }
        void OnDisable()
        {
            m_changeColorButton.onClick.RemoveAllListeners();
            m_randomEverythingButton.onClick.RemoveAllListeners();
        }


        void Start()
        {
            m_rotateXToggle.isOn = m_targetCube.IsRotateX;
            m_rotateYToggle.isOn = m_targetCube.IsRotateY;
            m_rotateZToggle.isOn = m_targetCube.IsRotateZ;

            m_isRandomColorToggle.isOn = m_targetCube.IsRandomColor;
            m_isChangeGraduallyToggle.isOn = m_targetCube.IsChangeGradually;

            m_alphaSlider.minValue = 0.0f;
            m_alphaSlider.maxValue = 1.0f;
            m_alphaSlider.value = m_targetCube.AlphaColor;

            m_rotateSpeedSlider.minValue = m_targetCube.MinRotationSpeed;
            m_rotateSpeedSlider.maxValue = m_targetCube.MaxRotationSpeed;
            m_rotateSpeedSlider.value = m_targetCube.CurrentRotateSpeed;

            m_intervertTimeSlider.minValue = m_targetCube.MinIntervertTime;
            m_intervertTimeSlider.maxValue = m_targetCube.MaxIntervertTime;
            m_intervertTimeSlider.value = m_targetCube.CurrentIntervertTime;

            m_changeGraduallyDurationSlider.minValue = m_targetCube.MinGraudallyChangeDuration;
            m_changeGraduallyDurationSlider.maxValue = m_targetCube.MaxGraudallyChangeDuration;
            m_changeGraduallyDurationSlider.value = m_targetCube.CurrentGraudallyChangeDuration;








        }

        void Update()
        {
            m_targetCube.IsRotateX = m_rotateXToggle.isOn;
            m_targetCube.IsRotateY = m_rotateYToggle.isOn;
            m_targetCube.IsRotateZ = m_rotateZToggle.isOn;

            m_targetCube.IsRandomColor = m_isRandomColorToggle.isOn;
            m_targetCube.IsChangeGradually = m_isChangeGraduallyToggle.isOn;


            m_targetCube.AlphaColor = m_alphaSlider.value;
            m_targetCube.CurrentRotateSpeed = m_rotateSpeedSlider.value;
            m_targetCube.CurrentIntervertTime = m_intervertTimeSlider.value;
            m_targetCube.CurrentGraudallyChangeDuration = m_changeGraduallyDurationSlider.value;




        }




    }
}