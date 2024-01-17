using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCam : MonoBehaviour
{
    public GameObject target;
    bool waitPosition;
    float r;

    void Update()
    {
        transform.LookAt(target.transform);
        //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, 45, ref r, 0.1f * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
