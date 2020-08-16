using UnityEngine;

namespace Insight.Script.Core.Player.PlayerFiniteStateMachine
{
    public class PlayerStateMachine : MonoBehaviour
    {
        public PlayerState CurrentState { get; private set; }

        public void Initialize(PlayerState startingState)
        {
            CurrentState = startingState;

            CurrentState.Enter();
        }

        private void ChangeState(PlayerState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}