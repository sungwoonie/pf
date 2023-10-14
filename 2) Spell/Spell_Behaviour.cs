using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spell
{
    public class Spell_Behaviour : MonoBehaviour
    {
        public Spell spell;

        private void OnEnable()
        {
            StartCoroutine(Shot());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public double Get_Spell_Damage()
        {
            double damage = spell.basic_damage + (spell.level * spell.damage_power);
            return damage;
        }

        private IEnumerator Shot()
        {
            if (spell.projectile)
            {
                while (transform.position.x < 7)
                {
                    transform.Translate(Vector2.right * Time.deltaTime * 5.0f);

                    yield return null;
                }
            }
            else
            {
                transform.position = new Vector3(1.5f, 1.5f, 0);
            }
        }

        private void Give_Damage(Monster.Combat_State current_monster)
        {
            for (int i = 0; i < spell.attack_count; i++)
            {
                current_monster.Hit(Get_Spell_Damage() * Player.Player_Behaviour.instance.stat_manager.Get_Spell_Power());
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Monster") || collision.CompareTag("Wall"))
            {
                if (collision.GetComponent<Monster.Combat_State>())
                {
                    Monster.Combat_State current_monster = collision.GetComponent<Monster.Combat_State>();
                    Give_Damage(current_monster);
                }

                gameObject.SetActive(false);
            }
            else if (collision.CompareTag("Dungeon_Monster"))
            {
                if (collision.GetComponent<Dungeon.Dungeon_Monster>())
                {
                    collision.GetComponent<Dungeon.Dungeon_Monster>().
                        Get_Damage(Get_Spell_Damage() * Player.Player_Behaviour.instance.stat_manager.Get_Spell_Power());
                }

                gameObject.SetActive(false);
            }
        }
    }
}