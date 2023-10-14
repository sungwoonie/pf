using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 3)]
    public class Weapon_Scriptable : ScriptableObject
    {
        public string[] weapon_titles;
        public double current_weapon_spell_power;
        public int current_weapon_level;

        private double Round(double amount)
        {
            double result = Math.Round(amount * 100.0f) / 100.0f;
            return result;
        }

        public double Get_Weapon_Spell_Power
        {
            get
            {
                double total_spell_power;

                total_spell_power = 10 * (current_weapon_level * 1.2f);
                total_spell_power = Round(total_spell_power);

                return total_spell_power;
            }
        }
    }
}