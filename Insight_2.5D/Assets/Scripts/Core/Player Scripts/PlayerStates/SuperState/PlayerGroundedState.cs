using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Insight.Script.Core.PlayerScripts
{
    public class PlayerGroundedState : PlayerState
    {
        protected int xinput;

        public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {




        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            xinput = player.InputHandler.NomInputX;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
