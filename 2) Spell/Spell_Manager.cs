using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spell
{
    public class Spell_Manager : SingleTon<Spell_Manager>
    {
        public Spell_Behaviour[] spell_behaviours;

        public void Set_All_Spell_Stat()
        {
            for (int i = 0; i < Data_Base.instance.spells.Length; i++)
            {
                if (Data_Base.instance.spells[i].spell_code == spell_behaviours[i].name)
                {
                    spell_behaviours[i].spell = Data_Base.instance.spells[i];
                }
            }
        }
    }
}