using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts.Data
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
    public class PlayerData : ScriptableObject
    {
        
        
        public float rayCastDistance = 2f;

        public LayerMask normalBlock,
                         addBlock,
                         substractBlock,
                         divideBlock,
                         flipBlock;



    }
}