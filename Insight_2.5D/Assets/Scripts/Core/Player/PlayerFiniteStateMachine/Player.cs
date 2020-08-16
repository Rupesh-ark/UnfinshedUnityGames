using UnityEngine;

namespace Insight.Script.Core.Player.PlayerFiniteStateMachine
{
    public class Player : MonoBehaviour
    {
        public PlayerStateMachine StateMachine { get; private set; }

        private void Awake()
        {
            StateMachine = new PlayerStateMachine();
        }

        private void Start()
        {
            //TODO: Initailize state machine
        }

        private void Update()
        {
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
    }
}