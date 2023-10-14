using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    public class Run_State : MonoBehaviour, IState
    {
        private Monster_Behaviour monster_behaviour;

        public void Handle(Transform controller)
        {
            if (!monster_behaviour)
            {
                monster_behaviour = controller.GetComponent<Monster_Behaviour>();
            }

            StartCoroutine(Run_To_Position());
        }

        private IEnumerator Run_To_Position()
        {
            monster_behaviour.animation_behaviour.Change_Animation("Run");

            while (transform.position.x > 1.5f)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 1.5f);

                yield return null;
            }

            monster_behaviour.state_context.Transition(monster_behaviour.combat_state);
        }
    }
}