using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spell
{
    public class Spell_Book_Behaviour : SingleTon<Spell_Book_Behaviour>
    {
        public Spell_Paragraph[] spell_paragraphs;

        public List<Spell_Paragraph> test = new List<Spell_Paragraph>();

        private int current_count = 0;

        private Object_Pooling spell_pools;

        protected override void Awake()
        {
            base.Awake();

            spell_pools = GetComponent<Object_Pooling>();
        }

        public void Set_Paragraphs(int opend_count)
        {
            int opend = opend_count;

            for (int i = 0; i < opend_count; i++)
            {
                spell_paragraphs[i].is_opened = true;
            }
        }

        public void Set_Spawned_Stat(string spell_code, Spell changed_spell)
        {
            List<GameObject> spawned_spell = spell_pools.Get_All_Pool(spell_code);
            if (spawned_spell == null)
            {
                return;
            }
            for (int i = 0; i < spawned_spell.Count; i++)
            {
                spawned_spell[i].GetComponent<Spell_Behaviour>().spell = changed_spell;
            }
        }

        public GameObject Get_Spell()
        {
            GameObject new_spell = null;

            if (!spell_paragraphs[current_count].is_opened || spell_paragraphs[current_count].current_spell == null)
            {
                current_count = 0;
            }

            if (spell_paragraphs[current_count].current_spell == null)
            {
                return null;
            }

            string spell_name = spell_paragraphs[current_count].current_spell.spell.spell_code;
            new_spell = spell_pools.Pool(spell_name).gameObject;

            current_count++;
            return new_spell;
        }

        public void Change_Spell(Spell_Behaviour set_spell, Spell_Paragraph spell_paragraph)
        {
            for (int i = 0; i < spell_paragraphs.Length; i++)
            {
                if (spell_paragraphs[i].current_spell)
                {
                    if (spell_paragraphs[i].current_spell.spell.spell_code == set_spell.spell.spell_code)
                    {
                        return;
                    }
                }
            }

            for (int i = 0; i < spell_paragraphs.Length; i++)
            {
                if (spell_paragraphs[i] == spell_paragraph)
                {
                    spell_paragraphs[i].Set_Spell(set_spell);
                    spell_pools.Set_New_Prafab_And_Create(set_spell.transform);
                    break;
                }
            }
        }

        public void Set_New_Spell(Spell_Behaviour set_spell)
        {
            for (int i = 0; i < spell_paragraphs.Length; i++)
            {
                if (spell_paragraphs[i].is_opened && spell_paragraphs[i].current_spell == null)
                {
                    for (int ii = 0; ii < spell_paragraphs.Length; ii++)
                    {
                        if (spell_paragraphs[ii].current_spell == set_spell)
                        {
                            return;
                        }
                    }

                    spell_paragraphs[i].Set_Spell(set_spell);
                    spell_pools.Set_New_Prafab_And_Create(set_spell.transform);
                    break;
                }
            }
        }
    }
}