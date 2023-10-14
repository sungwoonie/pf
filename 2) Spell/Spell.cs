using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spell
{
    [System.Serializable]
    public class Spell
    {
        public string spell_code;
        public string spell_title;
        public Sprite spell_icon;
        public int level;
        public double basic_damage;
        public int attack_count;
        public bool is_opened;
        public bool projectile;
        public double damage_power;
    }
}