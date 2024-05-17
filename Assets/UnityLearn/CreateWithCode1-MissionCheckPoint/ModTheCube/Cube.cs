using System.Collections;
using UnityEngine;

namespace ModTheCube
{
    public class Cube : MonoBehaviour
    {
        [Header("Cube Setting")]
        [SerializeField] private MeshRenderer Renderer;
        [SerializeField] private Material m_material;

        [Header("Cube Size and Position Properties")]
        [SerializeField] private Vector3 m_position = new Vector3(3, 4, 1);
        [SerializeField] private Vector3 m_scale = Vector3.one;

        [Header("Cube Rotate Properties")]

        [SerializeField] private float m_minRotationSpeed = 0.00f;
        [SerializeField] private float m_maxRotationSpeed = 100.0f;
        [SerializeField] private float m_currentRotateSpeed = 10.0f;
        [SerializeField] private bool m_rotateX = false;
        [SerializeField] private bool m_rotateY = false;
        [SerializeField] private bool m_rotateZ = false;

        [Header("Cube Color Properties")]

        [SerializeField] private Color m_color = new Color(0.5f, 1.0f, 0.3f, 1.0f);
        [SerializeField] private bool m_isRandomColor = false;
        private float m_timer = 0.0f;
        [SerializeField] private float m_minIntervertTime = 0.0f;
        [SerializeField] private float m_maxIntervertTime = 10.0f;
        [SerializeField] private float m_intervertColorTime = 5.0f;

        [SerializeField] private bool m_changeColorGraudally = false;
        [SerializeField] private float m_minColorChangeDuration = 0;
        [SerializeField] private float m_maxColorChangeDuration = 10.0f;
        [SerializeField] private float m_currentGraudallyChangeDuration = 2.0f;

        [Header("Debug fun")]
        [SerializeField] private bool m_startRandom = false;


        public event System.Action OnRandomEverythingAction;
        private bool m_colorIsChanging = false;

        private Vector3 Scale
        {
            get => m_scale * 1.3f;
        }
        private Vector3 RotateDirection
        {
            get => new Vector3(m_rotateX ? 1 : 0, m_rotateY ? 1 : 0, m_rotateZ ? 1 : 0);
        }

        public float AlphaColor
        {
            get => m_color.a;
            set
            {
                m_color = new Color(m_color.r, m_color.g, m_color.b, value);
            }
        }

        private Color NewColor
        {
            get => m_color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, AlphaColor, AlphaColor);
        }

        public float MinRotationSpeed
        {
            get => m_minRotationSpeed;
            set => m_minRotationSpeed = value;
        }
        public float MaxRotationSpeed
        {
            get => m_maxRotationSpeed;
            set => m_maxRotationSpeed = value;
        }

        public float CurrentRotateSpeed
        {
            get => m_currentRotateSpeed;
            set => m_currentRotateSpeed = Mathf.Clamp(value, m_minRotationSpeed, m_maxRotationSpeed);
        }

        public float MinIntervertTime
        {
            get => m_minIntervertTime;
            set => m_minIntervertTime = value;
        }
        public float MaxIntervertTime
        {
            get => m_maxIntervertTime;
            set => m_maxIntervertTime = value;
        }

        public float CurrentIntervertTime
        {
            get => m_intervertColorTime;
            set => m_intervertColorTime = Mathf.Clamp(value, m_minIntervertTime, m_maxIntervertTime);
        }

        public float MinGraudallyChangeDuration
        {
            get => m_minColorChangeDuration;
            set => m_minColorChangeDuration = value;
        }
        public float MaxGraudallyChangeDuration
        {
            get => m_maxColorChangeDuration;
            set => m_maxColorChangeDuration = value;
        }
        public float CurrentGraudallyChangeDuration
        {
            get => m_currentGraudallyChangeDuration;
            set => m_currentGraudallyChangeDuration = Mathf.Clamp(value, m_minColorChangeDuration, m_maxColorChangeDuration);
        }

        public bool IsRotateX
        {
            get => m_rotateX;
            set => m_rotateX = value;
        }
        public bool IsRotateY
        {
            get => m_rotateY;
            set => m_rotateY = value;
        }
        public bool IsRotateZ
        {
            get => m_rotateZ;
            set => m_rotateZ = value;
        }
        public bool IsRandomColor
        {
            get => m_isRandomColor;
            set => m_isRandomColor = value;
        }

        public bool IsChangeGradually
        {
            get => m_changeColorGraudally;
            set => m_changeColorGraudally = value;
        }



        void Awake()
        {
            if (m_startRandom)
                RandomEverythingAction();
        }

        void Start()
        {
            if (m_startRandom)
                return;
            transform.position = m_position;
            transform.localScale = Scale;
            m_material.color = new Color(m_color.r, m_color.g, m_color.b, AlphaColor);
        }

        void Update()
        {
            RotateCube();
            UpdateAlphaValue();

            if (m_isRandomColor)
                ChangeColorInTick();
        }

        public void RandomEverythingAction()
        {

            StopAllCoroutines();
            m_colorIsChanging = false;
            
            transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
            transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));
            transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

            OnRandomEverythingAction?.Invoke();
            
            m_material.color = NewColor;
        }

        void RotateCube()
        {
            transform.Rotate(RotateDirection * m_currentRotateSpeed * Time.deltaTime);
        }

        void UpdateAlphaValue()
        {
            m_material.color = new Color(m_material.color.r, m_material.color.g, m_material.color.b, AlphaColor);
        }
        void ChangeColorInTick()
        {
            if (ValidateToChangeColor())
            {
                if (m_changeColorGraudally)
                {
                    StartCoroutine(ChangeColorGraudally(NewColor));
                }
                else
                {
                    ChangeColorAction();
                }
            }
        }

        public void ChangeColorAction()
        {
            StopAllCoroutines();
            m_material.color = NewColor;
        }
        bool ValidateToChangeColor()
        {
            if (m_colorIsChanging)
                return false;
            m_timer += Time.deltaTime;
            if (m_timer < m_intervertColorTime)
            {
                return false;
            }
            m_timer = 0.0f;
            return true;
        }
        IEnumerator ChangeColorGraudally(Color targetColor)
        {
            float duration = m_currentGraudallyChangeDuration;
            float timer = 0.0f;
            Color initialColor = m_material.color;

            while (timer < duration)
            {
                m_colorIsChanging = true;
                timer += Time.deltaTime;
                m_material.color = Color.Lerp(initialColor, targetColor, timer / duration);
                yield return null;
            }

            m_material.color = targetColor;
            m_colorIsChanging = false;
            yield return null;
        }
    }
}