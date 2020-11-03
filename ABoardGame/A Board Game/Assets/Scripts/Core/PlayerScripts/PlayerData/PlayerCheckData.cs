using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts.Data
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Check Data")]
    public class PlayerCheckData : ScriptableObject
    {
        public float rayCastDistance = 2f,
                     empty = 1f;

        public LayerMask normalBlock,
                         addBlock,
                         substractBlock,
                         divideBlock,
                         flipBlock,
                         boundary;

        public GameObject detectionSphere;
        public float OfsetFromCenter = 0.6f;
        public float OfsetFromCenterY = 0.1f;
    }
}