using ABoardGame.Scripts.Core.PlayerScripts.Input;
using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts.Commands
{
    public class CommandProcessor : MonoBehaviour
    {
        private VerticalMoveCommand vertical;
        private HorizontalMoveCommand horizontal; 
        private FlipCommand  flip;

        [SerializeField]
        private CharacterInputHandler characterInputHandler;

        protected PlayerCheckScript playerCheck;

        public void Awake()
        {
            characterInputHandler = GetComponent<CharacterInputHandler>();
            playerCheck = GetComponent<PlayerCheckScript>();
            horizontal = GetComponent<HorizontalMoveCommand>();
            vertical = GetComponent<VerticalMoveCommand>();
            flip = GetComponent<FlipCommand>();
        }

        public void Execute()
        {
            if (characterInputHandler.IsPressingHorizontalMovement)
            {
                
                if (!horizontal.CanMove)
                {
                    vertical.Execute(characterInputHandler.horizontalMovement);
                    horizontal.CanMove = true;
                }
                else
                {
                    horizontal.Execute(characterInputHandler.horizontalMovement);
                }

                characterInputHandler.UseHorrizontalInput();
            }

            if (characterInputHandler.IsPressingVerticalMovement)
            {
                 
                if (!vertical.CanMove)
                {
                    horizontal.Execute(-characterInputHandler.verticalMovement);
                    vertical.CanMove = true;
                }
                else
                {
                    vertical.Execute(characterInputHandler.verticalMovement);
                }

                characterInputHandler.UseVerticalInput();
            }
        }

      
    }
}