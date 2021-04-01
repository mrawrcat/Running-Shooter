// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""NewInput"",
            ""id"": ""b550fc12-1705-4bba-aa03-90f7e2cfcaa6"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2dbc1b9d-053d-4d05-bd14-321436ed4252"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""e995df25-23c3-471e-9fa6-dca337494673"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ad62e189-0d35-45e7-bd28-55977e0ad78e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6f326e7-dc0b-4bd9-9829-e05c0d73c0d8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fire"",
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
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // NewInput
        m_NewInput = asset.FindActionMap("NewInput", throwIfNotFound: true);
        m_NewInput_Jump = m_NewInput.FindAction("Jump", throwIfNotFound: true);
        m_NewInput_Fire = m_NewInput.FindAction("Fire", throwIfNotFound: true);
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

    // NewInput
    private readonly InputActionMap m_NewInput;
    private INewInputActions m_NewInputActionsCallbackInterface;
    private readonly InputAction m_NewInput_Jump;
    private readonly InputAction m_NewInput_Fire;
    public struct NewInputActions
    {
        private @PlayerInput m_Wrapper;
        public NewInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_NewInput_Jump;
        public InputAction @Fire => m_Wrapper.m_NewInput_Fire;
        public InputActionMap Get() { return m_Wrapper.m_NewInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewInputActions set) { return set.Get(); }
        public void SetCallbacks(INewInputActions instance)
        {
            if (m_Wrapper.m_NewInputActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_NewInputActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_NewInputActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_NewInputActionsCallbackInterface.OnJump;
                @Fire.started -= m_Wrapper.m_NewInputActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_NewInputActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_NewInputActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_NewInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public NewInputActions @NewInput => new NewInputActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface INewInputActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
}
