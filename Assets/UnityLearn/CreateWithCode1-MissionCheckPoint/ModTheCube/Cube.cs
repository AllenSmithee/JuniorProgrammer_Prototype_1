using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [Header("Cube Setting")]
    [SerializeField] private MeshRenderer Renderer;
    [SerializeField] private Material m_material;

    [Header("Cube Size and Position Properties")]
    [SerializeField] private Vector3 m_position = new Vector3(3, 4, 1);
    [SerializeField] private Vector3 m_scale = Vector3.one;

    [Header("Cube Rotate Properties")]
    [SerializeField] private float m_rotateSpeed = 10.0f;
    [SerializeField] private bool m_rotateX = false;
    [SerializeField] private bool m_rotateY = false;
    [SerializeField] private bool m_rotateZ = false;

    [Header("Cube Color Properties")]

    [SerializeField] private Color m_color = new Color(0.5f, 1.0f, 0.3f, 1.0f);
    [SerializeField] private bool m_isRandomColor = false;
    private float m_timer = 0.0f;
    [SerializeField] private float m_intervertColorTime = 5.0f;

    [SerializeField] private bool m_changeColorGraudally = false;
    [SerializeField] private float m_graudallyChangeDuration = 2.0f;

    [Header("Debug fun")]
    [SerializeField] private bool m_startRandom = false;

    private bool m_colorIsChanging = false;

    private Vector3 Scale
    {
        get => m_scale * 1.3f;
    }
    private Vector3 RotateDirection
    {
        get => new Vector3(m_rotateX ? 1 : 0, m_rotateY ? 1 : 0, m_rotateZ ? 1 : 0);
    }

    private float AlphaColor
    {
        get => m_color.a;
        set
        {
            m_color.WithAlpha(value);
        }
    }

    private Color NewColor
    {
        get => m_color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, AlphaColor, AlphaColor);
    }

    void Start()
    {
        transform.position = m_position;
        transform.localScale = Scale;
        m_material.color = new Color(m_color.r, m_color.g, m_color.b, AlphaColor);

        if (m_startRandom)
            RandomStart();
    }

    void Update()
    {
        RotateCube();
        UpdateAlphaValue();

        if (m_isRandomColor)
            ChangeColorInTick();
    }

    void RandomStart()
    {
        transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));
        transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        m_material.color = NewColor;
    }

    void RotateCube()
    {
        transform.Rotate(RotateDirection * m_rotateSpeed * Time.deltaTime);
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
                m_material.color = NewColor;
            }
        }
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
        float duration = m_graudallyChangeDuration;
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
