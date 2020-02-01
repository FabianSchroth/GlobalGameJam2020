using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    protected float m_Speed;
    public float Speed
    {
        get => m_Speed;
    }

    [SerializeField]
    protected float m_Lifetime;
    public float Lifetime
    {
        get => m_Lifetime;
    }

    protected abstract void HitSomething(Collision _collision);
}
