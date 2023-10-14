using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Artifact
{
    public class Artifact_Content : MonoBehaviour
    {
        public Artifact artifact;
        public TMP_Text artifact_level_text;

        public Purchase purchase;

        private void Start()
        {
            purchase = GetComponent<Purchase>();
        }

        public void Set_UI()
        {
            if (artifact.level.Equals(0))
            {
                artifact_level_text.text = "È¹µæ ÈÄ ÇØ¹æ";
            }
            else
            {
                artifact_level_text.text = "Lv. " + artifact.level;
            }
        }

        public void Show_Button()
        {
            Artifact_Pop_Up.instance.Set_Up(artifact, this);
        }
    }
}