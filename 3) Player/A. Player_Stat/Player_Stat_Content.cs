using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Player
{
    public class Player_Stat_Content : MonoBehaviour
    {
        public Player_Stat_Scriptable target_stat;
        public string target_stat_type;
        public TMP_Text level_text;
        public TMP_Text ratio_text;

        public int max_level;

        private Purchase purchase_button;

        private void Awake()
        {
            purchase_button = GetComponent<Purchase>();
            Set_UI();
        }

        private bool Check_Max_Level()
        {
            var current_level_value = target_stat.GetType().GetField(target_stat_type + "_level" + "_" + purchase_button.budget_type).GetValue(target_stat);
            int level = int.Parse(current_level_value.ToString());
            if (level >= max_level && max_level != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Enhance_Button()
        {
            if (!Check_Max_Level())
            {
                return;
            }

            if (purchase_button.Enhance_Player_Stat(target_stat, target_stat_type))
            {
                Set_UI();
            }
        }

        public void Set_UI()
        {
            var current_level_value = target_stat.GetType().GetField(target_stat_type + "_level" + "_" + purchase_button.budget_type).GetValue(target_stat);
            double previous_ratio = 0;
            int test_int_level = int.Parse(current_level_value.ToString());

            if (test_int_level >= max_level && max_level != 0)
            {
                level_text.text = "Lv. MAX";
            }
            else
            {
                level_text.text = "Lv. " + test_int_level;
            }

            switch (target_stat_type)
            {
                case "spell_power":
                    previous_ratio = (test_int_level + 1) * 1.8f;
                    if (purchase_button.budget_type.Equals("gold"))
                    {
                        ratio_text.text = Text_Change.ToCurrencyString(target_stat.Spell_Power_Gold) + " > " + Text_Change.ToCurrencyString(Math.Round(previous_ratio * 100.0f) / 100.0f);
                    }
                    else
                    {
                        ratio_text.text = Text_Change.ToCurrencyString(target_stat.Spell_Power_Ruby) + " > " + Text_Change.ToCurrencyString(Math.Round(previous_ratio * 100.0f) / 100.0f);
                    }
                    break;
                case "casting_speed":
                    previous_ratio = (test_int_level + 1) * 0.02f;
                    if (purchase_button.budget_type.Equals("gold"))
                    {
                        ratio_text.text = target_stat.Casting_Speed_Gold + " > " + Math.Round(previous_ratio * 100.0f) / 100.0f;
                    }
                    else
                    {
                        ratio_text.text = target_stat.Casting_Speed_Ruby + " > " + Math.Round(previous_ratio * 100.0f) / 100.0f;
                    }
                    break;
                case "critical_ratio":
                    previous_ratio = (test_int_level + 1) * 0.5f;
                    if (purchase_button.budget_type.Equals("gold"))
                    {
                        ratio_text.text = target_stat.Critical_Ratio_Gold + " > " + Math.Round(previous_ratio * 100.0f) / 100.0f;
                    }
                    else
                    {
                        ratio_text.text = target_stat.Critical_Ratio_Ruby + " > " + Math.Round(previous_ratio * 100.0f) / 100.0f;
                    }
                    break;
                case "critical_damage":
                    previous_ratio = (test_int_level + 1) * 1.2f;
                    if (purchase_button.budget_type.Equals("gold"))
                    {
                        ratio_text.text = target_stat.Critical_Damage_Gold + " > " + Math.Round(previous_ratio * 100.0f) / 100.0f;
                    }
                    else
                    {
                        ratio_text.text = target_stat.Critical_Damage_Ruby + " > " + Math.Round(previous_ratio * 100.0f) / 100.0f;
                    }
                    break;
            }
        }
    }
}