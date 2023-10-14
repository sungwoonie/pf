using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Artifact
{
    public class Artifact_Pop_Up : SingleTon<Artifact_Pop_Up>
    {
        public TMP_Text artifact_title_text;
        public TMP_Text artifact_level_text;
        public TMP_Text price_text;
        public TMP_Text ratio_text;

        public GameObject pannel;

        private Artifact_Content current_artifact_content;

        private string Set_Ratio_Text(Artifact artifact)
        {
            string[] ratio = new string[artifact.stat_type.Length];
            string ratio_value = string.Empty;

            for (int i = 0; i < artifact.stat_type.Length; i++)
            {
                switch (artifact.stat_type[i])
                {
                    case "spell_power":
                        ratio[i] = "마력 * " + Text_Change.ToCurrencyString(artifact.Get_Artifact_Stat(artifact.stat_type[i]));
                        break;
                    case "casting_speed":
                        ratio[i] = "캐스팅 속도 + " + Text_Change.ToCurrencyString(artifact.Get_Artifact_Stat(artifact.stat_type[i]));
                        break;
                    case "critical_ratio":
                        ratio[i] = "크리티컬 확률 + " + Text_Change.ToCurrencyString(artifact.Get_Artifact_Stat(artifact.stat_type[i]));
                        break;
                    case "critical_damage":
                        ratio[i] = "크리티컬 데미지 + " + Text_Change.ToCurrencyString(artifact.Get_Artifact_Stat(artifact.stat_type[i]));
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < ratio.Length; i++)
            {
                ratio_value += ratio[i];
                ratio_value += "\n";
            }

            ratio_value = ratio_value.Replace("\\n", "\n");

            return ratio_value;
        }

        public void Set_Up(Artifact artifact, Artifact_Content artifact_content)
        {
            current_artifact_content = artifact_content;

            artifact_title_text.text = artifact.artifact_title;
            artifact_level_text.text = "Lv. " + artifact.level;
            ratio_text.text = Set_Ratio_Text(artifact);
            price_text.text = Text_Change.ToCurrencyString(current_artifact_content.purchase.price);

            pannel.SetActive(true);
        }

        public void Set_UI()
        {
            artifact_level_text.text = "Lv. " + current_artifact_content.artifact.level;
            ratio_text.text = Set_Ratio_Text(current_artifact_content.artifact);

            current_artifact_content.artifact_level_text.text = "Lv. " + current_artifact_content.artifact.level;
        }

        public void Enhance_Artifact()
        {
            if (!current_artifact_content.artifact.is_opened)
            {
                return;
            }

            if (current_artifact_content.purchase.Enhance_Artifact(current_artifact_content.artifact))
            {
                Set_UI();
            }
        }

        public void Equip_Artifact()
        {
            if (current_artifact_content.artifact.is_opened)
            {
                Artifact_Behaviour.instance.Equip_Artifact(current_artifact_content.artifact);
            }
        }
    }
}