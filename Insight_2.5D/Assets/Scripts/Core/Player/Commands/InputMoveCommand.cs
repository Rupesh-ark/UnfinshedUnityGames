using Insight.Script.Core.Interfaces;
using UnityEngine;

namespace Insight.Script.Core.Player.Commands
{
    public class InputMoveCommand : Command
    {
        //public AnimationCurve speed;
        public float speed = 2f;

        private Rigidbody _rb;
        private IMoveInput _move;
        private Transform _transform;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _move = GetComponent<IMoveInput>();
            _transform = transform;
        }

        public override void Execute()
        {
            Move();
        }

        public void Move()
        {
            _rb.velocity = new Vector3(speed * _move.MoveDirection.x, _rb.velocity.y, 0);
        }
    }
}