using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Combat_State : MonoBehaviour, IState
    {
        private Player_Behaviour player_behaviour;

        private double current_spell_delay;
        private Vector2 spell_position = new Vector2(-1, 1.8f);

        public void Handle(Transform controller)
        {
            if (!player_behaviour)
            {
                player_behaviour = controller.GetComponent<Player_Behaviour>();
            }

            StartCoroutine(Combat());
        }

        public void Shot_Spell()
        {
            GameObject new_spell = Spell.Spell_Book_Behaviour.instance.Get_Spell();
            new_spell.transform.position = spell_position;
            new_spell.SetActive(true);
        }

        private IEnumerator Combat()
        {
            while (player_behaviour.state_context.Current_State.Equals(player_behaviour.combat_state))
            {
                current_spell_delay += Time.deltaTime * player_behaviour.stat_manager.Get_Casting_Speed();

                if (current_spell_delay >= 1.0f)
                {
                    if (Spell.Spell_Book_Behaviour.instance.Get_Spell())
                    {
                        player_behaviour.animation_behaviour.Change_Animation("Attack");
                        current_spell_delay = 0;
                    }
                }

                yield return null;
            }
        }
    }
}