using System.Collections;
using UnityEngine;

[System.Serializable]
public class TreatmentPack
{
    public TreatmentData data;
    public TreatmentRepresentation rep;

    public TreatmentPack(TreatmentData data, TreatmentRepresentation rep)
    {
        this.data = data;
        this.rep = rep;
    }
}