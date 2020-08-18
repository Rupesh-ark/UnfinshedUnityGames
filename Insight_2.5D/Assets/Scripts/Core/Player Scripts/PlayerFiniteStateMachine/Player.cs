using Insight.Script.Core.Interfaces;
using UnityEngine;

namespace Insight.Script.Core.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        public PlayerStateMachine StateMachine { get; private set; }

        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }

        [SerializeField]
        private PlayerData playerData;

        public Animator Anim { get; private set; }

        public CharacterInputHandler InputHandler { get; private set; }

        public Rigidbody RB { get; private set; }

        public Vector3 Workspace { get; private set; }
        public Vector3 CurrentVelocity { get; private set; }

        public int FacingDirection { get; private set; }


        private void Awake()
        {
            StateMachine = new PlayerStateMachine();

            IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");

            MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");

        }

        private void Start()
        {
            Anim = GetComponentInChildren<Animator>();

            InputHandler = GetComponent<CharacterInputHandler>();

            RB = GetComponent<Rigidbody>();

            StateMachine.Initialize(IdleState);

            FacingDirection = 1;
        }

        private void Update()
        {
            CurrentVelocity = RB.velocity;
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }

        public void SetVelocityx(float velocity)
        {
            Debug.Log("velocity:" + velocity);
            Workspace = new Vector3(velocity, CurrentVelocity.y, CurrentVelocity.z);
            Debug.Log("WorkSpace:" + Workspace);
            RB.velocity = Workspace;
            Debug.Log("RB:" + RB.velocity);
            CurrentVelocity = Workspace;
        }

        public void CheckIfShouldFlip(int xinput)
        {
            if(xinput != 0 && xinput != FacingDirection)
            {
                Flip();
            }
        }

        private void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}