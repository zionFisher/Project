using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform Target;

    private void Start()
    {
        Target = Camera.main.transform;
    }

    private void Update()
    {
        transform.position = Target.position + Target.forward * 2f;
        transform.rotation = Target.rotation;
    }
}
