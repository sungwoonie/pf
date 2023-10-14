using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player
{
    [CreateAssetMenu(fileName = "Player_Stat", menuName = "Player_Stat", order = 1)]
    public class Player_Stat_Scriptable : ScriptableObject
    {
        private double casting_speed;
        private double spell_power;
        private double critical_ratio;
        private double critical_damage;

        [Header("Gold Stat")]
        public int critical_damage_level_gold;
        public int critical_ratio_level_gold;
        public int spell_power_level_gold;
        public int casting_speed_level_gold;

        [Header("Ruby Stat")]
        public int critical_damage_level_ruby;
        public int critical_ratio_level_ruby;
        public int spell_power_level_ruby;
        public int casting_speed_level_ruby;

        private double Round(double amount)
        {
            double result = Math.Round(amount * 100.0f) / 100.0f;
            return result;
        }

        #region "Gold Stat"
        public double Spell_Power_Gold
        {
            get
            {
                double current_spell_power = spell_power_level_gold * 1.8f;
                return Round(current_spell_power);
            }
        }

        public double Casting_Speed_Gold
        {
            get
            {
                double current_casting_spell = casting_speed_level_gold * 0.02f;
                return Round(current_casting_spell);
            }
        }

        public double Critical_Ratio_Gold
        {
            get
            {
                double current_critical_ratio = critical_ratio_level_gold * 0.5f;
                return Round(current_critical_ratio);
            }
        }

        public double Critical_Damage_Gold
        {
            get
            {
                double current_critical_damage = critical_damage_level_gold * 1.2f;
                return Round(current_critical_damage);
            }
        }
        #endregion

        #region "Ruby Stat"
        public double Spell_Power_Ruby
        {
            get
            {
                double current_spell_power = spell_power_level_ruby * 1.8f;
                return Round(current_spell_power);
            }
        }

        public double Casting_Speed_Ruby
        {
            get
            {
                double current_casting_spell = casting_speed_level_ruby * 0.02f;
                return Round(current_casting_spell);
            }
        }

        public double Critical_Ratio_Ruby
        {
            get
            {
                double current_critical_ratio = critical_ratio_level_ruby * 0.5f;
                return Round(current_critical_ratio);
            }
        }

        public double Critical_Damage_Ruby
        {
            get
            {
                double current_critical_damage = critical_damage_level_ruby * 1.2f;
                return Round(current_critical_damage);
            }
        }
        #endregion

        #region "Total Level"
        public int Spell_Power_Level
        {
            get
            {
                return spell_power_level_gold + spell_power_level_ruby;
            }
        }

        public int Casting_Speed_Level
        {
            get
            {
                return casting_speed_level_gold + casting_speed_level_ruby;
            }
        }

        public int Critical_Ratio_Level
        {
            get
            {
                return critical_ratio_level_gold + critical_ratio_level_ruby;
            }
        }

        public int Critical_Damage_Level
        {
            get
            {
                return critical_damage_level_gold + critical_damage_level_ruby;
            }
        }
        #endregion

        #region "Total Stat"
        public double Spell_Power
        {
            get
            {
                double current_spell_power = Spell_Power_Level * 1.8f;
                return current_spell_power;
            }
        }

        public double Casting_Speed
        {
            get
            {
                double current_casting_spell = Casting_Speed_Level * 0.02f;
                return Round(current_casting_spell);
            }
        }

        public double Critical_Ratio
        {
            get
            {
                double current_critical_ratio = Critical_Ratio_Level * 0.5f;
                return Round(current_critical_ratio);
            }
        }

        public double Critical_Damage
        {
            get
            {
                double current_critical_damage = Critical_Damage_Level * 1.2f;
                return Round(current_critical_damage);
            }
        }
        #endregion
    }
}