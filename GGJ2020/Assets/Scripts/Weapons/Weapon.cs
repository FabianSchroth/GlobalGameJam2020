using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    #region Members / Properties / Constants

    private string Name { get; set; }
    private int Damage { get; set; }
    private int AttackSpeed { get; set; }

    #endregion
}
