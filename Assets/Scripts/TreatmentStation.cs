using System.Collections;
using UnityEngine;
using NaughtyAttributes;

[System.Serializable]
public class TreatmentStation
{
    public bool isOccupied;
    //public Transform station;

    public Path spawnToStation;
    public Path stationToExit;
}