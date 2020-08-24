﻿using UnityEngine;

namespace Insight.Script.Core.PlayerScripts
{
    public class PlayerState
    {
        protected Player player;
        protected PlayerStateMachine stateMachine;
        protected PlayerData playerData;

        protected float startTime;

        protected bool isAnimationFinished;

        private string animBoolName;

        public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.playerData = playerData;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            DoChecks();
            player.Anim.SetBool(animBoolName, true);
            startTime = Time.time;
            isAnimationFinished = false;
        }

        public virtual void Exit()
        {
            player.Anim.SetBool(animBoolName, false);
        }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks() { }


        public virtual void AnimationTrigger() { }

        public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

    }
}