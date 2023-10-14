using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Artifact
{
    public class Artifact_Behaviour : SingleTon<Artifact_Behaviour>
    {
        public Artifact current_artifact;

        public void Equip_Artifact(Artifact artifact)
        {
            current_artifact = artifact;
        }

        public double Get_Artifact_Stat(string stat_type)
        {
            if (current_artifact.artifact_code == "")
            {
                return 1;
            }

            double target_stat = 0.0f;

            target_stat = current_artifact.Get_Artifact_Stat(stat_type);

            return target_stat;
        }
    }
}