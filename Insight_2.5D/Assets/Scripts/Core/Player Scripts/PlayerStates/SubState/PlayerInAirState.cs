﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Insight.Script.Core.PlayerScripts
{
    public class PlayerInAirState : PlayerState
    {

        private int xInput;

        private bool isGrounded;

        private bool jumpInput;

        private bool coyoteTime;

        public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {

        }

        public override void DoChecks()
        {
            base.DoChecks();

            isGrounded = player.CheckIfGrounded();

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

            CheckCoyoteTime();

            xInput = player.InputHandler.NomInputX;

            jumpInput = player.InputHandler.IsPressingJump;

            if(isGrounded && player.CurrentVelocity.y < 0.1f)
            {
                stateMachine.ChangeState(player.LandState);
            }
            else if(jumpInput && player.JumpState.CanJump())
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else
            {
                player.CheckIfShouldFlip(xInput);
                player.SetVelocityX(playerData.movementVelocity * xInput);

                player.Anim.SetFloat("velocityY", player.CurrentVelocity.y);
                player.Anim.SetFloat("velocityX", Mathf.Abs(player.CurrentVelocity.x));
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        private void CheckCoyoteTime()
        {
            if(coyoteTime && Time.time > startTime + playerData.coyoteTime)
            {
                coyoteTime = false;
                player.JumpState.DecreaseAmountOfJumpsLeft();
            }
        }

        public void StartCoyoteTime() => coyoteTime = true;
    }
}