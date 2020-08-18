using UnityEngine;

namespace Insight.Script.Core.PlayerScripts
{
    [CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/Base Data")]

    public class PlayerData : ScriptableObject
    {

        [Header("Running State")]
        public float movementVelocity = 10f;

    }
}