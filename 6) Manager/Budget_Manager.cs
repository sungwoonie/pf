using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Manager
{
    [System.Serializable]
    public class Budgets
    {
        public double current_gold;
        public double current_ruby;

        public double current_artifact_stone;

        public double current_thunder_stone;
        public double current_wind_stone;
        public double current_earth_stone;
        public double current_fire_stone;
    }

    public class Budget_Manager : SingleTon<Budget_Manager>
    {
        public TMP_Text gold_text;
        public TMP_Text ruby_text;

        public TMP_Text artifact_stone_text;

        public TMP_Text thunder_stone_text;
        public TMP_Text wind_stone_text;
        public TMP_Text earth_stone_text;
        public TMP_Text fire_stone_text;

        public Budgets budgets;


        private void Start()
        {
            Set_UI_All();
        }

        public void Set_UI(string budget_type)
        {
        }

        public void Set_UI_All()
        {
            gold_text.text = Text_Change.ToCurrencyString(budgets.current_gold);
            ruby_text.text = Text_Change.ToCurrencyString(budgets.current_ruby);
            artifact_stone_text.text = Text_Change.ToCurrencyString(budgets.current_artifact_stone);
            thunder_stone_text.text = Text_Change.ToCurrencyString(budgets.current_thunder_stone);
            wind_stone_text.text = Text_Change.ToCurrencyString(budgets.current_wind_stone);
            earth_stone_text.text = Text_Change.ToCurrencyString(budgets.current_earth_stone);
            fire_stone_text.text = Text_Change.ToCurrencyString(budgets.current_fire_stone);
        }

        public double Get_Budget(string budget_type)
        {
            var budget = budgets.GetType().GetField("current_" + budget_type).GetValue(budgets);

            return double.Parse(budget.ToString());
        }

        public void Calculate_Budget(string budget_type, double amount, string calculate_type)
        {
            double budget = Get_Budget(budget_type);

            switch (calculate_type)
            {
                case "+":
                    budget += amount;
                    break;
                case "-":
                    budget -= amount;
                    break;
                case "/":
                    budget /= amount;
                    break;
                case "*":
                    budget *= amount;
                    break;
                default:
                    break;
            }

            budgets.GetType().GetField("current_" + budget_type).SetValue(budgets, budget);

            Set_UI_All();
            Data_Base.instance.Save_Budget_Data();
        }
    }
}