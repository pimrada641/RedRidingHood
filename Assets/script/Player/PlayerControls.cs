// GENERATED AUTOMATICALLY FROM 'Assets/script/Player/PlayerControls.inputactions'

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
            ""name"": ""Player Control"",
            ""id"": ""ffd5c372-30ab-4f6e-9472-3d8d489921b8"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""da81048a-f68e-46a9-9531-399a88955ec2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""b8e57c69-01f8-4156-ab68-05994a5be4d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ea76cfb9-876e-4680-9dfa-bab0a03d59af"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e39e974b-9333-44a4-9f18-2dc3fb6ec74d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Accept"",
                    ""type"": ""Button"",
                    ""id"": ""8b9e83f6-a727-4bbc-8820-a2e0aa44ea79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0b1e2891-1baa-4320-8316-2639069b4aca"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b58bd5de-3c1c-4bec-9c74-c0f71e63ca9a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c64610a0-a547-443d-9cb4-00f0b93ca2f4"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7adda437-aa24-47da-bd32-a5f2bcdbb278"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""658025b1-452c-4f4a-9de2-5391eb7d26fb"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a7cf567-ac0a-4c0f-b37b-9e3edffcef08"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4894f0b5-9c8c-4244-9cc3-80a2b47dc9d5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2efe2d4c-a331-42b4-a68d-171def3347c9"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98de6ab7-e68f-4662-836c-6f64b1d67e17"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1eabb46-d6cb-4bb7-9e80-fe127f51f1de"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game Menu"",
            ""id"": ""055f5bcb-a3ab-452e-81dc-0ad7718913bc"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""e3064632-ccf4-4705-b7b5-8ce70fd086e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e10578d1-e07d-482f-9b01-e89c38bab3b0"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fac246e2-7d95-4d3e-bf17-572b4f0eb0f4"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a14802f-2577-42a8-a86f-a04175f6b4a2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d756107-2800-404c-9231-6f838d6ad925"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Game Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4cffe8e-587a-49e8-99a0-836282e2061b"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Game Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""748dc35c-b6cb-4d42-8baa-a810484505dc"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Game Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Control
        m_PlayerControl = asset.FindActionMap("Player Control", throwIfNotFound: true);
        m_PlayerControl_Jump = m_PlayerControl.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControl_Attack = m_PlayerControl.FindAction("Attack", throwIfNotFound: true);
        m_PlayerControl_PrimaryPosition = m_PlayerControl.FindAction("PrimaryPosition", throwIfNotFound: true);
        m_PlayerControl_PrimaryContact = m_PlayerControl.FindAction("PrimaryContact", throwIfNotFound: true);
        m_PlayerControl_Accept = m_PlayerControl.FindAction("Accept", throwIfNotFound: true);
        // Game Menu
        m_GameMenu = asset.FindActionMap("Game Menu", throwIfNotFound: true);
        m_GameMenu_Pause = m_GameMenu.FindAction("Pause", throwIfNotFound: true);
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

    // Player Control
    private readonly InputActionMap m_PlayerControl;
    private IPlayerControlActions m_PlayerControlActionsCallbackInterface;
    private readonly InputAction m_PlayerControl_Jump;
    private readonly InputAction m_PlayerControl_Attack;
    private readonly InputAction m_PlayerControl_PrimaryPosition;
    private readonly InputAction m_PlayerControl_PrimaryContact;
    private readonly InputAction m_PlayerControl_Accept;
    public struct PlayerControlActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerControlActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PlayerControl_Jump;
        public InputAction @Attack => m_Wrapper.m_PlayerControl_Attack;
        public InputAction @PrimaryPosition => m_Wrapper.m_PlayerControl_PrimaryPosition;
        public InputAction @PrimaryContact => m_Wrapper.m_PlayerControl_PrimaryContact;
        public InputAction @Accept => m_Wrapper.m_PlayerControl_Accept;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlActions instance)
        {
            if (m_Wrapper.m_PlayerControlActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAttack;
                @PrimaryPosition.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryContact.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPrimaryContact;
                @Accept.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAccept;
                @Accept.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAccept;
                @Accept.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAccept;
            }
            m_Wrapper.m_PlayerControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @PrimaryPosition.started += instance.OnPrimaryPosition;
                @PrimaryPosition.performed += instance.OnPrimaryPosition;
                @PrimaryPosition.canceled += instance.OnPrimaryPosition;
                @PrimaryContact.started += instance.OnPrimaryContact;
                @PrimaryContact.performed += instance.OnPrimaryContact;
                @PrimaryContact.canceled += instance.OnPrimaryContact;
                @Accept.started += instance.OnAccept;
                @Accept.performed += instance.OnAccept;
                @Accept.canceled += instance.OnAccept;
            }
        }
    }
    public PlayerControlActions @PlayerControl => new PlayerControlActions(this);

    // Game Menu
    private readonly InputActionMap m_GameMenu;
    private IGameMenuActions m_GameMenuActionsCallbackInterface;
    private readonly InputAction m_GameMenu_Pause;
    public struct GameMenuActions
    {
        private @PlayerControls m_Wrapper;
        public GameMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GameMenu_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GameMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameMenuActions set) { return set.Get(); }
        public void SetCallbacks(IGameMenuActions instance)
        {
            if (m_Wrapper.m_GameMenuActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GameMenuActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameMenuActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameMenuActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameMenuActions @GameMenu => new GameMenuActions(this);
    public interface IPlayerControlActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnPrimaryPosition(InputAction.CallbackContext context);
        void OnPrimaryContact(InputAction.CallbackContext context);
        void OnAccept(InputAction.CallbackContext context);
    }
    public interface IGameMenuActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
