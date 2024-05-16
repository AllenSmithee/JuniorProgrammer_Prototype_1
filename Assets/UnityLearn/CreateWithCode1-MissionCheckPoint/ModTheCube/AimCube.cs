using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCube : MonoBehaviour
{
    [SerializeField] GameObject m_cube;
    void Start()
    {
        transform.LookAt(m_cube.transform);
    }


}
