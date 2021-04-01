using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField]
    TreatmentStation[] treatmentStations;

    [SerializeField]
    TPath spawnToWaitingZone;

    public int TryGetStation(out Transform[] path)
    {
        for(int i=0;i < treatmentStations.Length; i++)
        {
            if(!treatmentStations[i].isOccupied)
            {
                path = treatmentStations[i].spawnToStation.path;
                treatmentStations[i].isOccupied = true;
                return i; // returns station index
            }
        }
        path = null;
        return 0;
    }

    public Transform[] GetPathToWaitingZone()
    {
        return spawnToWaitingZone.path;
    }

    public Transform[] GetPathToExit(int stationIndex)
    {
        treatmentStations[stationIndex].isOccupied = false;
        return treatmentStations[stationIndex].stationToExit.path;
    }
}
