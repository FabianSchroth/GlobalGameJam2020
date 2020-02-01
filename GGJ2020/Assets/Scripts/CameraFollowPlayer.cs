using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    float m_Height = 5;

    Transform m_FollowTransform;
    // Start is called before the first frame update
    void Start()
    {
        m_FollowTransform = GameManager.Instance.m_Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(m_FollowTransform.position.x,m_Height,m_FollowTransform.position.z);
    }
}
