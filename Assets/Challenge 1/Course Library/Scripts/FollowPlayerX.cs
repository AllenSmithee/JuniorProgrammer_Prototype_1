using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(40.0f, 0, 15.0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowAndPutInfrontOfPlayer();
    }

    void FollowPlayer()
    {
        transform.position = plane.transform.position + offset;

    }

    void FollowAndPutInfrontOfPlayer()
    {
        Vector3 rotatedOffset = plane.transform.rotation * offset;
        transform.position = plane.transform.position + rotatedOffset;
        transform.LookAt(plane.transform);
    }


}
