using ABoardGame.Scripts.Core.Interfaces;
using ABoardGame.Scripts.Core.PlayerScripts.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ABoardGame.Scripts.Core.PlayerScripts.Input
{
    public class CharacterInputHandler : MonoBehaviour
    {

        public Command horizontal;
        public Command vertical;

        
        
        private PlayerInputActions playerInputAction;

        private float horizontalMovement;
        private float verticalMovement;


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
            verticalMovement = context.ReadValue<float>();
            IsPressingHorizontalMovement = verticalMovement >= 0.15f;
            if (horizontal != null && IsPressingHorizontalMovement)
                horizontal.Execute();
                    
        }

        private void OnVerticalMoveInput(InputAction.CallbackContext context)
        {
            horizontalMovement = context.ReadValue<float>();
            IsPressingVerticalMovement = horizontalMovement >= 0.15f;
            if (vertical != null && IsPressingVerticalMovement)
                vertical.Execute();
        }

        private void OnDisable()
        {
            playerInputAction.Disable();

            playerInputAction.Player.HorizontalMovement.performed += OnHorizontalMoveInput;

            playerInputAction.Player.VerticalMovement.performed -= OnVerticalMoveInput;
        }

        
    }
}