using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class Stage_Manager : SingleTon<Stage_Manager>
    {
        public int current_stage = 1;
        public int current_floor = 1;

        public GameObject[] point_icons;
        public TMPro.TMP_Text stage_text;

        public int Stage
        {
            get { return current_stage; }
            set
            {
                current_stage = value;
            }
        }

        public int Floor
        {
            get { return current_floor; }
            set
            {
                current_floor = value;

                if (current_floor > 6)
                {
                    current_floor = 1;
                    Stage++;
                }

                Set_Points();
                Data_Base.instance.Save_Stage_Data();
            }
        }

        public void Set_Points()
        {
            for (int i = 0; i < point_icons.Length; i++)
            {
                point_icons[i].SetActive(false);
            }

            if (Floor != 6)
            {
                point_icons[Floor - 1].SetActive(true);
            }

            stage_text.text = "STAGE " + Stage + " - " + Floor;
        }

        public bool Boss()
        {
            if (current_floor >= 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}