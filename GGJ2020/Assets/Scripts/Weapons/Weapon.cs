using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    #region Members / Properties / Constants

    protected string Name { get; set; }
    protected int Damage { get; set; }
    protected int AttackSpeed { get; set; }

    [SerializeField]
    protected Transform m_SpawnPointProjectile;

    public abstract void Shoot();

    #endregion
}
