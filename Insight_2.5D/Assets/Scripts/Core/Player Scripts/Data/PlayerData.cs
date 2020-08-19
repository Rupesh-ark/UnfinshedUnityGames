using UnityEngine;

namespace Insight.Script.Core.PlayerScripts
{
    [CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/Base Data")]

    public class PlayerData : ScriptableObject
    {
        [Header("Ground Detection")]
        
        [Range(0.1f,0.5f)]
        public float detectionWidth = 0.2f;
        [Range(4, 8)]
        public int numberOfSphere = 5;
        [Range(0.1f, 0.5f)]
        public float distanceBetweenSphere = 0.1f;
        [Range(0.1f, 0.8f)]
        public float rayCastDistance = 0.2f;
        public LayerMask whatIsGround;

        [Header("Running State")]
        public float movementVelocity = 10f;

        [Header("Jump State")]
        public float jumpVelocity = 8f;

    }
}