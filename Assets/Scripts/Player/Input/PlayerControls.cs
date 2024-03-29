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
                    ""expectedControlType"": ""Button"",
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
                },
                {
                    ""name"": ""Walking"",
                    ""type"": ""Value"",
                    ""id"": ""32f9bdd1-c07d-43af-a4c8-ec3a5cb4a9e4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""80724930-59a0-4314-85cd-6a5e7dff68c0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Heal"",
                    ""type"": ""Button"",
                    ""id"": ""747f98e2-7a1c-41ef-b485-0ea17ca8083e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reincarnetion"",
                    ""type"": ""Button"",
                    ""id"": ""5f8a7663-f079-4c8c-89e4-ac5d16ada39d"",
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
                    ""path"": ""<Gamepad>/rightTrigger"",
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
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5dfd99a7-cfdb-4c71-96e3-6f1d107dfe5a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e7e92ae5-5b91-4db1-aaa1-106864142f39"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""369bf6fa-e89a-497f-852d-29eee85eddde"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""032f25e5-5427-431d-a6cc-386347d4af91"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""542a57dd-2850-4d54-aaab-36ace63d8a55"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63364296-2308-4587-b04a-aa66455408c3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23b54a67-9bec-4df7-8090-f9b19dd356e3"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard_Mouse"",
                    ""action"": ""Reincarnetion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard_Mouse"",
            ""bindingGroup"": ""Keyboard_Mouse"",
            ""devices"": []
        },
        {
            ""name"": ""Controller"",
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
        m_Player_Walking = m_Player.GetAction("Walking");
        m_Player_Interact = m_Player.GetAction("Interact");
        m_Player_Heal = m_Player.GetAction("Heal");
        m_Player_Reincarnetion = m_Player.GetAction("Reincarnetion");
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
    private readonly InputAction m_Player_Walking;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Heal;
    private readonly InputAction m_Player_Reincarnetion;
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
        public InputAction @Walking => m_Wrapper.m_Player_Walking;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Heal => m_Wrapper.m_Player_Heal;
        public InputAction @Reincarnetion => m_Wrapper.m_Player_Reincarnetion;
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
                Walking.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalking;
                Walking.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalking;
                Walking.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalking;
                Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                Heal.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHeal;
                Heal.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHeal;
                Heal.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHeal;
                Reincarnetion.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReincarnetion;
                Reincarnetion.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReincarnetion;
                Reincarnetion.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReincarnetion;
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
                Walking.started += instance.OnWalking;
                Walking.performed += instance.OnWalking;
                Walking.canceled += instance.OnWalking;
                Interact.started += instance.OnInteract;
                Interact.performed += instance.OnInteract;
                Interact.canceled += instance.OnInteract;
                Heal.started += instance.OnHeal;
                Heal.performed += instance.OnHeal;
                Heal.canceled += instance.OnHeal;
                Reincarnetion.started += instance.OnReincarnetion;
                Reincarnetion.performed += instance.OnReincarnetion;
                Reincarnetion.canceled += instance.OnReincarnetion;
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
        void OnWalking(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnHeal(InputAction.CallbackContext context);
        void OnReincarnetion(InputAction.CallbackContext context);
    }
}
