using Insight.Script.Core.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Insight.Script.Core.PlayerScripts
{
    public class CharacterInputHandler : MonoBehaviour
    {
      

        private PlayerInput _inputActions;

        public bool IsPressingInteract { get; private set; }

        public bool IsPressingJump { get; private set; }
        
        public Vector2 RawMovementInput { get; private set; }
        
        public int NomInputX { get; private set; }

        public int NomInputY { get; private set; }
        
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

            _inputActions.PlayerMovement.Jump.performed += OnJumpInput;
        }

       
        public void OnMoveInput(InputAction.CallbackContext context)
        {
            RawMovementInput = context.ReadValue<Vector2>();

            NomInputX = (int)(RawMovementInput * Vector2.right).normalized.x;

            NomInputY = (int)(RawMovementInput* Vector2.up).normalized.y;
            
        }

        public void OnInteractButton(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            IsPressingInteract = value >= 0.15f;
        }
       
        public void OnJumpInput(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            IsPressingJump = value >= 0.15f;

            Debug.Log("Jump");
           

        }

        public void UseJumpInput() => IsPressingJump = false;

        private void OnDisable()
        {
            _inputActions.Disable();

            _inputActions.PlayerMovement.Interact.performed -= OnInteractButton;

            _inputActions.PlayerMovement.Jump.performed -= OnJumpInput;
        }

     
    }
}