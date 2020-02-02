using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    #region Members / Properties / Constants

    private static Player m_Instance;
    public static Player Instance { get { return m_Instance; } set { m_Instance = value; } }

    public int m_RemainingHealth;
    public int m_MaxHealth = 3;

    [SerializeField]
    private Image[] Lifes;

    int m_SpareParts = 0;

    public int SpareParts
    {
        get => m_SpareParts;
        set
        {
            m_SparepartText.text = value.ToString();
            m_SpareParts = value;
        }
    }

    public Weapon CurrentWeapon { get; set; }

    [SerializeField]
    int m_CurrentWeaponIndx = 0;

    [SerializeField]
    Weapon[] m_Weapons;

    [SerializeField]
    private float m_Speed = 7;

    [SerializeField]
    private LerpAlpha m_LerpAlpha;

    private PlayerControls m_Controls;

    private Vector2 moveInput;

    private Rigidbody m_Rb;

    [SerializeField]
    private Text m_SparepartText;

    #endregion

    #region Functions

    private void Shoot()
    {
        m_Weapons[m_CurrentWeaponIndx].Shoot();
    }

    private void SwapWeapon(int _index)
    {
        m_Weapons[m_CurrentWeaponIndx].gameObject.SetActive(false);
        m_Weapons[_index].gameObject.SetActive(true);
        m_CurrentWeaponIndx = _index;
    }

    private void Movement()
    {
        float hor = moveInput.x;
        float vert = moveInput.y;

        m_Rb.MovePosition(transform.position + new Vector3(hor, 0, vert) * m_Speed * Time.deltaTime);
    }

    private void LookDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mousePos - playerPos;
        transform.rotation = Quaternion.Euler(0, Vector3.Angle(Vector3.up, direction) * ((mousePos.x > playerPos.x) ? 1 : -1), 0);
    }

    public void SwitchRoomFade(float _duration, System.Action _action)
    {
        m_LerpAlpha.LerpThatAlpha(_duration, true, _action);
    }

    private void Interact()
    {
        Collider[] col = Physics.OverlapSphere(transform.position + Vector3.up, 2);
        Debug.Log(col);

        foreach (Collider item in col)
        {
            Debug.Log(item.name);

            if (item.tag == "Sparepart")
            {
                Destroy(item.gameObject);
                SpareParts++;
            }
            else
            {
                RepairSpot spot = item.gameObject.GetComponent<RepairSpot>();
                if (spot)
                {
                    if (spot.RemainingMaterialsToRepair < SpareParts)
                    {
                        SpareParts -= spot.RemainingMaterialsToRepair;
                        spot.Repair(spot.RemainingMaterialsToRepair);
                    }
                }
                else
                {
                    EndRoom endRoom = item.gameObject.GetComponent<EndRoom>();
                    if (endRoom)
                    {
                        if (endRoom.DoorIsOpen)
                        {
                            GameManager.Instance.EndGame();
                        }
                    }
                }
            }

        }
    }

    /// <summary>
    /// Called when the player got hit by an enemy
    /// </summary>
    /// <param name="_amount">The amount of damage to take</param>
    public void TakeDamage(int _amount)
    {
        m_RemainingHealth -= _amount;
        if (m_RemainingHealth < 3 && m_RemainingHealth >= 0)
        {
            Lifes[m_RemainingHealth].enabled = false;
        }
        //TODO: Update GUI

        if (m_RemainingHealth <= 0)
        {
            Debug.Log("GameOver!");
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

        m_Rb = GetComponent<Rigidbody>();

        m_Controls = new PlayerControls();

        m_Controls.PlayerMaps.Movement.performed += _ => moveInput = m_Controls.PlayerMaps.Movement.ReadValue<Vector2>();
        m_Controls.PlayerMaps.Movement.canceled += _ => moveInput = m_Controls.PlayerMaps.Movement.ReadValue<Vector2>();

        m_Controls.PlayerMaps.Shoot.performed += _ => Shoot();

        m_Controls.PlayerMaps.Interact.performed += _ => Interact();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        m_Weapons[m_CurrentWeaponIndx].gameObject.SetActive(true);
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
