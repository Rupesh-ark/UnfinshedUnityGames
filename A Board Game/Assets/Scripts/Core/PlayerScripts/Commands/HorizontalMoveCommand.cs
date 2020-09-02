using ABoardGame.Scripts.Core.Interfaces;
using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts.Commands
{
    public class HorizontalMoveCommand : Command
    {
        float moveUnits = 1f;
        private Rigidbody rb;
        private bool shouldMove;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        public override void Execute()
        {
            MoveOnBoard();
        }

        private void MoveOnBoard()
        {
            rb.transform.position = new Vector3(rb.transform.position.x + moveUnits, rb.transform.position.y, rb.transform.position.z);


        }
    }
}