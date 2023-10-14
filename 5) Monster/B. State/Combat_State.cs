using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    public class Combat_State : MonoBehaviour, IState
    {
        private Monster_Behaviour monster_behaviour;

        public void Handle(Transform controller)
        {
            if (!monster_behaviour)
            {
                monster_behaviour = controller.GetComponent<Monster_Behaviour>();
            }

            Event_Bus.Publish(Event_Type.Start_Combat);
            monster_behaviour.animation_behaviour.Change_Animation("Idle");
        }

        public void Hit(double damage)
        {
            if (monster_behaviour.current_health <= 0)
            {
                return;
            }

            monster_behaviour.current_health -= damage;
            if (monster_behaviour.current_health < 0)
            {
                monster_behaviour.current_health = 0;
            }

            Monster_Health_Bar.instance.Set_Health_Bar(monster_behaviour.stat.max_health, monster_behaviour.current_health);

            if (monster_behaviour.current_health <= 0)
            {
                monster_behaviour.state_context.Transition(monster_behaviour.die_state);
            }
            else
            {
                //survive
                monster_behaviour.animation_behaviour.Change_Animation("Hit");
            }
        }
    }
}