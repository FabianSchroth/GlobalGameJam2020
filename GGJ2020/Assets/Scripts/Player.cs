using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{

    #region Members / Properties / Constants

    int m_RemainingHealth;
    int m_MaxHealth;

    public Weapon CurrentWeapon { get; set; }

    private CharacterController m_CC;

    private PlayerControls m_Controls;

    private Vector2 moveInput;
    #endregion

    #region Functions

    private void Awake()
    {
        m_CC = GetComponent<CharacterController>();

        m_Controls = new PlayerControls();

        m_Controls.PlayerMaps.Movement.performed += _ => moveInput = m_Controls.PlayerMaps.Movement.ReadValue<Vector2>();
        m_Controls.PlayerMaps.Movement.canceled += _ => moveInput = m_Controls.PlayerMaps.Movement.ReadValue<Vector2>();

        m_Controls.PlayerMaps.Shoot.performed += _ => Shoot();
    }

    private void OnEnable()
    {
        m_Controls.Enable();
    }

    private void OnDisable()
    {
        m_Controls.Disable();
    }

    private void Update()
    {
        Movement();
    }

    private void Shoot()
    {
        
    }

    private void Movement()
    {
        float hor = moveInput.x;
        float vert = moveInput.y;

        m_CC.Move(new Vector3(hor,0, vert));
    }

    /// <summary>
    /// Called when the player got hit by an enemy
    /// </summary>
    /// <param name="_amount">The amount of damage to take</param>
    public void TakeDamage(int _amount)
    {
        m_RemainingHealth -= _amount;

        //TODO: Update GUI

        if (m_RemainingHealth <= 0)
        {
            // TODO: Game Over
        }
    }

    #endregion
}
