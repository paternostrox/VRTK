using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField]
    TreatmentStation[] treatmentStations;

    [SerializeField]
    Transform entranceToWaitingZonePath;

    public int TryGetStation(out Transform[] path)
    {
        for(int i=0;i < treatmentStations.Length; i++)
        {
            if(!treatmentStations[i].isOccupied)
            {
                path = treatmentStations[i].entranceToStationPath;
                treatmentStations[i].isOccupied = true;
                return i; // returns station index
            }
        }
        path = null;
        return 0;
    }

    public Transform[] GetPathToExit(int stationIndex)
    {
        treatmentStations[stationIndex].isOccupied = false;
        return null;// path
    }
}
