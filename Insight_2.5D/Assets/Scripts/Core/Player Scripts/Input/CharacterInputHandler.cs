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

        [SerializeField]
        private float inputHoldTime = 0.2f;

        private float jumpInputStartTime; 

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

        private void Update()
        {
            CheckJumpInputHoldTime();

        }

        private void CheckJumpInputHoldTime()
        {
            if(Time.time >= jumpInputStartTime + inputHoldTime)
            {
                IsPressingJump = false;
            }
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
            if(value >= 0.15f)
            {
                IsPressingJump = true;
                jumpInputStartTime = Time.time;

            }
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