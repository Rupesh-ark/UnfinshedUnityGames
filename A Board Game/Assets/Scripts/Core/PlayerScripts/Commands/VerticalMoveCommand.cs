using ABoardGame.Scripts.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts.Commands
{
    public class VerticalMoveCommand : Command
    {
        private Rigidbody rb;
        private bool shouldMove;
        float moveUnits = 1f;

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
            rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z + moveUnits);

        }




    }
}