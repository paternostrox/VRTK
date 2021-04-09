using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreatmentDatabase", menuName = "GameData/TreatmentDatabase")]
public class TreatmentDatabase : ScriptableObject
{
    public TreatmentData[] availableTreatments;

    public TreatmentData GetRandomTreatment()
    {
        int index = Random.Range(0, availableTreatments.Length);
        return availableTreatments[index];
    }
}
