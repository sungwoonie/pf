using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Dungeon
{
    public class Dungeon_Monster : MonoBehaviour
    {
        public TMP_Text damage_bar_text;
        public double total_damage;

        public void Initialize_Monster()
        {
            damage_bar_text.text = "0";
            total_damage = 0;
        }

        public void Get_Damage(double damage)
        {
            total_damage += damage;
            damage_bar_text.text = Text_Change.ToCurrencyString(total_damage);
        }
    }
}