using UnityEngine;

namespace Insight.Script.Core.MovementInterface
{
    public interface IMoveInput
    {
        Vector3 MoveDirection { get; }
    }
}