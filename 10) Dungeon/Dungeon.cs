using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Dungeon
{
    public class Dungeon : MonoBehaviour
    {
        public Dungeon_Monster monster;
        public RuntimeAnimatorController[] monster_animators;

        public GameObject dungeon_ui;

        public TMP_Text title_text;
        public string[] titles;

        public Sprite[] dungeon_icon_sprites;
        public Image dungeon_icon;

        public Image reward_icon;
        public TMP_Text reward_text;

        public TMP_Text timer_text;
        public bool is_in;

        private int this_dungeon_type;

        public void Set_Dungeon(bool on_off, int type)
        {
            this_dungeon_type = type;

            if (on_off)
            {
                title_text.text = titles[type];
                dungeon_icon.sprite = dungeon_icon_sprites[type];
                monster.GetComponent<Animator>().runtimeAnimatorController = monster_animators[type];
                monster.Initialize_Monster();
            }

            monster.gameObject.SetActive(on_off);
            dungeon_ui.SetActive(on_off);
        }

        public IEnumerator Start_Timer()
        {
            int timer = 60;
            timer_text.text = timer.ToString();

            while (timer > 0)
            {
                yield return new WaitForSeconds(1);
                timer--;
                timer_text.text = timer.ToString();
            }

            Event_Bus.Publish(Event_Type.Stop);

            StartCoroutine(Dungeon_Behaviour.instance.Exit_Dungeon());

            double reward = monster.total_damage * 0.1f;

            reward_icon.sprite = dungeon_icon_sprites[this_dungeon_type];
            reward_text.text = "+ " + Text_Change.ToCurrencyString(reward);

            switch (this_dungeon_type)
            {
                case 0:
                    Manager.Budget_Manager.instance.Calculate_Budget("gold", reward, "+");
                    break;
                case 1:
                    Manager.Budget_Manager.instance.Calculate_Budget("artifact_stone", reward, "+");
                    break;
            }

            yield return null;
        }
    }
}