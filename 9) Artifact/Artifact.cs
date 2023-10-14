using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Artifact
{
    [System.Serializable]
    public class Artifact
    {
        public string artifact_code;
        public string artifact_title;
        public string[] stat_type;
        public double[] stat_value;
        public float[] stat_power;

        public int level;

        public bool is_opened;

        public Sprite artifact_icon;

        public double Get_Artifact_Stat(string type)
        {
            double target_stat = 0.0f;

            for (int i = 0; i < stat_type.Length; i++)
            {
                if (type.Equals(stat_type[i]))
                {
                    target_stat = level * stat_power[i];
                    break;
                }
            }

            return target_stat;
        }
    }
}