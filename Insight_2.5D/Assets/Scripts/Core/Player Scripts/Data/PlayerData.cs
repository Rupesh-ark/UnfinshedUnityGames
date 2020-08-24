﻿using UnityEngine;

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
        [Range(0.01f, 0.8f)]
        public float rayCastDistance = 0.1f;
        public LayerMask whatIsGround;

        [Header("Running State")]
        public float movementVelocity = 10f;

        [Header("Jump State")]
        public float jumpVelocity = 8f;
        public int amountOfJumps = 1;

        [Header("In Air State")]
        public float coyoteTime = 0.2f;

    }
}