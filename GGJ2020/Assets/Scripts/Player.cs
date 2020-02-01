using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{

    #region Members / Properties / Constants

    private static Player m_Instance;
    public static Player Instance { get { return m_Instance; } set { m_Instance = value; } }

    int m_RemainingHealth;
    int m_MaxHealth;

    public Weapon CurrentWeapon { get; set; }

    [SerializeField]
    private float m_Speed = 7;

    private CharacterController m_CharacterController;

    private PlayerControls m_Controls;

    private Vector2 moveInput;

    #endregion

    #region Functions

    private void Shoot()
    {
        
    }

    private void Movement()
    {
        float hor = moveInput.x;
        float vert = moveInput.y;

        m_CharacterController.Move(new Vector3(hor,0, vert) * m_Speed * Time.deltaTime);
    }

    private void LookDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mousePos - playerPos;
        transform.rotation = Quaternion.Euler(0,Vector3.Angle(Vector3.up, direction) * ((mousePos.x > playerPos.x) ? 1:-1),0);
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

    #region Unity Lifecycle

    private void Awake()
    {
        if (m_Instance != null && m_Instance != this)
            Destroy(this.gameObject);
        else
            m_Instance = this;

        m_CharacterController = GetComponent<CharacterController>();

        m_Controls = new PlayerControls();

        m_Controls.PlayerMaps.Movement.performed += _ => moveInput = m_Controls.PlayerMaps.Movement.ReadValue<Vector2>();
        m_Controls.PlayerMaps.Movement.canceled += _ => moveInput = m_Controls.PlayerMaps.Movement.ReadValue<Vector2>();

        m_Controls.PlayerMaps.Shoot.performed += _ => Shoot();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        Movement();
        LookDirection();
    }

    private void OnEnable()
    {
        m_Controls.Enable();
    }

    private void OnDisable()
    {
        m_Controls.Disable();
    }
    #endregion    
}
