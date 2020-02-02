using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private int m_RotationSpeed;

    public RotationAxis m_Axis;

    // Update is called once per frame
    void Update()
    {
        switch (m_Axis)
        {
            case RotationAxis.X:
                this.transform.Rotate(Vector3.right, Time.deltaTime * m_RotationSpeed);
                break;
            case RotationAxis.Y:
                this.transform.Rotate(Vector3.up, Time.deltaTime * m_RotationSpeed);
                break;
            case RotationAxis.Z:
                this.transform.Rotate(Vector3.forward, Time.deltaTime * m_RotationSpeed);
                break;
            default:
                break;
        }
    }
}
