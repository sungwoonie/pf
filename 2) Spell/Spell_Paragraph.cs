using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Spell
{
    public class Spell_Paragraph : MonoBehaviour, IPointerClickHandler
    {
        public Spell_Behaviour current_spell;
        public Image spell_icon;
        public GameObject lock_icon;

        private bool open;

        public bool is_opened
        {
            get
            {
                return open;
            }
            set
            {
                if (value == true)
                {
                    lock_icon.SetActive(false);
                    open = true;
                }
                else
                {
                    open = false;
                }
            }
        }

        public void Set_Spell(Spell_Behaviour new_spell)
        {
            current_spell = new_spell;

            spell_icon.sprite = current_spell.spell.spell_icon;
            spell_icon.color = Color.white;
        }

        public Spell_Behaviour Get_Spell()
        {
            return current_spell;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Spell_Paragraph_Pop_Up.instance.Set_Up();
        }
    }
}