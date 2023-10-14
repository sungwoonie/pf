using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Artifact
{
    public class Artifact_Manager : SingleTon<Artifact_Manager>
    {
        public Artifact[] artifacts;
        public Artifact_Content[] artifact_contents;

        private void Start()
        {
            Set_All_Artifact();
        }

        public void Set_All_Artifact()
        {
            for (int i = 0; i < artifacts.Length; i++)
            {
                if (artifacts[i].artifact_code == artifact_contents[i].name)
                {
                    artifact_contents[i].artifact = artifacts[i];
                }
            }

            for (int i = 0; i < artifact_contents.Length; i++)
            {
                artifact_contents[i].Set_UI();
            }
        }
    }
}