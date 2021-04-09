using System.Collections;
using UnityEngine;

public class TreatmentManager : MonoBehaviour
{
    public static TreatmentManager main;

    public TreatmentDatabase database;

    public GameObject[] treatmentObjs; // LEFT HERE

    public Treatment GetTreatment()
    {
        return database.GetRandomTreatment();
    }
}