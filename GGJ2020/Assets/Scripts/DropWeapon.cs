using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWeapon : MonoBehaviour
{    
    public EWeapon m_myWeapon;
}

public enum EWeapon
{
    Pistol,
    Shotgun,
    LMG,
    Minigun,
    Rocketlauncher,
}
