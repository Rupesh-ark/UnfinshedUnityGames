using UnityEngine;
using UnityEngine.InputSystem;

namespace ABoardGame.Scripts.Core.PlayerScripts.Input
{
    public class CharacterInputHandler : MonoBehaviour
    {
        private PlayerInputActions playerInputAction;

        public float horizontalMovement { get; private set; }

        public float verticalMovement { get; private set; }

        public bool IsPressingHorizontalMovement { get; private set; }
        public bool IsPressingVerticalMovement { get; private set; }

        private void Awake()
        {
            playerInputAction = new PlayerInputActions();
        }

        private void OnEnable()
        {
            playerInputAction.Enable();

            playerInputAction.Player.HorizontalMovement.performed += OnHorizontalMoveInput;

            playerInputAction.Player.VerticalMovement.performed += OnVerticalMoveInput;
        }

        private void OnHorizontalMoveInput(InputAction.CallbackContext context)
        {
            horizontalMovement = context.ReadValue<float>();
            IsPressingHorizontalMovement = horizontalMovement != 0;
        }

        private void OnVerticalMoveInput(InputAction.CallbackContext context)
        {
            verticalMovement = context.ReadValue<float>();
            IsPressingVerticalMovement = verticalMovement != 0;
        }

        public void UseHorrizontalInput() => IsPressingHorizontalMovement = false;

        public void UseVerticalInput() => IsPressingVerticalMovement = false;

        private void OnDisable()
        {
            playerInputAction.Disable();

            playerInputAction.Player.HorizontalMovement.performed -= OnHorizontalMoveInput;

            playerInputAction.Player.VerticalMovement.performed -= OnVerticalMoveInput;
        }
    }
}