using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts.Commands
{
    public class Flip : Command
    {

        public override void Execute(float value)
        {
            transform.Rotate(0f, 90f, 0f);
        }



    }
}