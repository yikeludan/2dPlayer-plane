// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/MoveAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MoveActionSys : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MoveActionSys()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MoveAction"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""08de0941-d0f7-4ed3-aaab-8bd07a41841d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8a87e383-5819-4958-92e8-7e516324b527"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""File"",
                    ""type"": ""Button"",
                    ""id"": ""8a218a77-6fc2-43c0-81b3-4d33f2992000"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Doge"",
                    ""type"": ""Button"",
                    ""id"": ""4f616ee1-3c4c-4bb2-a21b-17a2940153b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Over"",
                    ""type"": ""Button"",
                    ""id"": ""f67ed4c7-ac25-4fca-a7c5-15d7841b5b04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""176c352d-d664-4f97-8760-1bde07e183eb"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""968325fe-53df-491f-bfb1-007573f2f468"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""82e6b67d-9582-49d7-88bb-6421ca7ccaab"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bc32cfcf-5b1f-4133-aca4-bf577a2aed21"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""404272d6-f174-4c73-94c8-95bb0944d00b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6deb37d6-b760-43af-81b2-1515fbfc4ced"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5a7fc536-4a61-408a-8450-4c86ea3abdea"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7c6194a1-2dee-4964-a6c7-a1539567f210"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""File"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7acb03fd-0668-428e-b63e-231e16182de5"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""File"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc05dbfc-d0f8-425f-9e35-d726eb1ae131"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Doge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10ff1e13-4e44-47d6-90d3-65cd88b0c1e9"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Over"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
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
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Move = m_GamePlay.FindAction("Move", throwIfNotFound: true);
        m_GamePlay_File = m_GamePlay.FindAction("File", throwIfNotFound: true);
        m_GamePlay_Doge = m_GamePlay.FindAction("Doge", throwIfNotFound: true);
        m_GamePlay_Over = m_GamePlay.FindAction("Over", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Move;
    private readonly InputAction m_GamePlay_File;
    private readonly InputAction m_GamePlay_Doge;
    private readonly InputAction m_GamePlay_Over;
    public struct GamePlayActions
    {
        private @MoveActionSys m_Wrapper;
        public GamePlayActions(@MoveActionSys wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GamePlay_Move;
        public InputAction @File => m_Wrapper.m_GamePlay_File;
        public InputAction @Doge => m_Wrapper.m_GamePlay_Doge;
        public InputAction @Over => m_Wrapper.m_GamePlay_Over;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @File.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFile;
                @File.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFile;
                @File.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFile;
                @Doge.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDoge;
                @Doge.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDoge;
                @Doge.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDoge;
                @Over.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOver;
                @Over.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOver;
                @Over.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOver;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @File.started += instance.OnFile;
                @File.performed += instance.OnFile;
                @File.canceled += instance.OnFile;
                @Doge.started += instance.OnDoge;
                @Doge.performed += instance.OnDoge;
                @Doge.canceled += instance.OnDoge;
                @Over.started += instance.OnOver;
                @Over.performed += instance.OnOver;
                @Over.canceled += instance.OnOver;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface IGamePlayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFile(InputAction.CallbackContext context);
        void OnDoge(InputAction.CallbackContext context);
        void OnOver(InputAction.CallbackContext context);
    }
}
