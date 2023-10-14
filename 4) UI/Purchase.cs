using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Purchase : MonoBehaviour
{
    public string budget_type;
    public double price;
    public float price_power;

    public TMP_Text price_text;

    private void Start()
    {
        Set_Price_Text();
    }

    private void Set_Price_Text()
    {
        if (price_text)
        {
            price_text.text = Text_Change.ToCurrencyString(price);
        }
    }

    public bool Buy()
    {
        bool bought = false;

        if (Manager.Budget_Manager.instance.Get_Budget(budget_type) >= price)
        {
            Manager.Budget_Manager.instance.Calculate_Budget(budget_type, price, "-");
            Set_Price();
            bought = true;
        }

        return bought;
    }

    public void Set_Price()
    {
        price *= price_power;
        Set_Price_Text();
    }

    public bool Enhance_Player_Stat(Player.Player_Stat_Scriptable stat, string stat_type)
    {
        bool is_purchased = false;

        if (!Buy())
        {
            return false;
        }
        
        var current_level_value = stat.GetType().GetField(stat_type + "_level" + "_" + budget_type).GetValue(stat);
        
        int level_value = int.Parse(current_level_value.ToString());

        stat.GetType().GetField(stat_type + "_level" + "_" + budget_type).SetValue(stat, level_value + 1);

        is_purchased = true;

        Data_Base.instance.Save_Player_Data();

        return is_purchased;
    }

    public bool Buy_Spell(Spell.Spell target_spell)
    {
        bool is_purchased = false;

        if (!Buy())
        {
            return false;
        }

        target_spell.level = 1;
        target_spell.is_opened = true;

        is_purchased = true;

        return is_purchased;
    }

    public bool Enhance_Spell(Spell.Spell target_spell)
    {
        bool is_purchased = false;

        if (!Buy())
        {
            return false;
        }

        target_spell.level++;
        Spell.Spell_Book_Behaviour.instance.Set_Spawned_Stat(target_spell.spell_code, target_spell);

        is_purchased = true;

        return is_purchased;
    }

    public bool Enhance_Weapon(Weapon.Weapon_Scriptable weapon_scriptable, float chance, Weapon.Weapon weapon)
    {
        bool is_purchased = false;

        if (!Buy())
        {
            return false;
        }

        int random_chance = Random.Range(0, 100);

        if (random_chance <= chance)
        {
            weapon_scriptable.current_weapon_level++;

            weapon.Enhance_Effect(1);

            weapon.current_chance = 80 - (10 * (weapon_scriptable.current_weapon_level / 50));
        }
        else
        {
            weapon.Enhance_Effect(0);
        }

        is_purchased = true;

        Data_Base.instance.Save_Weapon_Data();

        return is_purchased;
    }

    public bool Enhance_Artifact(Artifact.Artifact artifact)
    {
        bool is_purchased = false;

        if (!Buy())
        {
            return false;
        }

        artifact.level++;

        is_purchased = true;

        Data_Base.instance.Save_Artifact_Data();

        return is_purchased;
    }
}