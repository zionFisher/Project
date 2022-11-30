using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float OriSpeed = 10f;
    public float MoveSpeed = 3f;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        float xOri = Input.GetAxis("Mouse X");
        float yOri = Input.GetAxis("Mouse Y");
        AdjustOrientation(xOri, yOri);

        float xPos = Input.GetAxis("Horizontal");
        float zPos = Input.GetAxis("Vertical");
        AdjustPosition(xPos, zPos);
    }

    private void AdjustOrientation(float xDelta, float yDelta)
    {
        Vector3 orientation = transform.rotation.eulerAngles;

        orientation.y += xDelta * OriSpeed;
        orientation.x -= yDelta * OriSpeed;

        if (orientation.x < 0f)
        {
            orientation.x += 360f;
        }
        else if (orientation.x >= 360f)
        {
            orientation.x -= 360f;
        }

        if (orientation.x > 90f && orientation.x < 270f)
        {
            orientation.x = 0f;
        }

        gameObject.transform.rotation = Quaternion.Euler(orientation);
    }

    private void AdjustPosition(float xDelta, float zDelta)
    {
        Vector3 direction = transform.rotation * new Vector3(xDelta, 0f, zDelta).normalized;

        var pos = gameObject.transform.position;
        pos += direction * MoveSpeed * Time.fixedDeltaTime;

        gameObject.transform.position = pos;
    }
}
