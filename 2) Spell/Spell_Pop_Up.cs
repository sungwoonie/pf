using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Spell
{
    public class Spell_Pop_Up : SingleTon<Spell_Pop_Up>
    {
        public GameObject pop_up;

        public Spell_Content current_spell_content;

        public TMP_Text spell_title;
        public Image spell_icon;
        public TMP_Text ratio_text;
        public TMP_Text level_text;
        public TMP_Text attack_count_text;
        public TMP_Text price_text;

        public void Buy_Button()
        {
            if (current_spell_content.set_spell.spell.is_opened)
            {
                if(current_spell_content.purchase.Enhance_Spell(current_spell_content.set_spell.spell))
                {
                    Set_Up(current_spell_content);
                    current_spell_content.Data_Sync();
                    Data_Base.instance.Save_Spell_Data();
                }
            }
            else
            {
                if(current_spell_content.purchase.Buy_Spell(current_spell_content.set_spell.spell))
                {
                    Set_Up(current_spell_content);
                    current_spell_content.Set_UI();
                    current_spell_content.Data_Sync();
                    Data_Base.instance.Save_Spell_Data();
                }
            }

        }

        public void Set_Up(Spell_Content spell_content)
        {
            current_spell_content = spell_content;

            spell_title.text = current_spell_content.set_spell.spell.spell_title;
            level_text.text = "Lv. " + current_spell_content.set_spell.spell.level.ToString();
            attack_count_text.text = "공격 횟수 : " + current_spell_content.set_spell.spell.attack_count;
            price_text.text = Text_Change.ToCurrencyString(current_spell_content.purchase.price);

            spell_icon.sprite = current_spell_content.set_spell.spell.spell_icon;

            if (!current_spell_content.set_spell.spell.is_opened)
            {
                ratio_text.text = "구매 시 해방";
            }
            else
            {
                double previous_ratio = current_spell_content.set_spell.spell.basic_damage + ((current_spell_content.set_spell.spell.level + 1) * current_spell_content.set_spell.spell.damage_power);

                ratio_text.text = Text_Change.ToCurrencyString(current_spell_content.set_spell.Get_Spell_Damage()) + " > " +
                    Text_Change.ToCurrencyString(previous_ratio);
            }

            pop_up.SetActive(true);
        }

        public void Set_Off()
        {
            current_spell_content = null;

            pop_up.SetActive(false);
        }
    }
}