using ABoardGame.Scripts.Core.PlayerScripts.Commands;
using ABoardGame.Scripts.Core.PlayerScripts.Input;
using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        CommandProcessor processor;

        

        private void Awake()
        {
            processor = GetComponent<CommandProcessor>();
        }

        private void Start()
        {
        }

        private void Update()
        {
            processor.Execute();
        }

        
    }
}