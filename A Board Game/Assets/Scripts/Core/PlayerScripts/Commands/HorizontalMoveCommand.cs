using ABoardGame.Scripts.Core.Interfaces;
using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts.Commands
{
    public class HorizontalMoveCommand : Command
    {
        float moveUnits = 5f;
       
        private bool shouldMove;

        private void Awake()
        {
            
        }
        public override void Execute(float value)
        {
            MoveOnBoard(value);
        }

        private void MoveOnBoard(float direction)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z + (moveUnits * direction));


        }
    }
}