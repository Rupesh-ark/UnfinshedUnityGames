using UnityEngine;

namespace Insight.Script.Core.PlayerScripts
{
    public class PlayerInAirState : PlayerState
    {
        private int xInput;

        private bool isGrounded;

        private bool jumpInput;

        private bool coyoteTime;

        private bool isJumping;

        private bool jumpInputStop;

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

            CopyInputParameters();

            CheckJumpMultiplier();

            HandlingMovementInAirState();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        private void CheckCoyoteTime()
        {
            if (coyoteTime && Time.time > startTime + playerData.coyoteTime)
            {
                coyoteTime = false;
                player.JumpState.DecreaseAmountOfJumpsLeft();
            }
        }

        private void CopyInputParameters()
        {
            xInput = player.InputHandler.NomInputX;

            jumpInput = player.InputHandler.IsPressingJump;

            jumpInputStop = player.InputHandler.JumpInputStop;
        }

        private void CheckJumpMultiplier()
        {
            if (isJumping)
            {
                if (jumpInputStop)
                {
                    player.SetVelocityY(playerData.jumpVelocity * playerData.variableJumpHeightMultiplier);
                    isJumping = false;
                }
                else if (player.CurrentVelocity.y <= 0f)
                {
                    isJumping = false;
                }
            }
        }

        private void HandlingMovementInAirState()
        {
            if (isGrounded && player.CurrentVelocity.y < 0.1f)
            {
                stateMachine.ChangeState(player.LandState);
            }
            else if (jumpInput && player.JumpState.CanJump())
            {
                player.InputHandler.UseJumpInput();
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

        public void StartCoyoteTime() => coyoteTime = true;

        public void SetIsJumping() => isJumping = true;
    }
}