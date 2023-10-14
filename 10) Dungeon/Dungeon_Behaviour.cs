using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dungeon
{
    public class Dungeon_Behaviour : SingleTon<Dungeon_Behaviour>
    {
        public Image fade_pannel;
        public GameObject top_box;
        public GameObject exit_pop_up;

        public Dungeon dungeon;
        //0 = gold, 1 = artifact,
        public bool is_in_dungeon;

        public void Enter_Dungeon(int dungeon_type)
        {
            if (is_in_dungeon)
            {
                return;
            }

            is_in_dungeon = true;

            StartCoroutine(Start_Dungeon(dungeon_type));
        }

        private IEnumerator Start_Dungeon(int dungeon_type)
        {
            is_in_dungeon = true;

            Event_Bus.Publish(Event_Type.Stop);

            yield return StartCoroutine(Fade_Pannel_In());

            top_box.SetActive(false);
            Monster.Monster_Spawner.instance.Off_All_Monsters();
            dungeon.Set_Dungeon(true, dungeon_type);
            yield return new WaitForSeconds(0.5f);

            yield return StartCoroutine(Fade_Pannel_Out());

            fade_pannel.gameObject.SetActive(false);
            dungeon.StartCoroutine(dungeon.Start_Timer());
            Event_Bus.Publish(Event_Type.Start_Combat);

            yield break;
        }

        public IEnumerator Exit_Dungeon()
        {
            Event_Bus.Publish(Event_Type.Stop);

            yield return StartCoroutine(Fade_Pannel_In());

            top_box.SetActive(true);
            dungeon.Set_Dungeon(false, 0);
            exit_pop_up.SetActive(true);

            yield return new WaitForSeconds(0.5f);

            yield return StartCoroutine(Fade_Pannel_Out());

            fade_pannel.gameObject.SetActive(false);
            Event_Bus.Publish(Event_Type.Ready_To_Run);
            is_in_dungeon = false;
        }

        #region "Fade"

        private IEnumerator Fade_Pannel_In()
        {
            fade_pannel.gameObject.SetActive(true);

            float fade_color_alpha = 0.0f;
            Color fade_color = Color.black;

            while (fade_color_alpha < 1.0f)
            {
                fade_color_alpha += Time.deltaTime * 1.3f;
                fade_color.a = fade_color_alpha;

                fade_pannel.color = fade_color;

                yield return null;
            }
        }

        private IEnumerator Fade_Pannel_Out()
        {
            fade_pannel.gameObject.SetActive(true);

            float fade_color_alpha = 1.0f;
            Color fade_color = Color.black;

            while (fade_color_alpha > 0.0f)
            {
                fade_color_alpha -= Time.deltaTime * 0.9f;
                fade_color.a = fade_color_alpha;

                fade_pannel.color = fade_color;

                yield return null;
            }
        }

        #endregion
    }
}