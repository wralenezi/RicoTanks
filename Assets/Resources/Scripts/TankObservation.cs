using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankObservation : MonoBehaviour
{
    // ray length
    float m_rayLength = 2f;

    // Number of rays casted
    int m_rayCount = 5;


    // Tank Motion
    float m_speed = 1f;
    float m_rotationSpeed = 60f;

    public Vector2 DirFromAngle(float angleInDegree, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegree += transform.eulerAngles.y;
        }

        return new Vector2(Mathf.Sin(angleInDegree * Mathf.Deg2Rad), Mathf.Cos(angleInDegree * Mathf.Deg2Rad));
    }


    // Cast rays around
    void CastRays()
    {
        float angle = 360f;
        float angleSize = angle / m_rayCount;

        while (angle > 0f)
        {
            Debug.DrawRay(transform.position, m_rayLength * DirFromAngle(angle, true), Color.red);
            angle -= angleSize;
        }
    }


    void ApplyControl()
    {
        if (Input.GetKey("w"))
            transform.position += transform.up * m_speed * Time.deltaTime;
        else if (Input.GetKey("a"))
            transform.Rotate(Vector3.forward * m_rotationSpeed * Time.deltaTime);
        else if (Input.GetKey("d"))
            transform.Rotate(Vector3.forward * -m_rotationSpeed * Time.deltaTime);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CastRays();
        ApplyControl();
    }
}
