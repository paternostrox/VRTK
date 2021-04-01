using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreatmentDatabase", menuName = "GameData/TreatmentDatabase")]
public class TreatmentDatabase : ScriptableObject
{
    public TreatmentData[] availableTreatments;
}
