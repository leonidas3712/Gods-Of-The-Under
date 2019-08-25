// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Input/PlayerControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""3ca760dd-3fac-4962-af1c-da03fe551b1a"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5fc9bec0-c4d4-4766-9d39-59184a2f0b7e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Charge"",
                    ""type"": ""Button"",
                    ""id"": ""b6d3eaef-4cf4-4d7f-922d-c10958239ab6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""09ee95de-2b95-4423-ac69-de47ab0d60c6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CallBack"",
                    ""type"": ""Button"",
                    ""id"": ""ab783339-3a8b-4269-9366-9b3253b4f18a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimDirX"",
                    ""type"": ""Value"",
                    ""id"": ""22320a08-3d82-49df-a81d-b869283ee06d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimDirY"",
                    ""type"": ""Value"",
                    ""id"": ""2b4466c3-e7b2-465f-b30d-4e281fee2501"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8acabf13-dacb-4e3d-8abf-3918fb40427a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard_Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f94b7fd-9c28-42a6-b802-d437e9407585"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00082ce9-d0a6-441f-9c08-3d36e6f4dde5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc5c2a72-beba-4470-abab-483057d05445"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75a70e28-6b51-43bd-a020-cf0a9c998e6f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d119bbb-5224-45b1-bd7a-2ff208b75f2f"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad984662-6f31-4445-9795-f59492bca4e8"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""CallBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef7e80eb-5d94-45ea-914b-887f2d294c63"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CallBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae50b254-70a6-40be-b5a9-cd0ede2e0517"",
                    ""path"": ""<Mouse>/position/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""AimDirX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28934ad5-0f9a-439c-803c-db44b9400508"",
                    ""path"": ""<DualShockGamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AimDirX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0be8896b-d6a6-47e6-bb75-368f79a696bd"",
                    ""path"": ""<Mouse>/position/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""AimDirY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""545610fb-d1de-47f3-b44b-15db9760137c"",
                    ""path"": ""<DualShockGamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""AimDirY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard_Mouse"",
            ""basedOn"": """",
            ""bindingGroup"": ""Keyboard_Mouse"",
            ""devices"": []
        },
        {
            ""name"": ""Controller"",
            ""basedOn"": """",
            ""bindingGroup"": ""Controller"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_Jump = m_Player.GetAction("Jump");
        m_Player_Charge = m_Player.GetAction("Charge");
        m_Player_Throw = m_Player.GetAction("Throw");
        m_Player_CallBack = m_Player.GetAction("CallBack");
        m_Player_AimDirX = m_Player.GetAction("AimDirX");
        m_Player_AimDirY = m_Player.GetAction("AimDirY");
    }

    ~PlayerControls()
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
    private readonly InputAction m_Player_AimDirX;
    private readonly InputAction m_Player_AimDirY;
    public struct PlayerActions
    {
        private PlayerControls m_Wrapper;
        public PlayerActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Charge => m_Wrapper.m_Player_Charge;
        public InputAction @Throw => m_Wrapper.m_Player_Throw;
        public InputAction @CallBack => m_Wrapper.m_Player_CallBack;
        public InputAction @AimDirX => m_Wrapper.m_Player_AimDirX;
        public InputAction @AimDirY => m_Wrapper.m_Player_AimDirY;
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
                AimDirX.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDirX;
                AimDirX.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDirX;
                AimDirX.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDirX;
                AimDirY.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDirY;
                AimDirY.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDirY;
                AimDirY.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimDirY;
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
                AimDirX.started += instance.OnAimDirX;
                AimDirX.performed += instance.OnAimDirX;
                AimDirX.canceled += instance.OnAimDirX;
                AimDirY.started += instance.OnAimDirY;
                AimDirY.performed += instance.OnAimDirY;
                AimDirY.canceled += instance.OnAimDirY;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_Keyboard_MouseSchemeIndex = -1;
    public InputControlScheme Keyboard_MouseScheme
    {
        get
        {
            if (m_Keyboard_MouseSchemeIndex == -1) m_Keyboard_MouseSchemeIndex = asset.GetControlSchemeIndex("Keyboard_Mouse");
            return asset.controlSchemes[m_Keyboard_MouseSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.GetControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnCharge(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnCallBack(InputAction.CallbackContext context);
        void OnAimDirX(InputAction.CallbackContext context);
        void OnAimDirY(InputAction.CallbackContext context);
    }
}
