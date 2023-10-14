using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    public class Die_State : MonoBehaviour, IState
    {
        private Monster_Behaviour monster_behaviour;
        private ParticleSystem gold_drop_effect;

        public void Handle(Transform controller)
        {
            if (!monster_behaviour)
            {
                monster_behaviour = controller.GetComponent<Monster_Behaviour>();
                gold_drop_effect = GameObject.Find("Gold_Drop_Effect").GetComponent<ParticleSystem>();
            }

            Monster_Die();
        }

        private void Monster_Die()
        {
            Event_Bus.Publish(Event_Type.Stop);
            Drop_Reward();
            monster_behaviour.animation_behaviour.Change_Animation("Death");
            Manager.Stage_Manager.instance.Floor++;
            StartCoroutine(Monster_Fade_Out());
            StartCoroutine(Dead());
        }

        private IEnumerator Monster_Fade_Out()
        {
            Color fade_out_color = Color.white;
            SpriteRenderer monster_sprite = monster_behaviour.GetComponent<SpriteRenderer>();

            float fade_time = 1.0f;

            while (gameObject.activeSelf || fade_time > 0.0f)
            {
                fade_time -= Time.deltaTime;
                monster_sprite.color = fade_out_color;
                fade_out_color.a = fade_time;

                yield return null;
            }
        }

        private IEnumerator Dead()
        {
            yield return new WaitForSeconds(1.5f);
            Event_Bus.Publish(Event_Type.Ready_To_Run);
            gameObject.SetActive(false);
        }

        private void Delete_Monster()
        {
            
        }

        public void Drop_Reward()
        {
            gold_drop_effect.Play();

            int ruby_random_count = Random.Range(0, 100);
            if (ruby_random_count <= monster_behaviour.stat.ruby_drop_chance)
            {
                Manager.Budget_Manager.instance.Calculate_Budget("ruby", monster_behaviour.stat.drop_ruby, "+");
            }

            Manager.Budget_Manager.instance.Calculate_Budget("gold", monster_behaviour.stat.drop_gold, "+");
        }
    }
}