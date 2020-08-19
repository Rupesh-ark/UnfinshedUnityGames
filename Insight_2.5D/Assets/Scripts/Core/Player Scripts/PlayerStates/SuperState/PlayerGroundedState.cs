﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Insight.Script.Core.PlayerScripts
{
    public class PlayerGroundedState : PlayerState
    {
        protected int xinput;
        private bool jumpInput;

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

            jumpInput = player.InputHandler.IsPressingJump;

            if(jumpInput)
            {
                player.InputHandler.UseJumpInput();
                stateMachine.ChangeState(player.JumpState);
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
