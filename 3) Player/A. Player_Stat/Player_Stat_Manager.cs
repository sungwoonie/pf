using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player_Stat_Manager : MonoBehaviour
    {
        public Player_Stat_Scriptable player_stats;
        public Weapon.Weapon_Scriptable weapon_stats;

        public double basic_spell_power;
        public double basic_casting_speed;
        public double basic_critical_ratio;
        public double basic_critical_damage;

        public double Get_Casting_Speed()
        {
            double result = 0;
            result = basic_casting_speed + (player_stats.Casting_Speed);
            return result;
        }

        public double Get_Spell_Power()
        {
            double result = 0;
            result = basic_spell_power + ((player_stats.Spell_Power + weapon_stats.Get_Weapon_Spell_Power) 
                * Artifact.Artifact_Behaviour.instance.Get_Artifact_Stat("spell_power"));
            return result;
        }
    }
}