using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Spell
{
    public class Spell_Content : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        public Spell_Behaviour set_spell;
        public GameObject lock_image;

        [HideInInspector] public Purchase purchase;

        private void Awake()
        {
            purchase = GetComponent<Purchase>();
        }

        private void Start()
        {
            Set_UI();
        }

        public void Set_UI()
        {
            if (set_spell.spell.is_opened)
            {
                lock_image.SetActive(false);
            }
        }

        public void Data_Sync()
        {
            for (int i = 0; i < Data_Base.instance.spells.Length; i++)
            {
                if (Data_Base.instance.spells[i].spell_code == set_spell.spell.spell_code)
                {
                    Data_Base.instance.spells[i] = set_spell.spell;
                    break;
                }
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (set_spell.spell.is_opened)
            {
                if (eventData.pointerEnter.GetComponent<Spell_Paragraph>())
                {
                    Spell_Paragraph current_spell_paragraph = eventData.pointerEnter.GetComponent<Spell_Paragraph>();

                    if (current_spell_paragraph.current_spell == null)
                    {
                        Spell_Book_Behaviour.instance.Set_New_Spell(set_spell);
                    }
                    else
                    {
                        if (current_spell_paragraph.current_spell.spell.spell_code == set_spell.spell.spell_code)
                        {
                            return;
                        }

                        Spell_Book_Behaviour.instance.Change_Spell(set_spell, current_spell_paragraph);
                    }
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Spell_Pop_Up.instance.Set_Up(this);
        }
    }
}