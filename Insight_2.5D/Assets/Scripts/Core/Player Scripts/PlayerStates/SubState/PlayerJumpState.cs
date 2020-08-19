using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Insight.Script.Core.PlayerScripts
{
    public class PlayerJumpState : PlayerAbilityState
    {
        public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.AddJumpForce(playerData.jumpVelocity);
            isAbilityDone = true;
        }
    }
}