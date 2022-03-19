// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerControllersInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControllersInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControllersInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControllersInputs"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""9c0339a9-bcfb-4a01-8802-161dcff38ba0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""eb6495fe-5790-4ef7-91a0-d2657c79eff5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PullUpPhone"",
                    ""type"": ""Button"",
                    ""id"": ""75aaad60-594a-4381-b3bf-17c6c537c5db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Flash"",
                    ""type"": ""Button"",
                    ""id"": ""1774dd21-da78-4fee-ae94-868485599b7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RejectCall"",
                    ""type"": ""Button"",
                    ""id"": ""13925d6e-bd3f-46ad-804b-9838c5ddc9aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AcceptCall"",
                    ""type"": ""Button"",
                    ""id"": ""b8feee4b-79f6-47db-aefe-bbe01abcc0f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenMainMenu"",
                    ""type"": ""Button"",
                    ""id"": ""8606c302-f0fc-4cc4-b36f-7aaa68c52a55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DisableFog"",
                    ""type"": ""Button"",
                    ""id"": ""6e90d1e0-e5bb-4814-a9b1-ab85306e68a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchTrack"",
                    ""type"": ""Button"",
                    ""id"": ""0cc96599-d5e5-4e9e-bb6a-1d202a0f0910"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurnAround"",
                    ""type"": ""Button"",
                    ""id"": ""e0aa004b-1975-41b3-bbd0-b9733404cd91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""752825d2-5a42-4825-b33d-f8094cc258da"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PullUpPhone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""014edc1e-5338-4c17-aaa6-23f60018cc8a"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PullUpPhone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""539c7280-9be4-422f-b44f-aac2016e7a95"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19034c7d-dbc0-438a-89ad-d142059ab121"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90768f43-77db-4e4b-9318-27d9c1b043ba"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RejectCall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""918c764c-e0a5-4948-b0d3-4b76df10c260"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RejectCall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c02e2af7-eb42-48c0-8bb5-83cc458c6ec7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AcceptCall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae75188d-2704-446c-8f9a-6ca00950896a"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AcceptCall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56743e3e-c098-4f2a-8c20-d301aad98acc"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dffc9e59-de9b-4303-ab1b-2762632239e8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4bc1e64-fb15-492b-88e8-a4e25b2e4fcb"",
                    ""path"": ""<Keyboard>/numpad7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DisableFog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40ab8b01-ca8d-4761-b552-f4769c98e027"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchTrack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01e77e3f-2445-4906-bd64-1a2f707cfb76"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchTrack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""637a6c2d-1712-46c7-8723-cdfd10f5e16c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""440aa740-93c9-4aeb-aec4-b37660e211f3"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dee55406-875d-420f-b17e-a6a63469761b"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f166e8f-4e0a-4cd6-adc0-c486a76f38e5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b8973de-b2a1-4a92-be38-980242a5bc33"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31f0d049-f017-4d3c-8d5a-465d2d181994"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_Move = m_Default.FindAction("Move", throwIfNotFound: true);
        m_Default_PullUpPhone = m_Default.FindAction("PullUpPhone", throwIfNotFound: true);
        m_Default_Flash = m_Default.FindAction("Flash", throwIfNotFound: true);
        m_Default_RejectCall = m_Default.FindAction("RejectCall", throwIfNotFound: true);
        m_Default_AcceptCall = m_Default.FindAction("AcceptCall", throwIfNotFound: true);
        m_Default_OpenMainMenu = m_Default.FindAction("OpenMainMenu", throwIfNotFound: true);
        m_Default_DisableFog = m_Default.FindAction("DisableFog", throwIfNotFound: true);
        m_Default_SwitchTrack = m_Default.FindAction("SwitchTrack", throwIfNotFound: true);
        m_Default_TurnAround = m_Default.FindAction("TurnAround", throwIfNotFound: true);
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

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_Move;
    private readonly InputAction m_Default_PullUpPhone;
    private readonly InputAction m_Default_Flash;
    private readonly InputAction m_Default_RejectCall;
    private readonly InputAction m_Default_AcceptCall;
    private readonly InputAction m_Default_OpenMainMenu;
    private readonly InputAction m_Default_DisableFog;
    private readonly InputAction m_Default_SwitchTrack;
    private readonly InputAction m_Default_TurnAround;
    public struct DefaultActions
    {
        private @PlayerControllersInputs m_Wrapper;
        public DefaultActions(@PlayerControllersInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Default_Move;
        public InputAction @PullUpPhone => m_Wrapper.m_Default_PullUpPhone;
        public InputAction @Flash => m_Wrapper.m_Default_Flash;
        public InputAction @RejectCall => m_Wrapper.m_Default_RejectCall;
        public InputAction @AcceptCall => m_Wrapper.m_Default_AcceptCall;
        public InputAction @OpenMainMenu => m_Wrapper.m_Default_OpenMainMenu;
        public InputAction @DisableFog => m_Wrapper.m_Default_DisableFog;
        public InputAction @SwitchTrack => m_Wrapper.m_Default_SwitchTrack;
        public InputAction @TurnAround => m_Wrapper.m_Default_TurnAround;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMove;
                @PullUpPhone.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnPullUpPhone;
                @PullUpPhone.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnPullUpPhone;
                @PullUpPhone.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnPullUpPhone;
                @Flash.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFlash;
                @Flash.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFlash;
                @Flash.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFlash;
                @RejectCall.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRejectCall;
                @RejectCall.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRejectCall;
                @RejectCall.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRejectCall;
                @AcceptCall.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnAcceptCall;
                @AcceptCall.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnAcceptCall;
                @AcceptCall.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnAcceptCall;
                @OpenMainMenu.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnOpenMainMenu;
                @OpenMainMenu.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnOpenMainMenu;
                @OpenMainMenu.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnOpenMainMenu;
                @DisableFog.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnDisableFog;
                @DisableFog.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnDisableFog;
                @DisableFog.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnDisableFog;
                @SwitchTrack.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSwitchTrack;
                @SwitchTrack.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSwitchTrack;
                @SwitchTrack.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSwitchTrack;
                @TurnAround.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTurnAround;
                @TurnAround.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTurnAround;
                @TurnAround.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTurnAround;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @PullUpPhone.started += instance.OnPullUpPhone;
                @PullUpPhone.performed += instance.OnPullUpPhone;
                @PullUpPhone.canceled += instance.OnPullUpPhone;
                @Flash.started += instance.OnFlash;
                @Flash.performed += instance.OnFlash;
                @Flash.canceled += instance.OnFlash;
                @RejectCall.started += instance.OnRejectCall;
                @RejectCall.performed += instance.OnRejectCall;
                @RejectCall.canceled += instance.OnRejectCall;
                @AcceptCall.started += instance.OnAcceptCall;
                @AcceptCall.performed += instance.OnAcceptCall;
                @AcceptCall.canceled += instance.OnAcceptCall;
                @OpenMainMenu.started += instance.OnOpenMainMenu;
                @OpenMainMenu.performed += instance.OnOpenMainMenu;
                @OpenMainMenu.canceled += instance.OnOpenMainMenu;
                @DisableFog.started += instance.OnDisableFog;
                @DisableFog.performed += instance.OnDisableFog;
                @DisableFog.canceled += instance.OnDisableFog;
                @SwitchTrack.started += instance.OnSwitchTrack;
                @SwitchTrack.performed += instance.OnSwitchTrack;
                @SwitchTrack.canceled += instance.OnSwitchTrack;
                @TurnAround.started += instance.OnTurnAround;
                @TurnAround.performed += instance.OnTurnAround;
                @TurnAround.canceled += instance.OnTurnAround;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPullUpPhone(InputAction.CallbackContext context);
        void OnFlash(InputAction.CallbackContext context);
        void OnRejectCall(InputAction.CallbackContext context);
        void OnAcceptCall(InputAction.CallbackContext context);
        void OnOpenMainMenu(InputAction.CallbackContext context);
        void OnDisableFog(InputAction.CallbackContext context);
        void OnSwitchTrack(InputAction.CallbackContext context);
        void OnTurnAround(InputAction.CallbackContext context);
    }
}
