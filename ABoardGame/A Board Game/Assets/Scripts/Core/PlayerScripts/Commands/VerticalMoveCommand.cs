using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts.Commands
{
    public class VerticalMoveCommand : MoveCommand
    {
        
        public override void Awake()
        {
            base.Awake();
        }

        public void Execute(float value)
        {
            Debug.Log("VerticalExecute");
            MoveOnBoard(value);
        }

        public override void MoveOnBoard(float direction)
        {
            EvaluateVerticalDirection(direction);

            transform.position = new Vector3(transform.position.x - (moveUnits * moveDirection), transform.position.y, transform.position.z);

        }

        public void EvaluateVerticalDirection(float direction)
        {
            moveDirection = direction;
            if (playerCheck.boundaryTriggerRight && !playerCheck.boundaryTriggerLeft)
            {
                if (direction < 0)
                {
                    moveDirection = 0;
                    CanMove = false;
                }

            }
            else if (playerCheck.boundaryTriggerLeft && !playerCheck.boundaryTriggerRight)
            {
                if (direction > 0)
                {
                    moveDirection = 0;
                    CanMove = false;
                }
            }
            else
                CanMove = true;
        }

    }
}