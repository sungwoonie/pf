using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Spell
{
    public class Spell_Paragraph_Pop_Up : SingleTon<Spell_Paragraph_Pop_Up>
    {
        public TMP_Text price_text;
        public TMP_Text title_text;

        public double price;

        public GameObject pop_up;

        private bool can_buy = true;

        private Spell_Paragraph Get_Current_Paragraphs()
        {
            Spell_Paragraph[] current_paragraph = Spell_Book_Behaviour.instance.spell_paragraphs;

            for (int i = 0; i < current_paragraph.Length; i++)
            {
                if (!current_paragraph[i].is_opened)
                {
                    return current_paragraph[i];
                }
            }

            return null;
        }

        public void Set_Up()
        {
            Set_UI();

            pop_up.SetActive(true);
        }

        public void Set_UI()
        {
            Spell_Paragraph[] test = Spell_Book_Behaviour.instance.spell_paragraphs;

            for (int i = 0; i < test.Length; i++)
            {
                if (!test[i].is_opened)
                {
                    price = i * i * 1000;
                    price_text.text = Text_Change.ToCurrencyString(price);
                    return;
                }
            }

            can_buy = false;

            price_text.text = "¿Ï·á";
        }

        public void Buy()
        {
            if(Manager.Budget_Manager.instance.budgets.current_gold >= price && can_buy)
            {
                Spell_Paragraph current_paragraph = Get_Current_Paragraphs();

                current_paragraph.is_opened = true;
                Data_Base.instance.opend_spell_paragraphs_count++;
                Manager.Budget_Manager.instance.Calculate_Budget("gold", price, "-");
                Set_Up();
            }
        }
    }
}