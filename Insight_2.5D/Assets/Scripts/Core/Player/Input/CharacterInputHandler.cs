using Insight.Script.Core.MovementInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Insight.Script.Core.Player.Input
{
    public class CharacterInputHandler : MonoBehaviour,IInteractInput
    {
        private PlayerInput _inputAction;

        public bool IsPressingInteract { get; private set; }

        private void Awake()
        {
            _inputAction = new PlayerInput();
        }

        private void OnEnable()
        {
            _inputAction.Movement.Interact.performed += OnInteractButton;
        }

        private void OnInteractButton(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            IsPressingInteract = value >= 0.15f;
        }

        private void OnDisable()
        {
            _inputAction.Movement.Interact.performed -= OnInteractButton;
        }

    }
}