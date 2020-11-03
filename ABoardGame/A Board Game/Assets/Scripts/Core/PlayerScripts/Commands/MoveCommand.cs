using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts.Commands
{
    public class MoveCommand : MonoBehaviour
    {
        protected PlayerCheckScript playerCheck;

        protected float moveUnits = 5f;
        protected float moveDirection;
        public bool CanMove { get; set; }
        public virtual void Awake()
        {
            playerCheck = GetComponent<PlayerCheckScript>();
        }
        public virtual void MoveOnBoard(float direction)
        {
        }
        
    }
}