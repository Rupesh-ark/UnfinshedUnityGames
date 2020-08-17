using UnityEngine;

namespace Insight.Script.Core.PlayerScripts
{
    public class PlayerState
    {
        protected Player player;
        protected PlayerStateMachine stateMachine;
        protected PlayerData playerDate;

        protected float startTime;

        private string animBoolName;

        public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.playerDate = playerData;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            DoChecks();
            player.Anim.SetBool(animBoolName, true);
            startTime = Time.time;
        }

        public virtual void Exit()
        {
            player.Anim.SetBool(animBoolName, true);
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {
        }
    }
}