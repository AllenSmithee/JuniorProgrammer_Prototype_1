using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ModTheCube
{
    public class AimCube : MonoBehaviour
    {
        [SerializeField] GameObject m_cube;

        void OnEnable()
        {
            var targetscript = m_cube.GetComponent<Cube>();
            targetscript.OnRandomEverythingAction += LookAtCube;
        }
        void OnDisable()
        {
            var targetscript = m_cube.GetComponent<Cube>();
            targetscript.OnRandomEverythingAction -= LookAtCube;

        }


        void Start()
        {
            LookAtCube();
        }

        void LookAtCube()
        {
            transform.LookAt(m_cube.transform);
        }

    }
}