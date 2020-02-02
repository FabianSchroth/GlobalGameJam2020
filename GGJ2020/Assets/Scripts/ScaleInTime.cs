using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleInTime : MonoBehaviour
{
    [SerializeField]
    float m_From;

    [SerializeField]
    float m_To;

    [SerializeField]
    float m_In;

    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        transform.localScale = Vector3.one * Mathf.Lerp(m_From,m_To,timer/m_In);
        if (timer >= m_In)
        {
            Destroy(this.gameObject);
        }
    }
}
