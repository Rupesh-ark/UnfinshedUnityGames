using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts.Commands
{
    public class FlipCommand : MonoBehaviour
    {
        public bool ShouldFlip { get; private set; }

        private void Update()
        {
            
        }

        private void Execute(float value)
        {
            transform.Rotate(0f, transform.rotation.y - 90f, 0f);
        }
    }
}