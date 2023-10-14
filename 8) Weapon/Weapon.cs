using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Weapon
{
    public class Weapon : MonoBehaviour
    {
        public Weapon_Scriptable weapon;

        public float current_chance;

        public ParticleSystem[] enhance_effects;

        public TMP_Text weapon_title_text;
        public TMP_Text current_level_text;
        public TMP_Text ratio_text;
        public TMP_Text chance_text;

        private Purchase[] enhance_buttons; //0 = gold 1 = ruby

        private void Awake()
        {
            enhance_buttons = GetComponents<Purchase>();
        }

        public void Initialize()
        {
            current_chance = 80 - (10 * (weapon.current_weapon_level / 50));

            weapon_title_text.text = weapon.weapon_titles[weapon.current_weapon_level / 50];

            current_level_text.text = "Lv. " + weapon.current_weapon_level;

            double previous_ratio = 10 * (weapon.current_weapon_level * 1.2f);
            previous_ratio = Math.Round(previous_ratio * 100.0f) / 100.0f;

            ratio_text.text = Text_Change.ToCurrencyString(weapon.current_weapon_spell_power) + " > " + 
                Text_Change.ToCurrencyString(previous_ratio);

            chance_text.text = current_chance + "%";
        }

        public void Enhance_Weapon(int type)
        {
            if (enhance_buttons[type].Enhance_Weapon(weapon, current_chance, this))
            {
                Initialize();
            }
        }

        public void Enhance_Effect(int success)
        {
            enhance_effects[success].Play();
        }
    }
}