using ABoardGame.Scripts.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts.Commands
{
    public class VerticalMoveCommand : Command
    {
        float moveUnits = 5f;

        private void Awake()
        {
            
        }
        public override void Execute(float value)
        {
            MoveOnBoard(value);
        }

        private void MoveOnBoard(float direction)
        {
            transform.position = new Vector3(transform.position.x - (moveUnits * direction), transform.position.y, transform.position.z );

        }




    }
}