using Insight.Script.Core.Interfaces;
using Insight.Script.Core.Player.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Insight.Script.Core.Player.Input
{
    public class CharacterInputHandler : MonoBehaviour, IInteractInput, IMoveInput, IRotationInput
    {
        public Command movementInput;
        public Command interactInput;

        private PlayerInput _inputActions;

        public bool IsPressingInteract { get; private set; }

        public Vector3 MoveDirection { get; private set; }
        public Vector3 RotationDirection { get; set; }

        private void Awake()
        {
            _inputActions = new PlayerInput();
        }

        private void OnEnable()
        {
            _inputActions.Enable();

            _inputActions.PlayerMovement.Movement.performed += OnMoveInput;

            _inputActions.PlayerMovement.Interact.performed += OnInteractButton;
        }

        private void Update()
        {
            movementInput.Execute();
        }

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            Debug.Log("how many times");
            var value = context.ReadValue<Vector2>();
            MoveDirection = new Vector3(value.x, 0, 0);

            //movementInput.Execute();
        }

        public void OnInteractButton(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            IsPressingInteract = value >= 0.15f;
        }

        private void OnDisable()
        {
            _inputActions.Disable();

            _inputActions.PlayerMovement.Interact.performed -= OnInteractButton;
        }
    }
}