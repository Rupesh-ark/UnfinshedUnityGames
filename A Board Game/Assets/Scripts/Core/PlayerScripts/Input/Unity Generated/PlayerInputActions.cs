// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Core/PlayerScripts/Input/Unity Generated/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace ABoardGame.Scripts.Core.PlayerScripts.Input
{
    public class @PlayerInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""1804ec62-5ee5-4179-9934-3ad04e03e4dc"",
            ""actions"": [
                {
                    ""name"": ""HorizontalMovement"",
                    ""type"": ""Button"",
                    ""id"": ""07949f86-f179-4c04-9bae-837922e95af7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""VerticalMovement"",
                    ""type"": ""Button"",
                    ""id"": ""311987cf-2c8f-4b0e-ac37-573f78a6d74c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d5061b25-fae9-4914-af9e-cb5a9ccb250f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63f8917e-22ec-4faf-b609-ebb19260c4e5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_HorizontalMovement = m_Player.FindAction("HorizontalMovement", throwIfNotFound: true);
            m_Player_VerticalMovement = m_Player.FindAction("VerticalMovement", throwIfNotFound: true);
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

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_HorizontalMovement;
        private readonly InputAction m_Player_VerticalMovement;
        public struct PlayerActions
        {
            private @PlayerInputActions m_Wrapper;
            public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @HorizontalMovement => m_Wrapper.m_Player_HorizontalMovement;
            public InputAction @VerticalMovement => m_Wrapper.m_Player_VerticalMovement;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @HorizontalMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalMovement;
                    @HorizontalMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalMovement;
                    @HorizontalMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalMovement;
                    @VerticalMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalMovement;
                    @VerticalMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalMovement;
                    @VerticalMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalMovement;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @HorizontalMovement.started += instance.OnHorizontalMovement;
                    @HorizontalMovement.performed += instance.OnHorizontalMovement;
                    @HorizontalMovement.canceled += instance.OnHorizontalMovement;
                    @VerticalMovement.started += instance.OnVerticalMovement;
                    @VerticalMovement.performed += instance.OnVerticalMovement;
                    @VerticalMovement.canceled += instance.OnVerticalMovement;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnHorizontalMovement(InputAction.CallbackContext context);
            void OnVerticalMovement(InputAction.CallbackContext context);
        }
    }
}
