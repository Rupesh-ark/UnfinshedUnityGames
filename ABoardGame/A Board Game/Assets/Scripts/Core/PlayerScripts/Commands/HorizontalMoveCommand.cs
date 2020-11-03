using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts.Commands
{
    public class HorizontalMoveCommand : MoveCommand
    {
        public override void Awake()
        {
            base.Awake();
        }

        public void Execute(float value)
        {
            Debug.Log("Hori Execute");
            MoveOnBoard(value);
        }

        public override void MoveOnBoard(float direction)
        {
            EvaluateHorizontalDirection(direction);

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (moveUnits * moveDirection));
        }

        public void EvaluateHorizontalDirection(float direction)
        {
            moveDirection = direction;
            if (playerCheck.boundaryTriggerFront && !playerCheck.boundaryTriggerBack)
            {
                if (direction < 0)
                {
                    moveDirection = 0;
                    CanMove = false;
                }
            }
            else if (playerCheck.boundaryTriggerBack && !playerCheck.boundaryTriggerFront)
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