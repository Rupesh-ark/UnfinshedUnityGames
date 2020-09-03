using UnityEngine;
using ABoardGame.Scripts.Core.PlayerScripts.Data;
namespace ABoardGame.Scripts.Core.PlayerScripts.Commands
{
    public abstract class Command : MonoBehaviour
    {
        public virtual void Execute(float value)
        {
        }
    }
}