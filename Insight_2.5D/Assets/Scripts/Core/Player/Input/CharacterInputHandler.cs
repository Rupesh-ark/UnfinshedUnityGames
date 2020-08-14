using Insight.Core.Commands;
using Insight.Script.Core.MovementInterface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Insight.Script.Core.Player.Input
{
    public class CharacterInputHandler : MonoBehaviour,IInteractInput,IMoveInput
    {
         
        public Command movementInput;
        public Command interactInput;

       
        private PlayerInput _inputActions;



        public bool IsPressingInteract { get; private set; }

        public Vector3 MoveDirection { get; private set; }
        

        private void Awake()
        {
            _inputActions = new PlayerInput();
        }

        private void OnEnable()
        {
            _inputActions.Enable();

         
            _inputActions.Movement.Movement.performed += OnMoveInput; 

            _inputActions.Movement.Interact.performed += OnInteractButton;



        }

       private void update()
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

            _inputActions.Movement.Interact.performed -= OnInteractButton;
        }

    }
}