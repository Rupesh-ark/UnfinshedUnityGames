using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Insight.Script.Core.PlayerScripts
{
    public class AnimationEvent : MonoBehaviour
    {
        Player player;

        // Start is called before the first frame update
        void Awake()
        {
            player = GetComponentInParent<Player>();
        }

        public void AnimationFinishTrigger() => player.AnimationFinishTrigger();


    }

}
