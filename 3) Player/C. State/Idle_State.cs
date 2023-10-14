using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Idle_State : MonoBehaviour, IState
    {
        private Player_Behaviour player_behaviour;

        public void Handle(Transform controller)
        {
            if (!player_behaviour)
            {
                player_behaviour = controller.GetComponent<Player_Behaviour>();
            }

            player_behaviour.animation_behaviour.Change_Animation("Idle");
        }
    }
}