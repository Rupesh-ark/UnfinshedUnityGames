using Insight.Script.Core.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Insight.Script.Core.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        #region State Variables
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }

        [SerializeField]
        private PlayerData playerData;
        #endregion

        #region Components
        public Animator Anim { get; private set; }

        public CharacterInputHandler InputHandler { get; private set; }

        public Rigidbody RB { get; private set; }

        public CapsuleCollider capsule { get; private set; }

        [SerializeField]
        private GameObject groundDetection;
        #endregion

        #region Additional Variables
        public Vector3 Workspace { get; private set; }
        public Vector3 CurrentVelocity { get; private set; }

        public int FacingDirection { get; private set; }

        private List<GameObject> _bottomSpheres = new List<GameObject>();
        #endregion

        #region Unity Callback Function
        private void Awake()
        {
            capsule = GetComponent<CapsuleCollider>();

            StateMachine = new PlayerStateMachine();

            IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");

            MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");

            JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");

            InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");

            LandState = new PlayerLandState(this, StateMachine, playerData, "land");

            SummonGroundDetectionSphere();

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
        #endregion

        #region Set Function

        public void SetVelocityX(float velocity)
        {
            
            Workspace = new Vector3(velocity, CurrentVelocity.y, CurrentVelocity.z);

            RB.velocity = Workspace;
            
            CurrentVelocity = Workspace;
        }

        public void AddJumpForce(float jumpVelocity)
        {
            Workspace = new Vector3(CurrentVelocity.x, jumpVelocity, CurrentVelocity.z);
            RB.velocity = Workspace;
            CurrentVelocity = Workspace;
        }

        #endregion


        #region Check Function
        public void CheckIfShouldFlip(int xinput)
        {
            if(xinput != 0 && xinput != FacingDirection)
            {
                Flip();
            }
        }

        public bool CheckIfGrounded()
        {

            foreach(GameObject rayCastOrigin in _bottomSpheres)
            {
                Debug.DrawRay(rayCastOrigin.transform.position, Vector3.down * playerData.rayCastDistance,Color.black);
                
                RaycastHit hit;

                if (Physics.Raycast(rayCastOrigin.transform.position, Vector3.down, out hit, playerData.rayCastDistance, playerData.whatIsGround))
                {
                    return true;
                }
                
            }

            return false;
        }

        #endregion

        #region Additional Functions

        private void AnimationTriggerFunction() => StateMachine.CurrentState.AnimationTrigger();

        public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

        


        private void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0f, 180f, 0f);
        }

        public GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(groundDetection, pos, Quaternion.identity);
            return obj;
        }

        private void SummonGroundDetectionSphere()
        {
            GameObject bottom = CreateEdgeSphere(new Vector3(transform.position.x - playerData.detectionWidth, transform.position.y, transform.position.z));

            bottom.transform.parent = this.transform;

            _bottomSpheres.Add(bottom);

            for (int i = 0; i < playerData.numberOfSphere; i++)
            {
                Vector3 pos = new Vector3(bottom.transform.position.x + (float)((i + 1) * playerData.distanceBetweenSphere), bottom.transform.position.y, bottom.transform.position.z);

                GameObject newObj = CreateEdgeSphere(pos);

                newObj.transform.parent = this.transform;

                _bottomSpheres.Add(newObj);
            }
        }


        #endregion

    }

}