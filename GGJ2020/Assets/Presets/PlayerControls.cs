// GENERATED AUTOMATICALLY FROM 'Assets/Presets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerMaps"",
            ""id"": ""5b9460b2-5b9c-4170-a68a-ee80025e8cd0"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""1ab0e939-9e09-4c36-b098-25e16e0260d3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""8922dc93-b296-4767-b006-5677baabb19c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""355948a2-aae3-460a-9156-f209436af346"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""761f016d-38bd-4fe8-ba73-95a4d6827fff"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KeyBoard"",
                    ""id"": ""c1e24ae1-2f0e-4cc2-9685-eeb9c37e72e3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b602877c-2141-4986-b51d-2f8721fcb2a5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""02556c0f-c5c6-409f-a361-c3c8c0b5c59b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""399a1010-f877-4a2f-8a68-2a3499b2eff9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e6e319fc-6d5d-4ab4-b5b3-e647cc544ebe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3f2a25e2-6f08-45f8-b2b3-c450b93da763"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
        // PlayerMaps
        m_PlayerMaps = asset.FindActionMap("PlayerMaps", throwIfNotFound: true);
        m_PlayerMaps_Shoot = m_PlayerMaps.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerMaps_Movement = m_PlayerMaps.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMaps_Interact = m_PlayerMaps.FindAction("Interact", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerMaps
    private readonly InputActionMap m_PlayerMaps;
    private IPlayerMapsActions m_PlayerMapsActionsCallbackInterface;
    private readonly InputAction m_PlayerMaps_Shoot;
    private readonly InputAction m_PlayerMaps_Movement;
    private readonly InputAction m_PlayerMaps_Interact;
    public struct PlayerMapsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMapsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_PlayerMaps_Shoot;
        public InputAction @Movement => m_Wrapper.m_PlayerMaps_Movement;
        public InputAction @Interact => m_Wrapper.m_PlayerMaps_Interact;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMaps; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMapsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMapsActions instance)
        {
            if (m_Wrapper.m_PlayerMapsActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_PlayerMapsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerMapsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerMapsActionsCallbackInterface.OnShoot;
                @Movement.started -= m_Wrapper.m_PlayerMapsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMapsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMapsActionsCallbackInterface.OnMovement;
                @Interact.started -= m_Wrapper.m_PlayerMapsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerMapsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerMapsActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_PlayerMapsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public PlayerMapsActions @PlayerMaps => new PlayerMapsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerMapsActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
