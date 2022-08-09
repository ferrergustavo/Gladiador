using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform PJFollow;
    public Vector3 zPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = PJFollow.position + zPosition;
    }
}
