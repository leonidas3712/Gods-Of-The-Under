// GENERATED AUTOMATICALLY FROM 'Assets/InputManager.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputManager : IInputActionCollection
{
    private InputActionAsset asset;
    public InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""0428dc01-9082-42fa-9d46-c7381135c8ed"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5b7dae46-fc21-42f3-b35e-a1565d4235df"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Charge"",
                    ""type"": ""Button"",
                    ""id"": ""5681575d-303b-4367-b3e9-d273381393de"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""c209c33c-810c-4762-beef-9f4d006127bc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CallBack"",
                    ""type"": ""Button"",
                    ""id"": ""6fb64f7a-0a01-489a-b04e-4e2e6bb533da"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""35b29fb5-ce57-45ad-9777-3b34101ad2ef"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouase"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3e0e8a8-9ab1-43ba-93c2-561253b2c1e9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouase"",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f0d3824-8dfa-4634-bc70-abfc71cc8984"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouase"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60be7396-507c-44d0-b895-b4c31396fb03"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouase"",
                    ""action"": ""CallBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouase"",
            ""basedOn"": """",
            ""bindingGroup"": ""Keyboard&Mouase"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_Jump = m_Player.GetAction("Jump");
        m_Player_Charge = m_Player.GetAction("Charge");
        m_Player_Throw = m_Player.GetAction("Throw");
        m_Player_CallBack = m_Player.GetAction("CallBack");
    }

    ~InputManager()
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Charge;
    private readonly InputAction m_Player_Throw;
    private readonly InputAction m_Player_CallBack;
    public struct PlayerActions
    {
        private InputManager m_Wrapper;
        public PlayerActions(InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Charge => m_Wrapper.m_Player_Charge;
        public InputAction @Throw => m_Wrapper.m_Player_Throw;
        public InputAction @CallBack => m_Wrapper.m_Player_CallBack;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                Charge.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCharge;
                Charge.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCharge;
                Charge.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCharge;
                Throw.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrow;
                Throw.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrow;
                Throw.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrow;
                CallBack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCallBack;
                CallBack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCallBack;
                CallBack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCallBack;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                Charge.started += instance.OnCharge;
                Charge.performed += instance.OnCharge;
                Charge.canceled += instance.OnCharge;
                Throw.started += instance.OnThrow;
                Throw.performed += instance.OnThrow;
                Throw.canceled += instance.OnThrow;
                CallBack.started += instance.OnCallBack;
                CallBack.performed += instance.OnCallBack;
                CallBack.canceled += instance.OnCallBack;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardMouaseSchemeIndex = -1;
    public InputControlScheme KeyboardMouaseScheme
    {
        get
        {
            if (m_KeyboardMouaseSchemeIndex == -1) m_KeyboardMouaseSchemeIndex = asset.GetControlSchemeIndex("Keyboard&Mouase");
            return asset.controlSchemes[m_KeyboardMouaseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnCharge(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnCallBack(InputAction.CallbackContext context);
    }
}
